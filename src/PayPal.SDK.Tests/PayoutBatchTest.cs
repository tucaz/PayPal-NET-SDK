
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayoutBatchTest
    {
        public static readonly string PayoutBatchJson = 
            "{\"batch_header\":" + PayoutBatchHeaderTest.PayoutBatchHeaderJson + "," +
            "\"links\":[{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/payments/payouts/H4HF4AT2GZXQN\"," +
                "\"rel\":\"self\"," +
                "\"method\":\"GET\"}]}";

        public static PayoutBatch GetPayoutBatch()
        {
            return JsonFormatter.ConvertFromJson<PayoutBatch>(PayoutBatchJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutBatchObjectTest()
        {
            var testObject = GetPayoutBatch();
            Assert.NotNull(testObject);
            Assert.NotNull(testObject.batch_header);
            Assert.NotNull(testObject.links);
            Assert.True(testObject.links.Count == 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutBatchConvertToJsonTest()
        {
            Assert.False(GetPayoutBatch().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutBatchToStringTest()
        {
            Assert.False(GetPayoutBatch().ToString().Length == 0);
        }
    }
}