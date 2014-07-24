@echo off
IF exist "C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\" ( call "C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.com" RestApiSDK.VS.2008.sln /build Release)

IF exist "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\" ( call "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com" RestApiSDK.VS.2010.sln /build Release)

IF exist "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\" ( call "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\devenv.com" RestApiSDK.VS.2012.sln /build Release)