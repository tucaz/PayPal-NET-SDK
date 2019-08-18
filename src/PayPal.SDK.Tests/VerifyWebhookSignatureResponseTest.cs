using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class VerifyWebhookSignatureResponseTest
    {
        public static readonly string VerifyWebhookSignatureResponseJson =
            "{\"verification_status\":\"TestSample\"}";


        public static VerifyWebhookSignatureResponse GetVerifyWebhookResponseSignature()
        {
            return JsonFormatter.ConvertFromJson<VerifyWebhookSignatureResponse>(VerifyWebhookSignatureResponseJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void VerifyWebhookSignatureObjectTest()
        {
            var testObject = GetVerifyWebhookResponseSignature();
            Assert.Equal("TestSample", testObject.verification_status);
        }
    }
}
