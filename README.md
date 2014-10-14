# PayPal REST API SDK for .NET

> **Before using this SDK, please be aware of the [existing issues and currently available or upcoming features](https://github.com/paypal/rest-api-sdk-python/wiki/Existing-Issues-and-Unavailable%5CUpcoming-features) for the PayPal REST APIs (which all PayPal REST API SDKs are based upon).**

## Contents

* [Prerequisites](https://github.com/paypal/rest-api-sdk-dotnet#prerequisites)
* [Getting Started](https://github.com/paypal/rest-api-sdk-dotnet#getting-started)
  * 1. [Download the Dependencies](https://github.com/paypal/rest-api-sdk-dotnet#download-the-dependencies)
  * 2. [Configure Your Application](https://github.com/paypal/rest-api-sdk-dotnet#configure-your-application)
  * 5. [Make Your First Call](https://github.com/paypal/rest-api-sdk-dotnet#make-your-first-call)
* [NuGet](https://github.com/paypal/rest-api-sdk-dotnet#nuget)
* [License](https://github.com/paypal/rest-api-sdk-dotnet#license)

## Prerequisites

* Visual Studio 2008 or higher
* [NuGet](https://github.com/paypal/rest-api-sdk-dotnet#nuget)

## Getting Started

### 1. Download the Dependencies

To begin using this SDK, first download this SDK from NuGet.

````
NuGet Install -Package RestApiSDK
````

Optionally, also download [log4net](https://www.nuget.org/packages/log4net/) to give your application enhanced logging capabilities.

````
NuGet Install -Package log4net
````

Once all the libraries are downloaded, simply add the following libraries to your project references (**Project** > **Add Reference...**):
 * RestApiSDK.dll
 * PayPalCoreSDK.dll
 * Newtonsoft.Json.dll
 * log4net.dll

### 2. Configure Your Application

When using the SDK with your application, the SDK will attempt to look for PayPal-specific settings in your application's **app.config** or **web.config** file.

````xml
<configuration>
  <!--
  Specifies what user-defined sections will appear in this file, as well as which objects internally are able to access the sections.
  NOTE: This element MUST be the first child under the root element in the *.config file.
  -->
  <configSections>
    <section name="paypal" type="PayPal.Manager.SDKConfigHandler, PayPalCoreSDK" />
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
  </configSections>

  <!-- PayPal SDK settings -->
  <paypal>
    <settings>
      <add name="mode" value="sandbox"/>
      <add name="connectionTimeout" value="360000"/>
      <add name="requestRetries" value="1"/>
      <add name="clientId" value="EBWKjlELKMYqRNQ6sYvFo64FtaRLRR5BdHEESmha49TM"/>
      <add name="clientSecret" value="EO422dn3gQLgDbuwqTjzrFgFtaRLRR5BdHEESmha49TM"/>
    </settings>
  </paypal>

  <!-- log4net settings -->
  <log4net>
    <appender name="FileAppender" type="log4net.Appender.FileAppender">
      <file value="my_app.log"/>
      <appendToFile value="true"/>
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] %message%newline"/>
      </layout>
    </appender>
    <root>
      <level value="DEBUG"/>
      <appender-ref ref="FileAppender"/>
    </root>
  </log4net>
  
  <!-- 
  App-specific settings. Here we specify which PayPal logging classes are enabled.
    PayPal.Log.Log4netLogger: Provides base log4net logging functionality
    PayPal.Log.DiagnosticsLogger: Provides more thorough logging of system diagnostic information and tracing code execution
  -->
  <appSettings>
    <add key="PayPalLogger" value="PayPal.Log.DiagnosticsLogger, PayPal.Log.Log4netLogger"/>
  </appSettings>
</configuration>
````

The following are values that can be specified in the `<paypal>` section of the **app.config** or **web.config** file:

| Name | Description |
| ---- | ----------- |
| `mode` | Determines which PayPal endpoint URL will be used with your application. Possible values are `live` or `sandbox`. |
| `endpoint` | Overrides the default REST endpoint URL as well as `mode`, if set. |
| `oauth.EndPoint` | Overrides the default endpoint URL used for gettings OAuth tokens. |
| `IPNEndpoint` | Overrides the default endpoint URL used for validating IPN messages. |
| `requestRetries` | The number of times HTTP requests should be attempted by the SDK before an error is thrown. Default value is `3`. |
| `connectionTimeout` | The amount of time (in milliseconds) before an HTTP request should timeout. Default value is `30000`. |
| `clientId` | Your application's **Client ID** as specified on your PayPal account's [My REST Apps](https://developer.paypal.com/webapps/developer/applications/myapps) page for your specific application. |
| `clientSecret` | Your application's **Client Secret** as specified on your PayPal account's [My REST Apps](https://developer.paypal.com/webapps/developer/applications/myapps) page for your specific application. |
| `proxyAddress` | The address for a proxy server your application must tunnel through in order to connect with PayPal. |
| `proxyCredentials` | If `proxyAddress` is set, use this field to specify the username and password for the proxy server. The format must be `username:password`. |

### 3. Make Your First Call

**Authenticate With PayPal**

Before you can begin making various calls to PayPal's REST APIs via the SDK, you must first authenticate with PayPal using an **OAuth access token** that can be used with each call.  To do this, you will need to use the `OAuthTokenCredential` class.

````c#
// Get a reference to the config
var config = PayPal.Manager.ConfigManager.Instance.GetProperties();

// Read the clientId and clientSecret stored in the config
var clientId = config[BaseConstants.ClientId];
var clientSecret = config[BaseConstants.ClientSecret];

// Use OAuthTokenCredential to request an access token from PayPal
var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
````		
**NOTE:** It is not mandatory to generate the `accessToken` with every call using the SDK. Typically, the access token can be generated once and reused until it expires.

For more information on the access token and how it is used in calls to PayPal, refer to [How PayPal Uses OAuth 2.0](https://developer.paypal.com/docs/integration/direct/paypal-oauth2/).

**Configure an APIContext Object**

To make it easier for developers to customize how calls are being made to PayPal with the SDK, we offer an `APIContext` object that can be created using the `accessToken` from the code example in the previous step.

````c#
var apiContext = new APIContext(accessToken);
````

This object can be further setup to include custom configuration settings as well as include specific HTTP headers, allowing for more flexibility and customization in how HTTP requests are made using this SDK.

````c#
// Initialize the apiContext's configuration with the default configuration for this application.
apiContext.Config = PayPal.Manager.ConfigManager.Instance.GetProperties();

// Define any custom configuration settings for calls that will use this object.
apiContext.Config["connectionTimeout"] = 1000; // Quick timeout for testing purposes

// Define any HTTP headers to be used in HTTP requests made with this APIContext object
if(apiContext.HTTPHeaders == null)
{
  apiContext.HTTPHeaders = new Dictionary<string, string>();
}
apiContext.HTTPHeaders["some-header-name"] = "some-value";
````

**NOTE:** When using `APIContext.HTTPHeaders`, be aware that some headers will be overwritten depending on the SDK call (e.g. `Authorization`, `Content-Type`, and `User-Agent`).

**Use the APIContext Object to Make SDK Calls**

Now that you have your `APIContext` object setup, it's time to make your first call with the SDK.  The following is a simple example of how to get the details of a PayPal payment using a `paymentId`.

```c#
var paymentId = "PAY-0XL713371A312273YKE2GCNI";
var payment = Payment.Get(apiContext, paymentId);
```

For more information on what features are supported by this SDK, refer to the [REST API Reference](https://developer.paypal.com/docs/api/) page on [developer.paypal.com](https://developer.paypal.com/).

To get more code samples for using the SDK with the various PayPal features, refer to the [Samples](https://github.com/paypal/rest-api-sdk-dotnet/tree/master/Samples) project in this repository.


## NuGet 

NuGet is a Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects that use the .NET Framework.  If you develop a library or tool that you want to share with other developers, you create a NuGet package and store the package in a NuGet repository. If you want to use a library or tool that someone else has developed, you retrieve the package from the repository and install it in your Visual Studio project or solution. When you install the package, NuGet copies files to your solution and automatically makes whatever changes are needed, such as adding references and changing your app.config or web.config file. If you decide to remove the library, NuGet removes files and reverses whatever changes it made in your project so that no clutter is left.

Here is how you can get NuGet working on your IDE - 

* [Installing NuGet in Visual Studio 2005 & 2008] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2005-&-2008)
* [Installing NuGet in Visual Studio 2010 & 2012] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2010-&-2012)

## License

* PayPal, Inc. SDK License - [LICENSE.txt](https://github.com/paypal/rest-api-sdk-dotnet/blob/master/LICENSE.txt)

[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/paypal/rest-api-sdk-dotnet/trend.png)](https://bitdeli.com/free "Bitdeli Badge")
