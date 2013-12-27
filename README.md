The repository contains the PayPal PaymentSDK C#.NET Class Library Application and the PaymentSDKUnitTest C#.NET Visual Studio Test Application.


Prerequisites
-------------
   *   Visual Studio 2008 or higher
   *   log4net 1.2.10
   *   NuGet 2.2
   *   Note: NuGet 2.2 requires .NET Framework 4.0

	
To make an API call
--------------------
   *  Add references to the following libraries in your project.
      *   RestApiSDK 
      *   PayPalCoreSDK.dll 
      *   Newtonsoft.Json.dll
      *   log4net.dll 1.2.10.0
   *   Refer to the App.config file configuration file settings		
   *   Create 'accesstoken' from 'ClientID' and 'ClientSecret' using `OAuthTokenCredential` and set the same in resource as follows,

		// Retrieve the access token from
		// OAuthTokenCredential by passing in
		// ClientID and ClientSecret
		// It is not mandatory to generate Access Token on a per call basis.
		// Typically the access token can be generated once and
		// reused within the expiry window
		string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperties()["ClientID"], ConfigManager.Instance.GetProperties()["ClientSecret"]).GetAccessToken();
		
   *   Depending on the context of API calls, calling method may be static or non-static (For example, most 'GET' http methods are created as `static` methods within the resource).
	 
   If it is static, invoke it as a class method as seen here

```csharp
		// Retrieve the payment object by calling the
		// static `Get` method
		// on the Payment class by passing a valid
		// AccessToken and Payment ID
		Payment pymnt = Payment.Get(accessToken, "PAY-0XL713371A312273YKE2GCNI");
```


   If it is non-static, invoke it using resource object using the following syntax
      
```csharp
		// A Payment Resource; create one using
		// the above types and intent as `sale`
		Payment pymnt = new Payment();
		pymnt.intent = "sale";
		...
		...
		pymnt.Create(accessToken);
```

App.Config Configuration
------------------------
   *   endpoint
   *   ClientID
   *   ClientSecret


NuGet 
-----

NuGet is a Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects that use the .NET Framework. 	If you develop a library or tool that you want to share with other developers, you create a NuGet package and store the package in a NuGet repository. If you want to use a library or tool that someone else has developed, you retrieve the package from the repository and install it in your Visual Studio project or solution. When you install the package, NuGet copies files to your solution and automatically makes whatever changes are needed, such as adding references and changing your app.config or web.config file. If you decide to remove the library, NuGet removes files and reverses whatever changes it made in your project so that no clutter is left.

Here is how you can get NuGet working on your IDE - 

   * [Installing NuGet in Visual Studio 2005 & 2008] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2005-&-2008)
   * [Installing NuGet in Visual Studio 2010 & 2012] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2010-&-2012)

License
-------
   *   PayPal, Inc. SDK License - LICENSE.txt

[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/paypal/rest-api-sdk-dotnet/trend.png)](https://bitdeli.com/free "Bitdeli Badge")
