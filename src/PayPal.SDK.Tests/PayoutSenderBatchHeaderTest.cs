
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayoutSenderBatchHeaderTest
    {
        public static readonly string PayoutSenderBatchHeaderJson = 
            "{\"sender_batch_id\":\"batch_25\"," +
            "\"email_subject\":\"You have a payment\"}";

        public static PayoutSenderBatchHeader GetPayoutSenderBatchHeader()
        {
            return JsonFormatter.ConvertFromJson<PayoutSenderBatchHeader>(PayoutSenderBatchHeaderJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutSenderBatchHeaderObjectTest()
        {
            var testObject = GetPayoutSenderBatchHeader();
            Assert.NotNull(testObject);
            Assert.True(!string.IsNullOrEmpty(testObject.sender_batch_id));
            Assert.Equal("You have a payment", testObject.email_subject);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutSenderBatchHeaderConvertToJsonTest()
        {
            Assert.False(GetPayoutSenderBatchHeader().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutSenderBatchHeaderToStringTest()
        {
            Assert.False(GetPayoutSenderBatchHeader().ToString().Length == 0);
        }
    }
}