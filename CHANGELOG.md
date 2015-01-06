PayPal .NET SDK release notes
=============================

## v1.2.1
* Fix `Sale.Refund()`
* Remove empty `Percentage` class

## v1.2.0
* Add Payouts support

## v1.1.0
* Add Webhooks support
* Add missing class properties
  * `Agreement.agreement_details`
  * `Agreement.state`
  * `CreditCard.payer_id`
* Add OAuthTokenCredential constructor that just takes config

## v1.0.0
* Integrated PayPal Core SDK
* Renamed projects and built assemblies
* Removed .NET 3.5 support
* Added .NET 4.5.1 support
* Built assemblies are now marked with AllowPartiallyTrustedCallers attribute
* Updated Invoice support
  * Fixed Invoice.Create
  * Fixed Invoice.Search
  * Added Invoice.QrCode
* Updated Credit Card support
  * Fixed CreditCard.Update
  * Added CreditCard.List
* Updated Samples project

## v0.11.0
* Added billing plans and agreements support

## v0.10.0
* Added payment experience support

## v0.9.0
* Added order support

## v0.8.0
* Added future payment support

## v0.7.8
* Fixed NuGet package dependency listing for PayPal Core
 
## v0.7.7
* Added Invoice API support.
* Added constructor for getting Payer ID.

## v0.7.6
* Fixed core reference.

## v0.7.5
* Updated new version of core SDK.

## v0.7.4
* Updated new version of core SDK.
* Added support for multiple target .NET frameworks.

## v0.7.3
* Added support for Reauthorization.
 
## v0.7.2
* Fixed bug for extended types in stubs #7.

## v0.7.1
* Bug fix release for "internal server error" issues in OAuth calls.

## v0.7.0
* Added support for Auth and Capture APIs
* Types Modified to match the API Spec

## v0.6.0
* Added support for dynamic configuration of SDK (Upgraded sdk-core-dotnet dependency to V1.3.0)
* Deprecated the setCredential method and changed resource class methods to take an ApiContext argument instead of an OauthTokenCredential argument

## v0.5.2
* Initial Release

