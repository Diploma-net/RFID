@echo off
set /p migration=Enter Migration Name:
if "%migration%"=="" (
	echo You didn't enter migration name!
)

cd ..\src\RFLOT.Infrastructure

if "%migration%"=="-" (
	echo Removing last migration!
	dotnet ef migrations remove -s ..\RFLOT.WebApi\RFLOT.WebApi.csproj -c RfidContext
) else (
	dotnet ef migrations add %migration% -s ..\RFLOT.WebApi\RFLOT.WebApi.csproj -c RfidContext -o Migrations\Rfid
)

if %errorlevel% == 0 (
	timeout 5
) else (
	pause
)
