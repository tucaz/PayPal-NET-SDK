# PayPal .NET SDK

[![Build status](https://ci.appveyor.com/api/projects/status/kofokkh2ir74hywx?svg=true)](https://ci.appveyor.com/project/tucaz/paypal-net-sdk)

This is a fork from the original [v1 PayPal SDK](https://github.com/paypal/PayPal-NET-SDK) that seems to be abandoned by PayPal.

The [old documentation](https://github.com/paypal/PayPal-NET-SDK/blob/develop/README.md) is still valid and my plan is to update it as I move forward with the library.

It seemed like none of the multiple packages available on nuget.org are working well so that's the reason I created yet another fork.

# Changes from original repository

## Webhook event validations

In the original version, event sent by PayPal via webhooks could be validated locally based on the ceritificates provided by PayPal. However, with .NET Core things changed and that stopped working. For that reason, `WebhookEvent.ValidateReceivedEvent` has been removed from this library.

Now, instead of using `WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId)` you should use `new VerifyWebhookSignature().Post` according to the example below:

```c#
var content = "";
using (var sr = new StreamReader(request.Body, true))
{
    content = sr.ReadToEnd();
}
var paypalEvent = JsonConvert.DeserializeObject<WebhookEvent>(content);
var verificationRequest = new VerifyWebhookSignature()
{
    auth_algo = request.Headers["paypal-auth-algo"].ToString(),
    cert_url = request.Headers["paypal-cert-url"].ToString(),
    transmission_id = request.Headers["paypal-transmission-id"].ToString(),
    transmission_sig = request.Headers["paypal-transmission-sig"].ToString(),
    transmission_time = request.Headers["paypal-transmission-time"].ToString(),
    webhook_id = "YOUR_WEBHOOK_ID",
    webhook_event =  paypalEvent
};

var verification = verificationRequest.Post(GetPayPalContext()); //Pass your APIContext instance
    
if (verification.verification_status == "SUCCESS") 
    //EVENT IS VERIFIED

```

### Troubleshooting

The moethod above will ask PayPal to verify the event for you. This verification is a constant source of pain. The primary reason is that PayPal wants to receive the event exactly in the way it sent you, meaning that field order matters in the JSON that is sent to PayPal. Verify this first if it stops working for you.

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

# Running tests

As of 08/18/2019 all tests are passing. However, PayPal sandbox servers are not always in good mood so from time to time it throws some 404 or 503. If that happens with you, run the same test a couple more times and it should work.

# Examples

Examples can be found inside the `Samples.old` folder as they are migrated. Once they are all migrated, they will live in the `Samples` folder.

Even though the samples provided are not really comprehensive, they are a start.

# How to contribute / I want to help
 
 There are multiple things that are necessary to bring this old library into life. Here are some if you are interested:
 
 - [ ] Migrate samples from old ASPX style pages into Controllers or Razor Pages
 - [ ] Provide documentation on how to setup, configure and debug the SDK (the original examples are not comprehensive enough IMO)
 - [ ] Improve the internal implementation of basic things such as `HttpConnection`, exception handling, logging, etc
 
 If there is anything that should be worked on first, please open an issue and I'm happy to help. If you feel like helping with any of these tasks just send a PR :) 
