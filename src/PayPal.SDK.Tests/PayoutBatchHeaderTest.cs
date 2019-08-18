
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayoutBatchHeaderTest
    {
        public static readonly string PayoutBatchHeaderJson = 
            "{\"payout_batch_id\":\"H4HF4AT2GZXQN\"," +
            "\"batch_status\":\"PENDING\"," +
            "\"sender_batch_header\":" + PayoutSenderBatchHeaderTest.PayoutSenderBatchHeaderJson + "}";

        public static PayoutBatchHeader GetPayoutBatchHeader()
        {
            return JsonFormatter.ConvertFromJson<PayoutBatchHeader>(PayoutBatchHeaderJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutBatchHeaderObjectTest()
        {
            var testObject = GetPayoutBatchHeader();
            Assert.NotNull(testObject);
            Assert.Equal("H4HF4AT2GZXQN", testObject.payout_batch_id);
            Assert.Equal("PENDING", testObject.batch_status);
            Assert.NotNull(testObject.sender_batch_header);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutBatchHeaderConvertToJsonTest()
        {
            Assert.False(GetPayoutBatchHeader().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutBatchHeaderToStringTest()
        {
            Assert.False(GetPayoutBatchHeader().ToString().Length == 0);
        }
    }
}