using PayPal.Api;
using PayPal.Sample.Utilities;
using System;
using System.Collections.Generic;
using System.Web;

namespace PayPal.Sample
{
    public partial class BillingAgreementWithCreditCard : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

            // For demonstration purposes, we'll first setup a billing plan in
            // an active state to be used to make an agreement with.
            var plan = BillingPlanCreate.CreatePlanObject(HttpContext.Current);
            var guid = Convert.ToString((new Random()).Next(100000));
            plan.merchant_preferences.return_url = Request.Url.ToString() + "?guid=" + guid;
            plan.merchant_preferences.cancel_url = Request.Url.ToString();

            // > Note: Both `return_url` and `cancel_url` are being set in
            // `plan.merchant_preferences` since many plans may be setup well
            // in advance of anyone setting up an agreement for it.  These URLs
            // are only used for agreements setup with `payer.payment_method`
            // set to `paypal` to establish where the customer should be redirected
            // once they approve or cancel the agreement using their PayPal account.

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Create new billing plan", plan);
            #endregion

            var createdPlan = plan.Create(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdPlan);
            #endregion

            // Activate the plan
            var patchRequest = new PatchRequest()
            {
                new Patch()
                {
                    op = "replace",
                    path = "/",
                    value = new Plan() { state = "ACTIVE" }
                }
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Update the plan", patchRequest);
            #endregion

            createdPlan.Update(apiContext, patchRequest);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordActionSuccess("Plan updated successfully");
            #endregion

            // With the plan created and activated, we can now create the billing agreement.
            // A resource representing a Payer that funds a payment.
            var payer = new Payer
            {
                payment_method = "credit_card",
                funding_instruments = new List<FundingInstrument>
                {
                    new FundingInstrument
                    {
                        credit_card = new CreditCard
                        {
                            billing_address = new Address
                            {
                                city = "Johnstown",
                                country_code = "US",
                                line1 = "52 N Main ST",
                                postal_code = "43210",
                                state = "OH"
                            },
                            cvv2 = "874",
                            expire_month = 11,
                            expire_year = 2018,
                            first_name = "Joe",
                            last_name = "Shopper",
                            number = "4877274905927862",
                            type = "visa"
                        }
                    }
                }
            };

            var shippingAddress = new ShippingAddress()
            {
                line1 = "111 First Street",
                city = "Saratoga",
                state = "CA",
                postal_code = "95070",
                country_code = "US"
            };

            var agreement = new Agreement()
            {
                name = "T-Shirt of the Month Club",
                description = "Agreement for T-Shirt of the Month Club",
                start_date = "2015-02-19T00:37:04Z",
                payer = payer,
                plan = new Plan() { id = createdPlan.id },
                shipping_address = shippingAddress
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Create billing agreement", agreement);
            #endregion

            // Create the billing agreement.
            var createdAgreement = agreement.Create(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdAgreement);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}