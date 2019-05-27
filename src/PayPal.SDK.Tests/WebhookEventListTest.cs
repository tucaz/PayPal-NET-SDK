using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class WebhookEventListTest
    {
        public static readonly string WebhookEventListJson = 
            "{\"events\":[" + WebhookEventTest.WebhookEventJson + "]," +
            "\"count\": 2," + 
            "\"links\": [" +
            "{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/?start_time=2014-08-04T12:46:47-07:00&amp;amp;end_time=2014-09-18T12:46:47-07:00&amp;amp;page_size=2&amp;amp;move_to=next&amp;amp;index_time=2014-09-17T23:07:35Z&amp;amp;index_id=3\"," +
                "\"rel\":\"next\"," +
                "\"method\":\"GET\"" +
            "},{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/?start_time=2014-08-04T12:46:47-07:00&amp;amp;end_time=2014-09-18T12:46:47-07:00&amp;amp;page_size=2&amp;amp;move_to=previous&amp;amp;index_time=2014-09-17T23:07:35Z&amp;amp;index_id=0\"," +
                "\"rel\":\"previous\"," +
                "\"method\":\"GET\"}]}";

        public static WebhookEventList GetWebhookEventList()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventList>(WebhookEventListJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventListObjectTest()
        {
            var testObject = GetWebhookEventList();
            Assert.IsNotNull(testObject.events);
            Assert.AreEqual(2, testObject.count);
            Assert.IsNotNull(testObject.links);
            Assert.IsTrue(testObject.links.Count == 2);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventListConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEventList().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventListToStringTest()
        {
            Assert.IsFalse(GetWebhookEventList().ToString().Length == 0);
        }
    }
}
