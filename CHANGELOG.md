PayPal .NET SDK release notes
=============================

## v1.8.0
* Enable ConfigManager to tolerate missing web.config or app.config file
* Use PaymentCard instead of CreditCard
* Update Webhooks to API version 1.7
* Update Payment Experience to API version 1.3
* Update Invoicing to API version 1.7
* Update Payouts to API version 1.2
* Update Payments to API version 1.9

## v1.7.4
* Added missing fields for invoice.
* Added missing fields for authorization. 
* Vault API Updates
* Minor bug fixes

## v1.7.3
* Update shipping address summary
* TLSv1.2 changes
* Removed issues list link
* Update License to 2016

## v1.7.2
* Added `security-test-sandbox` as mode for TLSv1.2 verification

## v1.7.1
* Added Subject Name validation to Webhooks Validation logic

## v1.7.0
* Connections to PayPal should use TLSv1.2
* Update Payments API support

## v1.6.0
* Disable logging of request & response in live mode
* Update Newtonsoft.Json dependency
* Minor bug fixes

## v1.5.0
* Add support for validating received webhook event notifications
* Fix issue #102: Add `PayPalLogger.Delimiter` key support in `<appSettings>` config section.
* Improved connection retry logic
* Improved unit and functional test coverage
* Marked certain PayPal-internal fields as obsolete

## v1.4.4
* Fix issue #101: Make `<accounts>` config section optional.  This section is included to maintain compatibility with the Classic SDKs.

## v1.4.3
* Fix issue #94: Null exception thrown when specifying an endpoint in the config without defining the mode
* Fix default state of APIContext so Config and Headers properties are null. Some callers rely on these properties being null by default.
* Minor code improvements related to providing more debug details about HTTP requests and responses
* Remove unused constants from BaseConstants class.
* Improve interface on SDK so internal-specific classes are now correctly marked as internal instead of public.

## v1.4.2
* Fix issue #89: Add `ResetRequestId()` method to `APIContext` class, which can be called to reset the request ID used for ensuring idempotency when making REST API calls.
* Improve XML documentation

## v1.4.1
* Fix Invoicing API support
* Add `JsonFormatter` deserialization error event support
* Improve compatibility with Classic SDKs
* Minor improvements to samples and tests

## v1.4.0
* `BaseLogger` is now public, allowing developers to add custom logger support
* Fix sample for creating and executing an order
* Update Payments API support with new classes and properties:
  * New Classes
    * `FmfDetails`
    * `Measurement`
  * New Properties
    * `Authorization.reason_code`
    * `Authorization.pending_reason`
    * `Authorization.fmf_details`
    * `BaseAddress.status`
    * `Capture.transaction_fee`
    * `CartBase.notify_url`
    * `CartBase.order_url`
    * `Error.purchase_unit_reference_id`
    * `Error.code`
    * `ErrorDetails.purchase_unit_reference_id`
    * `Item.weight`
    * `Item.length`
    * `Item.height`
    * `Item.width`
    * `ItemList.shipping_method`
    * `Order.reason_code`
    * `Order.fmf_details`
    * `Payer.account_type`
    * `Payer.account_age`
    * `PayerInfo.salutation`
    * `PayerInfo.middle_name`
    * `PayerInfo.suffix`
    * `PayerInfo.country_code`
    * `Payment.payee`
    * `Sale.recipient_fund_status`
    * `Sale.hold_reason`
    * `Sale.transaction_fee`
    * `Sale.receivable_amount`
    * `Sale.exchange_rate`
    * `Sale.fmf_details`
    * `Sale.receipt_id`
    * `Transaction.purchase_unit_reference_id`

## v1.3.1
* Add code workaround for `InvalidCastException` Mono bug #643379

## v1.3.0
* Add `PayoutItem.Cancel()` support
* Re-add Identity `Userinfo` support
* Add helper methods to `PayPalResourceObject` base class for HATEOAS links:
  * `GetHateoasLink()`
  * `GetApprovalUrl()`, with optional `setUserActionParameter` parameter for **Pay Now** feature
  * `GetTokenFromApprovalUrl()` (moved from `SDKUtil`)
* `Agreement.ListTransactions()` now requires `startDate` and `endDate`
* Deprecate `time_updated` property for `AgreementTransaction` and replace with `time_stamp`
* Numerous `FundingInstrument` properties marked as currently not supported and hidden from Intellisense view

## v1.2.2
* Add missing class properties for invoicing:
  * `BillingInfo.notification_channel`
  * `BillingInfo.phone`
  * `Invoice.additional_data`
  * `Metadata.payer_view_url`
* Log records missing object fields when deserializing JSON strings

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
