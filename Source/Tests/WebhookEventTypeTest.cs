using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class WebhookEventTypeTest : BaseTest
    {
        public static readonly string WebhookEventTypeJsonCreated = "{\"name\":\"PAYMENT.AUTHORIZATION.CREATED\"}";
        public static readonly string WebhookEventTypeJsonVoided = "{\"name\":\"PAYMENT.AUTHORIZATION.VOIDED\"}";

        public static WebhookEventType GetWebhookEventType()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventType>(WebhookEventTypeJsonCreated);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventTypeObjectTest()
        {
            var testObject = GetWebhookEventType();
            Assert.AreEqual("PAYMENT.AUTHORIZATION.CREATED", testObject.name);
            Assert.IsTrue(string.IsNullOrEmpty(testObject.description));
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventTypeConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEventType().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventTypeToStringTest()
        {
            Assert.IsFalse(GetWebhookEventType().ToString().Length == 0);
        }

        [Ignore]
        public void WebhookEventTypeSubscribedEventsTest()
        {
            var webhookEventTypeList = WebhookEventType.SubscribedEventTypes(TestingUtil.GetApiContext(), "45R80540W07069023");
            Assert.IsNotNull(webhookEventTypeList);
            Assert.IsNotNull(webhookEventTypeList.event_types);
            Assert.AreEqual(2, webhookEventTypeList.event_types.Count);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookEventTypeAvailableEventsTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhookEventTypeList = WebhookEventType.AvailableEventTypes(apiContext);
                this.RecordConnectionDetails();

                Assert.IsNotNull(webhookEventTypeList);
                Assert.IsNotNull(webhookEventTypeList.event_types);
                Assert.IsTrue(webhookEventTypeList.event_types.Count > 2);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
