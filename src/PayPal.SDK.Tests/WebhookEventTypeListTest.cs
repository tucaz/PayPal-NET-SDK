using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class WebhookEventTypeListTest
    {
        public static readonly string WebhookEventTypeListJson = 
            "{\"event_types\": [" +
            WebhookEventTypeTest.WebhookEventTypeJsonCreated + "," +
            WebhookEventTypeTest.WebhookEventTypeJsonVoided + "]}";

        public static WebhookEventTypeList GetWebhookEventTypeList()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventTypeList>(WebhookEventTypeListJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventTypeListObjectTest()
        {
            var testObject = GetWebhookEventTypeList();
            Assert.IsNotNull(testObject.event_types);
            Assert.IsTrue(testObject.event_types.Count == 2);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventTypeListConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEventTypeList().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventTypeListToStringTest()
        {
            Assert.IsFalse(GetWebhookEventTypeList().ToString().Length == 0);
        }
    }
}
