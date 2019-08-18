using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class VerifyWebhookSignatureTest
    {
        public static readonly string VerifyWebhookSignatureJson =
            "{\"auth_algo\":\"TestSample\"," +
            "\"cert_url\":\"http://www.google.com\"," +
            "\"transmission_id\":\"TestSample\"," +
            "\"transmission_sig\":\"TestSample\"," +
            "\"transmission_time\":\"TestSample\"," +
            "\"webhook_id\":\"TestSample\"," +
            "\"webhook_event\":" + WebhookEventTest.WebhookEventJson + "}";


        public static VerifyWebhookSignature GetVerifyWebhookSignature()
        {
            return JsonFormatter.ConvertFromJson<VerifyWebhookSignature>(VerifyWebhookSignatureJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void VerifyWebhookSignatureObjectTest()
        {
            var testObject = GetVerifyWebhookSignature();
            Assert.Equal("TestSample", testObject.auth_algo);
            Assert.Equal("http://www.google.com", testObject.cert_url);
            Assert.Equal("TestSample", testObject.transmission_id);
            Assert.Equal("TestSample", testObject.transmission_sig);
            Assert.Equal("TestSample", testObject.transmission_time);
            Assert.Equal("TestSample", testObject.webhook_id);
            Assert.Equal(WebhookEventTest.WebhookEventJson, JsonFormatter.ConvertToJson(testObject.webhook_event));
        }
    }
}
