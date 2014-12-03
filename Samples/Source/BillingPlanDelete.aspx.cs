using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayPal.Sample
{
    public partial class BillingPlanDelete : BaseSamplePage
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

            // ### Create a Billing Plan
            // For demonstration purposes, we'll first create a new billing plan.
            var plan = new Plan
            {
                name = "T-Shirt of the Month Club Plan",
                description = "Monthly plan for getting the t-shirt of the month.",
                type = "fixed",
                merchant_preferences = new MerchantPreferences
                {
                    setup_fee = new Currency { value = "1.00", currency = "USD" },
                    return_url = "https://www.paypal.com",
                    cancel_url = "https://www.paypal.com",
                    auto_bill_amount = "YES",
                    initial_fail_amount_action = "CONTINUE",
                    max_fail_attempts = "0"
                },
                payment_definitions = new List<PaymentDefinition>
                {
                    new PaymentDefinition()
                    {
                        name = "Standard Plan",
                        type = "REGULAR",
                        frequency = "MONTH",
                        frequency_interval = "1",
                        amount = new Currency() { value = "19.99", currency = "USD" },
                        cycles = "11",
                        charge_models = new List<ChargeModel>
                        {
                            new ChargeModel
                            {
                                type = "TAX",
                                amount = new Currency() { value = "2.47", currency = "USD" }
                            },
                            new ChargeModel()
                            {
                                type = "SHIPPING",
                                amount = new Currency() { value = "9.99", currency = "USD" }
                            }
                        }
                    }
                }
            };

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Create the billing plan", plan);
            //--------------------
            #endregion

            // Create the billing plan.
            var createdPlan = plan.Create(apiContext);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(createdPlan);
            //--------------------
            #endregion

            // ### Delete the Billing Plan
            // Deleting the plan is done by applying an update to the plan with its `state` set to `DELETED`.
            // > NOTE: Only the 'replace' operation is supported when updating billing plans.
            // For demonstration purposes, we'll create the `patchRequest` object here to show you how the plan is being deleted.
            var patchRequest = new PatchRequest
            {
                new Patch
                {
                    op = "replace",
                    path = "/",
                    value = new Plan { state = "DELETED" }
                }
            };

            #region Track Workflow
            this.flow.AddNewRequest("Delete the billing plan", patchRequest);
            #endregion

            // To make it easier for developers, this functionality has been built into the `Plan.Delete()` method.
            createdPlan.Delete(apiContext);

            #region Track Workflow
            this.flow.RecordActionSuccess("Billing plan deleted successfully");
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}