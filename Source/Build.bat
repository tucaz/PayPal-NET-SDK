@echo off

ECHO PayPal .NET SDK
ECHO ======================================

SET VSTOOLS=%VS140COMNTOOLS%
IF "%VSTOOLS%"=="" GOTO :VS_NOT_FOUND

SET IDE_DIR=%VSTOOLS%\..\IDE
SET DEVENV="%IDE_DIR%\devenv.com"
%DEVENV% PayPal.SDK.NET40.sln /build Release
%DEVENV% PayPal.SDK.NET45.sln /build Release
%DEVENV% PayPal.SDK.NET451.sln /build Release

IF NOT EXIST TestResults MKDIR TestResults
DEL TestResults\results_net*.xml

SET MSTEST="%IDE_DIR%\MSTest.exe"
SET TEST_DLL=PayPal.Tests.dll
%MSTEST% /testcontainer:Tests\bin\Release\net40\%TEST_DLL% /category:Unit /resultsfile:TestResults\results_net40.xml
%MSTEST% /testcontainer:Tests\bin\Release\net45\%TEST_DLL% /category:Unit /resultsfile:TestResults\results_net45.xml
%MSTEST% /testcontainer:Tests\bin\Release\net451\%TEST_DLL% /category:Unit /resultsfile:TestResults\results_net451.xml
GOTO :END

:VS_NOT_FOUND
ECHO Visual Studio 2015 was not found.

:END
