@echo off
set /p migration=Enter Migration Name:
if "%migration%"=="" (
	echo You didn't enter migration name!
)


cd ..\src\RFLOT.Infrastructure

if "%migration%"=="-" (
	echo Removing last migration!
	dotnet ef migrations remove -s ..\RFLOT.Gateway\RFLOT.Gateway.csproj -c ZoneDbContext
) else (
	dotnet ef migrations add %migration% -s ..\RFLOT.Gateway\RFLOT.Gateway.csproj -c ZoneDbContext -o Zone\Migrations
)

if %errorlevel% == 0 (
	timeout 5
) else (
	pause
)
