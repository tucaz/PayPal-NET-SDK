# PayPal .NET SDK

[![Build status](https://ci.appveyor.com/api/projects/status/kofokkh2ir74hywx?svg=true)](https://ci.appveyor.com/project/tucaz/paypal-net-sdk)

This is a fork from the original [v1 PayPal SDK](https://github.com/paypal/PayPal-NET-SDK) that seems to be abandoned by PayPal.

The [old documentation](https://github.com/paypal/PayPal-NET-SDK/blob/develop/README.md) is still valid and my plan is to update it as I move forward with the library.

It seemed like none of the multiple packages available on nuget.org are working well so that's the reason I created yet another fork.

# Configuration

The original configuration of the SDK was based on the old `app.config` paradigm and has been migrated to the new .NET Core standard.

`appsettings.json` example:

```js
{
  "PayPal": {
    "mode": "sandbox",
    "connectionTimeout": 360000,
    "requestRetries": 3,
    "clientId": "AYrAaReQUybACfY3NJNZ1CNpbf8IdERKSHvA-urkP5G8YXzJd2khdkD8LT2WpDMUhXjn8NPl4sTFnYa2",
    "clientSecret": "EObW1isFRDZKO6xe2FvpwABDdOsGrhrsKqMrWzSC4Ndz8k5WeYnpYofCm9EAdibSEBv5Gel6J86TzENj"
  }
}
```

# Examples

Examples can be found inside the `Samples.old` folder as they are migrated. Once they are all migrated, they will live in the `Samples` folder.

Even though the samples provided are not really comprehensive, they are a start.

# How to contribute / I want to help
 
 There are multiple things that are necessary to bring this old library into life. Here are some if you are interested:
 
 - [ ] Migrate samples from old ASPX style pages into Controllers or Razor Pages
 - [ ] Provide documentation on how to setup, configure and debug the SDK (the original examples are not comprehensive enough IMO)
 - [ ] Improve the internal implementation of basic things such as `HttpConnection`, exception handling, logging, etc
 
 If there is anything that should be worked on first, please open an issue and I'm happy to help. If you feel like helping with any of these tasks just send a PR :) 