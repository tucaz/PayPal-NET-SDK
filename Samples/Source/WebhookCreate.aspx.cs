using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class WebhookCreate : BaseSamplePage
    {
        /// <summary>
        /// Helper method for creating a new, unique webhook URL to be used by the webhook sample pages.
        /// </summary>
        /// <returns>A new, unique webhook URL.</returns>
        public static string GetNewWebhookUrl()
        {
            return "https://www.paypal.com/paypal_webhook_samples/" + Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Helper method for creating a new webhook object to be used by the webhook sample pages.
        /// </summary>
        /// <returns>A new Webhook object.</returns>
        public static Webhook GetNewWebhook()
        {
            return new Webhook
            {
                url = GetNewWebhookUrl(),
                event_types = new List<WebhookEventType>
                {
                    new WebhookEventType
                    {
                        name = "PAYMENT.AUTHORIZATION.CREATED"
                    },
                    new WebhookEventType
                    {
                        name = "PAYMENT.AUTHORIZATION.VOIDED"
                    }
                }
            };
        }

        protected override void RunSample()
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

            var webhook = GetNewWebhook();

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Create webhook", webhook);
            //--------------------
            #endregion

            var createdWebhook = webhook.Create(apiContext);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(createdWebhook);
            this.flow.AddNewRequest("Retrieve a webhook", description: "ID: " + createdWebhook.id);
            //--------------------
            #endregion

            var retrievedWebhook = Webhook.Get(apiContext, createdWebhook.id);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(retrievedWebhook);
            //--------------------
            #endregion

            // Cleanup
            retrievedWebhook.Delete(apiContext);
        }
    }
}