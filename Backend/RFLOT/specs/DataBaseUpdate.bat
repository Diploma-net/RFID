@echo off
cd ..
dotnet ef database update --project src\RFLOT.Infrastructure\RFLOT.Infrastructure.csproj --startup-project src\RFLOT.Gateway\RFLOT.Gateway.csproj --context EquipDbContext
dotnet ef database update --project src\RFLOT.Infrastructure\RFLOT.Infrastructure.csproj --startup-project src\RFLOT.Gateway\RFLOT.Gateway.csproj --context PlaneDbContext
dotnet ef database update --project src\RFLOT.Infrastructure\RFLOT.Infrastructure.csproj --startup-project src\RFLOT.Gateway\RFLOT.Gateway.csproj --context ReportDbContext
dotnet ef database update --project src\RFLOT.Infrastructure\RFLOT.Infrastructure.csproj --startup-project src\RFLOT.Gateway\RFLOT.Gateway.csproj --context ZoneDbContext
dotnet ef database update --project src\RFLOT.Identity\RFLOT.Identity.csproj --startup-project src\RFLOT.Gateway\RFLOT.Gateway.csproj --context UserDbContext
pause