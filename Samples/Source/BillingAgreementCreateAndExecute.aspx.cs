using System;
using System.Web;
using PayPal.Api;
using PayPal.Sample.Utilities;

namespace PayPal.Sample
{
    public partial class BillingAgreementCreateAndExecute : BaseSamplePage
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

            string token = Request.Params["token"];
            if (string.IsNullOrEmpty(token))
            {
                this.CreateBillingAgreement(apiContext);
            }
            else
            {
                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow = Session["flow-" + Request.Params["guid"]] as RequestFlow;
                this.RegisterSampleRequestFlow();
                this.flow.RecordApproval("Agreement approved successfully.");
                #endregion

                this.ExecuteBillingAgreement(apiContext, token);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateBillingAgreement(APIContext apiContext)
        {
            // Before we can setup the billing agreement, we must first create a
            // billing plan that includes a redirect URL back to this test server.
            var plan = BillingPlanCreate.CreatePlanObject(HttpContext.Current);
            var guid = Convert.ToString((new Random()).Next(100000));
            plan.merchant_preferences.return_url = Request.Url.ToString() + "?guid=" + guid;

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
                start_date = "2016-02-19T00:37:04Z",
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

            // Get the redirect URL to allow the user to be redirected to PayPal to accept the agreement.
            var links = createdAgreement.links.GetEnumerator();

            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    this.flow.RecordRedirectUrl("Redirect to PayPal to approve billing agreement...", link.href);
                }
            }
            Session.Add("flow-" + guid, this.flow);
            Session.Add(guid, createdAgreement.token);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteBillingAgreement(APIContext apiContext, string token)
        {
            var agreement = new Agreement() { token = token };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Execute billing agreement", description: string.Format("URI: v1/payments/billing-agreements/{0}/agreement-execute", agreement.token));
            #endregion
            
            var executedAgreement = agreement.Execute(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(executedAgreement);
            #endregion
        }
    }
}
