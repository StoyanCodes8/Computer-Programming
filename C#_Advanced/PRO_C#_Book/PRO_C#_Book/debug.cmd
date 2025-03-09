@echo off
rem A batch file to run the C# app and capture its return value
dotnet run
@if "%ERRORLEVEL%" == "0" goto success
@if "ERRORLEVEL%" == "-1" goto fail
:fail
echo This application has failed!
echo return value = %ERRORLEVEL%
goto end
:success
echo This application has succeeded!
echo return value = %ERRORLEVEL%
goto end
:end
echo All Done.
pause