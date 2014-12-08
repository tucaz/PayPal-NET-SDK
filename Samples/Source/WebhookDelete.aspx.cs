using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class WebhookDelete : BaseSamplePage
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

            bool deleteAll = Convert.ToBoolean(Request.Params["deleteAll"]);
            if (deleteAll)
            {
                var webhookList = Webhook.GetAll(apiContext);
                foreach (var webhook in webhookList.webhooks)
                {
                    webhook.Delete(apiContext);
                }
            }
            else
            {
                var webhook = WebhookCreate.GetNewWebhook();

                #region Track Workflow
                //--------------------
                this.flow.AddNewRequest("Create a webhook", webhook);
                //--------------------
                #endregion

                var createdWebhook = webhook.Create(apiContext);

                #region Track Workflow
                //--------------------
                this.flow.RecordResponse(createdWebhook);
                this.flow.AddNewRequest("Delete the webhook", description: "ID: " + webhook.id);
                //--------------------
                #endregion

                createdWebhook.Delete(apiContext);

                #region Track Workflow
                //--------------------
                this.flow.RecordActionSuccess("Webhook successfully deleted.");
                //--------------------
                #endregion
            }
        }
    }
}