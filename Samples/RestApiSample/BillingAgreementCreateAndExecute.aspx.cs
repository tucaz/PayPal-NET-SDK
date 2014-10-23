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
using PayPal;
using PayPal.Api.Payments;

namespace RestApiSample
{
    public partial class BillingAgreementCreateAndExecute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;

            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext..
            APIContext apiContext = Configuration.GetAPIContext();

            try
            {
                string token = Request.Params["token"];
                if (string.IsNullOrEmpty(token))
                {
                    this.CreateBillingAgreement();
                }
                else
                {
                    this.ExecuteBillingAgreement(token);
                }
            }
            catch (Exception ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateBillingAgreement()
        {
            var apiContext = Configuration.GetAPIContext();

            // Before we can setup the billing agreement, we must first create a
            // billing plan that includes a redirect URL back to this test server.
            var plan = BillingPlanCreate.CreatePlanObject(HttpContext.Current);
            var guid = Convert.ToString((new Random()).Next(100000));
            plan.merchant_preferences.return_url = Request.Url.ToString() + "?guid=" + guid;
            var createdPlan = plan.Create(apiContext);

            // Activate the plan
            var patch = new Patch()
            {
                op = "replace",
                path = "/",
                value = new Plan() { state = "ACTIVE" }
            };
            var patchRequest = new PatchRequest();
            patchRequest.Add(patch);
            createdPlan.Update(apiContext, patchRequest);

            // With the plan created and activated, we can now create the
            // billing agreement.
            var payer = new Payer() { payment_method = "paypal" };
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

            HttpContext.Current.Items.Add("RequestJson", Common.FormatJsonString(agreement.ConvertToJson()));

            // Create the billing agreement.
            var createdAgreement = agreement.Create(apiContext);

            HttpContext.Current.Items.Add("ResponseJson", Common.FormatJsonString(createdAgreement.ConvertToJson()));

            // Get the redirect URL to allow the user to be redirected to PayPal to accept the agreement.
            var links = createdAgreement.links.GetEnumerator();

            while (links.MoveNext())
            {
                Links lnk = links.Current;
                if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                {
                    HttpContext.Current.Items.Add("RedirectURLText", "Redirect to PayPal to approve billing agreement...");
                    HttpContext.Current.Items.Add("RedirectURL", lnk.href);
                }
            }
            Session.Add(guid, createdAgreement.token);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteBillingAgreement(string token)
        {
            // Executing a payment
            var apiContext = Configuration.GetAPIContext();
            var agreement = new Agreement() { token = token };
            var executedAgreement = agreement.Execute(apiContext);
            HttpContext.Current.Items.Add("ResponseJson", Common.FormatJsonString(executedAgreement.ConvertToJson()));
        }
    }
}
