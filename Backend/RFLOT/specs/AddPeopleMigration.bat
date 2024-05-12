@echo off
set /p migration=Enter Migration Name:
if "%migration%"=="" (
	echo You didn't enter migration name!
)


cd ..\src\RFLOT.Identity

if "%migration%"=="-" (
	echo Removing last migration!
	dotnet ef migrations remove -s ..\RFLOT.Gateway\RFLOT.Gateway.csproj -c UserDbContext
) else (
	dotnet ef migrations add %migration% -s ..\RFLOT.Gateway\RFLOT.Gateway.csproj -c UserDbContext -o Migrations\User
)

if %errorlevel% == 0 (
	timeout 5
) else (
	pause
)
