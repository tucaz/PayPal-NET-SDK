@echo off

ECHO PayPal .NET SDK
ECHO ======================================

IF "%VS120COMNTOOLS%"=="" GOTO :VS_NOT_FOUND

:: .NET 4.0
"%VS120COMNTOOLS%\..\IDE\devenv.com" PayPal.SDK.NET40.sln /build Debug
"%VS120COMNTOOLS%\..\IDE\devenv.com" PayPal.SDK.NET40.sln /build Release

:: .NET 4.5
"%VS120COMNTOOLS%\..\IDE\devenv.com" PayPal.SDK.NET45.sln /build Debug
"%VS120COMNTOOLS%\..\IDE\devenv.com" PayPal.SDK.NET45.sln /build Release

:: .NET 4.5.1
"%VS120COMNTOOLS%\..\IDE\devenv.com" PayPal.SDK.NET451.sln /build Debug
"%VS120COMNTOOLS%\..\IDE\devenv.com" PayPal.SDK.NET451.sln /build Release

GOTO :END

:VS_NOT_FOUND
ECHO Visual Studio 2013 was not found.

:END
