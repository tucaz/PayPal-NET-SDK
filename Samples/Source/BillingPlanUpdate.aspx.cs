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
using Newtonsoft.Json.Linq;
using PayPal.Api;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    /// <summary>
    /// Sample for updating a PayPal Billing Plan
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#update-a-plan
    /// </summary>
    public partial class BillingPlanUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                var patch = new Patch()
                {
                    op = "replace",
                    path = "/",
                    value = tempPlan
                };
                var patchRequest = new PatchRequest();
                patchRequest.Add(patch);

                HttpContext.Current.Items.Add("RequestJson", Common.FormatJsonString(patchRequest.ConvertToJson()));

                // Get the plan we want to update.
                var apiContext = Configuration.GetAPIContext();
                var planId = "P-23P27073KJ353233VHEXQM4Y";
                var plan = Plan.Get(apiContext, planId);

                // Update the plan.
                plan.Update(apiContext, patchRequest);

                // After it's been updated, get it again to make sure it was updated properly (and so we can see what it looks like afterwards).
                var updatedPlan = Plan.Get(apiContext, planId);

                HttpContext.Current.Items.Add("ResponseTitle", "Updated Billing Plan Details");
                HttpContext.Current.Items.Add("ResponseJson", Common.FormatJsonString(updatedPlan.ConvertToJson()));
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
