using System;
using PayPal.Api;
using System.Collections.Generic;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebhookTest : BaseTest
    {
        public static readonly string WebhookJson =
            "{\"url\":\"https://www.paypal.com/paypal_webhook\"," +
            "\"event_types\":[" +
            WebhookEventTypeTest.WebhookEventTypeJsonCreated + "," +
            WebhookEventTypeTest.WebhookEventTypeJsonVoided + "]}";

        public static Webhook GetWebhook()
        {
            return JsonFormatter.ConvertFromJson<Webhook>(WebhookJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookObjectTest()
        {
            var testObject = GetWebhook();
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookConvertToJsonTest()
        {
            Assert.False(GetWebhook().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookToStringTest()
        {
            Assert.False(GetWebhook().ToString().Length == 0);
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookCreateAndGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhook = WebhookTest.GetWebhook();
                var url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
                webhook.url = url;
                var createdWebhook = webhook.Create(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(createdWebhook);
                Assert.True(!string.IsNullOrEmpty(createdWebhook.id));

                var webhookId = createdWebhook.id;
                var retrievedWebhook = Webhook.Get(apiContext, webhookId);
                this.RecordConnectionDetails();

                Assert.NotNull(retrievedWebhook);
                Assert.Equal(webhookId, retrievedWebhook.id);
                Assert.Equal(url, retrievedWebhook.url);

                // Cleanup
                retrievedWebhook.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookGetListTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhookList = Webhook.GetAll(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(webhookList);
                Assert.NotNull(webhookList.webhooks);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhook = WebhookTest.GetWebhook();
                webhook.url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
                var createdWebhook = webhook.Create(apiContext);
                this.RecordConnectionDetails();

                var newUrl = "https://update.com/paypal_webhooks/" + Guid.NewGuid().ToString();
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

                var updatedWebhook = createdWebhook.Update(apiContext, patchRequest);
                this.RecordConnectionDetails();

                Assert.NotNull(updatedWebhook);
                Assert.Equal(createdWebhook.id, updatedWebhook.id);
                Assert.Equal(newUrl, updatedWebhook.url);
                Assert.NotNull(updatedWebhook.event_types);
                Assert.Equal(1, updatedWebhook.event_types.Count);
                Assert.Equal(newEventTypeName, updatedWebhook.event_types[0].name);

                // Cleanup
                updatedWebhook.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookDeleteTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhook = WebhookTest.GetWebhook();
                webhook.url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
                var createdWebhook = webhook.Create(apiContext);
                this.RecordConnectionDetails();

                createdWebhook.Delete(apiContext);
                this.RecordConnectionDetails();

                Assert.Equal(204, (int)PayPalResource.LastResponseDetails.Value.StatusCode);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
