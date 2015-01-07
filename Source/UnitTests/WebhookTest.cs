using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.UnitTest
{
    [TestClass]
    public class WebhookTest
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

        [TestMethod, TestCategory("Unit")]
        public void WebhookObjectTest()
        {
            var testObject = GetWebhook();
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhook().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookToStringTest()
        {
            Assert.IsFalse(GetWebhook().ToString().Length == 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookCreateTest()
        {
            var webhook = WebhookTest.GetWebhook();
            webhook.url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
            var createdWebhook = webhook.Create(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(createdWebhook);
            Assert.IsTrue(!string.IsNullOrEmpty(createdWebhook.id));

            // Cleanup
            createdWebhook.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookGetTest()
        {
            var webhook = WebhookTest.GetWebhook();
            webhook.url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
            var createdWebhook = webhook.Create(UnitTestUtil.GetApiContext());

            var webhookId = createdWebhook.id;
            var retrievedWebhook = Webhook.Get(UnitTestUtil.GetApiContext(), webhookId);
            Assert.IsNotNull(retrievedWebhook);
            Assert.AreEqual(webhookId, retrievedWebhook.id);

            // Cleanup
            createdWebhook.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookGetListTest()
        {
            var webhookList = Webhook.GetAll(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(webhookList);
            Assert.IsNotNull(webhookList.webhooks);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookUpdateTest()
        {
            var webhook = WebhookTest.GetWebhook();
            webhook.url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
            var createdWebhook = webhook.Create(UnitTestUtil.GetApiContext());

            var newUrl = "https://update.com/paypal_webhooks";
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

            var updatedWebhook = createdWebhook.Update(UnitTestUtil.GetApiContext(), patchRequest);
            Assert.IsNotNull(updatedWebhook);
            Assert.AreEqual(createdWebhook.id, updatedWebhook.id);
            Assert.AreEqual(newUrl, updatedWebhook.url);
            Assert.IsNotNull(updatedWebhook.event_types);
            Assert.AreEqual(1, updatedWebhook.event_types.Count);
            Assert.AreEqual(newEventTypeName, updatedWebhook.event_types[0].name);

            // Cleanup
            updatedWebhook.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookDeleteTest()
        {
            var webhook = WebhookTest.GetWebhook();
            webhook.url = "https://" + Guid.NewGuid().ToString() + ".com/paypal_webhooks";
            var createdWebhook = webhook.Create(UnitTestUtil.GetApiContext());
            createdWebhook.Delete(UnitTestUtil.GetApiContext());
            UnitTestUtil.AssertThrownException<HttpException>(() => Webhook.Get(UnitTestUtil.GetApiContext(), createdWebhook.id));
        }
    }
}
