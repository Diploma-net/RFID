FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY ./RFLOT.WebApi/RFLOT.WebApi.csproj ./RFLOT.WebApi/RFLOT.WebApi.csproj
COPY ./RFLOT.Infrastructure/RFLOT.Infrastructure.csproj ./RFLOT.Infrastructure/RFLOT.Infrastructure.csproj
COPY ./RFLOT.Application/RFLOT.Application.csproj ./RFLOT.Application/RFLOT.Application.csproj
COPY ./RFLOT.Domain/RFLOT.Domain.csproj ./RFLOT.Domain/RFLOTi.Domain.csproj

# restore only main project, it references everything that is required
RUN dotnet restore ./RFLOT.WebApi/RFLOT.WebApi.csproj

COPY ./RFLOT.WebApi ./RFLOT.WebApi
COPY ./RFLOT.Infrastructure ./RFLOT.Infrastructure
COPY ./RFLOT.Application ./RFLOT.Application
COPY ./RFLOT.Domain ./RFLOT.Domain

RUN dotnet publish ./RFLOT.WebApi/RFLOT.WebApi.csproj -c Release -o out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out /app

ENTRYPOINT ["dotnet", "/app/RFLOT.WebApi.dll"]