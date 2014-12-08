using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class WebhookUpdate : BaseSamplePage
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
            //--------------------
            #endregion

            var newUrl = WebhookCreate.GetNewWebhookUrl();
            var newEventTypeName = "PAYMENT.SALE.REFUNDED";

            var patchRequest = new PatchRequest
            {
                new Patch
                {
                    op = "replace",
                    path = "/url",
                    value = newUrl
                },
                new Patch
                {
                    op = "replace",
                    path = "/event_types",
                    value = new List<WebhookEventType>
                    {
                        new WebhookEventType
                        {
                            name = newEventTypeName
                        }
                    }
                }
            };

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Update the webhook", description: "ID: " + webhook.id);
            //--------------------
            #endregion

            var updatedWebhook = createdWebhook.Update(apiContext, patchRequest);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(updatedWebhook);
            //--------------------
            #endregion

            // Cleanup
            updatedWebhook.Delete(apiContext);
        }
    }
}