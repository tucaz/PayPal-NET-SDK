using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass]
    public class WebhookEventTypeTest
    {
        public static readonly string WebhookEventTypeJsonCreated = "{\"name\":\"PAYMENT.AUTHORIZATION.CREATED\"}";
        public static readonly string WebhookEventTypeJsonVoided = "{\"name\":\"PAYMENT.AUTHORIZATION.VOIDED\"}";

        public static WebhookEventType GetWebhookEventType()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventType>(WebhookEventTypeJsonCreated);
        }

        [TestMethod()]
        public void WebhookEventTypeObjectTest()
        {
            var testObject = GetWebhookEventType();
            Assert.AreEqual("PAYMENT.AUTHORIZATION.CREATED", testObject.name);
            Assert.IsTrue(string.IsNullOrEmpty(testObject.description));
        }

        [TestMethod()]
        public void WebhookEventTypeConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEventType().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void WebhookEventTypeToStringTest()
        {
            Assert.IsFalse(GetWebhookEventType().ToString().Length == 0);
        }

        [Ignore]
        public void WebhookEventTypeSubscribedEventsTest()
        {
            var webhookEventTypeList = WebhookEventType.SubscribedEventTypes(UnitTestUtil.GetApiContext(), "45R80540W07069023");
            Assert.IsNotNull(webhookEventTypeList);
            Assert.IsNotNull(webhookEventTypeList.event_types);
            Assert.AreEqual(2, webhookEventTypeList.event_types.Count);
        }

        [TestMethod]
        public void WebhookEventTypeAvailableEventsTest()
        {
            var webhookEventTypeList = WebhookEventType.AvailableEventTypes(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(webhookEventTypeList);
            Assert.IsNotNull(webhookEventTypeList.event_types);
            Assert.IsTrue(webhookEventTypeList.event_types.Count > 2);
        }
    }
}
