using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class WebhookListTest
    {
        public static readonly string WebhookListJson = "{\"webhooks\":[" + WebhookTest.WebhookJson + "]}";

        public static WebhookList GetWebhookList()
        {
            return JsonFormatter.ConvertFromJson<WebhookList>(WebhookListJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookListObjectTest()
        {
            var testObject = GetWebhookList();
            Assert.IsNotNull(testObject.webhooks);
            Assert.IsTrue(testObject.webhooks.Count == 1);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookListConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookList().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookListToStringTest()
        {
            Assert.IsFalse(GetWebhookList().ToString().Length == 0);
        }
    }
}
