using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PayPal.Api;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    /// <summary>
    /// Sample for creating PayPal Billing Plans:
    /// https://developer.paypal.com/webapps/developer/docs/integration/direct/create-billing-plan/
    /// </summary>
    public partial class BillingPlanCreate : BaseSamplePage
    {
        protected override void RunSample()
        {
            var plan = CreatePlanObject(HttpContext.Current);

            this.flow.AddNewRequest("Create billing plan", plan);
            this.flow.RecordResponse(plan.Create(this.apiContext));
        }

        /// <summary>
        /// Helper method for getting a currency amount.
        /// </summary>
        /// <param name="value">The value for the currency object.</param>
        /// <returns></returns>
        private static Currency GetCurrency(string value)
        {
            return new Currency() { value = value, currency = "USD" };
        }

        public static Plan CreatePlanObject(HttpContext httpContext)
        {
            // Both the trial and standard plans will use the same shipping
            // charge for this example, so for simplicity we'll create a
            // single object to use with both payment definitions.
            var shippingChargeModel = new ChargeModel()
            {
                type = "SHIPPING",
                amount = GetCurrency("9.99")
            };

            // Define a trial plan that will only charge $9.99 for the first
            // month. After that, the standard plan will take over for the
            // remaining 11 months of the year.
            var trialPlanPaymentDefinition = new PaymentDefinition()
            {
                name = "Trial Plan",
                type = "TRIAL",
                frequency = "MONTH",
                frequency_interval = "1",
                amount = GetCurrency("9.99"),
                cycles = "1"
            };
            trialPlanPaymentDefinition.charge_models = new List<ChargeModel>();
            trialPlanPaymentDefinition.charge_models.Add(new ChargeModel()
            {
                type = "TAX",
                amount = GetCurrency("1.65")
            });
            trialPlanPaymentDefinition.charge_models.Add(shippingChargeModel);

            // Define the standard payment plan. It will represent a monthly
            // plan for $19.99 USD that charges once month for 11 months.
            var regularPlanPaymentDefinition = new PaymentDefinition()
            {
                name = "Standard Plan",
                type = "REGULAR",
                frequency = "MONTH",
                frequency_interval = "1",
                amount = GetCurrency("19.99"),
                cycles = "11"
            };
            regularPlanPaymentDefinition.charge_models = new List<ChargeModel>();
            regularPlanPaymentDefinition.charge_models.Add(new ChargeModel()
            {
                type = "TAX",
                amount = GetCurrency("2.47")
            });
            regularPlanPaymentDefinition.charge_models.Add(shippingChargeModel);

            // Define the merchant preferences.
            // More Information: https://developer.paypal.com/webapps/developer/docs/api/#merchantpreferences-object
            var merchantPreferences = new MerchantPreferences()
            {
                setup_fee = GetCurrency("1"),
                return_url = httpContext.Request.Url.ToString(),
                cancel_url = httpContext.Request.Url.ToString() + "?cancel",
                auto_bill_amount = "YES",
                initial_fail_amount_action = "CONTINUE",
                max_fail_attempts = "0"
            };

            // Define the plan and attach the payment definitions and merchant preferences.
            // More Information: https://developer.paypal.com/webapps/developer/docs/api/#create-a-plan
            var plan = new Plan()
            {
                name = "T-Shirt of the Month Club Plan",
                description = "Monthly plan for getting the t-shirt of the month.",
                type = "fixed",
                merchant_preferences = merchantPreferences
            };
            plan.payment_definitions = new List<PaymentDefinition>();
            plan.payment_definitions.Add(trialPlanPaymentDefinition);
            plan.payment_definitions.Add(regularPlanPaymentDefinition);
            return plan;
        }
    }
}
