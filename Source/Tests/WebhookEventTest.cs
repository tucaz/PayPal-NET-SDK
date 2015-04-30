using System;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
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
		        "\"href\":\"https://api.sandbox.paypal.com/v1/notfications/webhooks-events/8PT597110X687430LKGECATA\"," +
		        "\"rel\":\"self\"," +
		        "\"method\":\"GET\"" +
	        "},{" +
		        "\"href\":\"https://api.sandbox.paypal.com/v1/notfications/webhooks-events/8PT597110X687430LKGECATA/resend\"," +
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
            var webhookEvent = WebhookEvent.Get(TestingUtil.GetApiContext(), webhookEventId);
            Assert.IsNotNull(webhookEvent);
            Assert.AreEqual(webhookEventId, webhookEvent.id);
        }

        [Ignore]
        public void WebhookEventGetAllTest()
        {
            var webhookEventList = WebhookEvent.List(TestingUtil.GetApiContext());
            Assert.IsNotNull(webhookEventList);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebhookEventValidateReceivedEventTest()
        {
            var requestBody = "{\"id\":\"WH-83M739899B401212M-7DU699748W928720N\",\"create_time\":\"2015-01-20T21:36:29Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 100.0 USD\",\"resource\":{\"id\":\"2BK99536JB384163F\",\"create_time\":\"2015-01-20T21:35:18Z\",\"update_time\":\"2015-01-20T21:35:37Z\",\"amount\":{\"total\":\"100.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-29E10708MU8063339KS7MUFQ\",\"links\":[{\"href\":\"https://10.72.108.213:11881/v1/payments/sale/2BK99536JB384163F\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://10.72.108.213:11881/v1/payments/sale/2BK99536JB384163F/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://10.72.108.213:11881/v1/payments/payment/PAY-29E10708MU8063339KS7MUFQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-83M739899B401212M-7DU699748W928720N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-83M739899B401212M-7DU699748W928720N/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-35c2ed1e-21e9a5d6"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "UsYAipVbZNtuSGq59AqYhxA/k5esWWE8RGsaYHUQpURsrnyfpPou7AaozlMRXbP2Ry+REChStJLdjCeYHQa2PZAAr3ikzPFCT5kSNd1hL52fIXW60l3k5fJIMo4qSpvXmraEhn3zXAPIaw11RzzUxrDe4wDql4yhot109H+ZtFNUSjOt/KzzZugpAwwIfwOgtnbjpLhfRJaMykozeMVelBPQ8GaYUpK37QI3BFYGs0joEEXeiRWZLAbIbyxBe1xYF8oVCYmhP47fkwhkHjy1J0hK8mhFPxOe1/6WKbljiJ9jbHzkdOWeInBhbq8LbaCX1Q+fHPkKOdo/bimMM5Pw4Q=="},
                {"Paypal-Transmission-Id", "657044e0-a0ec-11e4-a003-6b62a8a99ac4"},
                {"Via", "1.1 vegur"},
                {"Total-Route-Time", "0"},
                {"User-Agent", "PayPal/AUHD-119.0-14832179"},
                {"Content-Type", "application/json"},
                {"Connect-Time", "1"},
                {"Host", "requestb.in"},
                {"Connection", "close"},
                {"Content-Length", "1229"},
                {"Accept", "*/*"},
                {"X-Request-Id", "927e10aa-6486-461f-ac94-e4afa099e2b5"},
                {"Paypal-Auth-Algo", "SHA1withRSA"},
                {"Correlation-Id", "a31e7d8667bd5"},
                {"Paypal-Transmission-Time", "2015-01-20T21:36:30Z"}
            };
            var webhookId = "6XE614444P001923J";
            Assert.IsTrue(WebhookEvent.ValidateReceivedEvent(requestHeaders, requestBody, webhookId));
        }
    }
}
