using System;
using PayPal.Api;

namespace PayPal.Sample
{
    /// <summary>
    /// Sample for updating a PayPal Billing Plan
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#update-a-plan
    /// </summary>
    public partial class BillingPlanUpdate : BaseSamplePage
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

            // In order to update the plan, you must define one or more
            // patches to be applied to the plan. The patches will be
            // applied in the order in which they're specified.
            //
            // The 'value' of each Patch object will need to be a Plan object
            // that contains the fields that will be modified.
            // More Information: https://developer.paypal.com/webapps/developer/docs/api/#patchrequest-object
            var tempPlan = new Plan();
            tempPlan.description = "Some updated description (" + Guid.NewGuid().ToString() + ").";

            // NOTE: Only the 'replace' operation is supported when updating
            //       billing plans.
            var patchRequest = new PatchRequest()
            {
                new Patch()
                {
                    op = "replace",
                    path = "/",
                    value = tempPlan
                }
            };

            // Get the plan we want to update.
            var planId = "P-23P27073KJ353233VHEXQM4Y";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Retrieve billing plan details", description: "ID: " + planId);
            //--------------------
            #endregion
            
            var plan = Plan.Get(apiContext, planId);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(plan);
            this.flow.AddNewRequest("Update billing plan", patchRequest);
            //--------------------
            #endregion

            // Update the plan.
            plan.Update(apiContext, patchRequest);

            #region Track Workflow
            //--------------------
            this.flow.RecordActionSuccess("Billing plan updated successfully");
            //--------------------
            #endregion

            // After it's been updated, get it again to make sure it was updated properly (and so we can see what it looks like afterwards).
            var updatedPlan = Plan.Get(apiContext, planId);
        }
    }
}
