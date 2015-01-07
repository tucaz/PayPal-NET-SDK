using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass]
    public class WebhookEventTest
    {
        public static readonly string WebhookEventJson = 
            "{\"id\":\"8PT597110X687430LKGECATA\"," +
	        "\"create_time\":\"2013-06-25T21:41:28Z\"," +
	        "\"resource_type\":\"authorization\"," +
            "\"event_type\":\"PAYMENT.AUTHORIZATION.CREATED\"," +
	        "\"summary\":\"A payment authorization was created\"," +
	        "\"resource\":" + AuthorizationTest.AuthorizationJson + "," +
	        "\"links\":[{" +
		        "\"href\":\"https://api.paypal.com/v1/notfications/webhooks-events/8PT597110X687430LKGECATA\"," +
		        "\"rel\":\"self\"," +
		        "\"method\":\"GET\"" +
	        "},{" +
		        "\"href\":\"https://api.paypal.com/v1/notfications/webhooks-events/8PT597110X687430LKGECATA/resend\"," +
		        "\"rel\":\"resend\"," +
		        "\"method\":\"POST\"}]}";

        public static WebhookEvent GetWebhookEvent()
        {
            return JsonFormatter.ConvertFromJson<WebhookEvent>(WebhookEventJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventObjectTest()
        {
            var testObject = GetWebhookEvent();
            Assert.AreEqual("8PT597110X687430LKGECATA", testObject.id);
            Assert.AreEqual("2013-06-25T21:41:28Z", testObject.create_time);
            Assert.AreEqual("authorization", testObject.resource_type);
            Assert.AreEqual("PAYMENT.AUTHORIZATION.CREATED", testObject.event_type);
            Assert.AreEqual("A payment authorization was created", testObject.summary);
            Assert.IsNotNull(testObject.resource);
            Assert.IsNotNull(testObject.links);
            Assert.IsTrue(testObject.links.Count == 2);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEvent().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebhookEventToStringTest()
        {
            Assert.IsFalse(GetWebhookEvent().ToString().Length == 0);
        }

        [Ignore]
        public void WebhookEventGetTest()
        {
            var webhookEventId = "8PT597110X687430LKGECATA";
            var webhookEvent = WebhookEvent.Get(UnitTestUtil.GetApiContext(), webhookEventId);
            Assert.IsNotNull(webhookEvent);
            Assert.AreEqual(webhookEventId, webhookEvent.id);
        }

        [Ignore]
        public void WebhookEventGetAllTest()
        {
            var webhookEventList = WebhookEvent.List(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(webhookEventList);
        }
    }
}
