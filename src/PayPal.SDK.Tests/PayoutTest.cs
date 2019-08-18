
using PayPal.Api;
using System.Collections.Generic;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayoutTest : BaseTest
    {
        public static readonly string PayoutJson = 
            "{\"sender_batch_header\":" + PayoutSenderBatchHeaderTest.PayoutSenderBatchHeaderJson + "," +
            "\"items\":[" + PayoutItemTest.PayoutItemJson + "]}";

        public static Payout GetPayout()
        {
            return JsonFormatter.ConvertFromJson<Payout>(PayoutJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutObjectTest()
        {
            var testObject = GetPayout();
            Assert.NotNull(testObject);
            Assert.NotNull(testObject.sender_batch_header);
            Assert.NotNull(testObject.items);
            Assert.True(testObject.items.Count == 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutConvertToJsonTest()
        {
            Assert.False(GetPayout().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutToStringTest()
        {
            Assert.False(GetPayout().ToString().Length == 0);
        }

        [Fact, Trait("Category", "Functional")]
        public void PayoutCreateAndGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var payout = PayoutTest.GetPayout();
                var payoutSenderBatchId = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8);
                payout.sender_batch_header.sender_batch_id = payoutSenderBatchId;
                var createdPayout = payout.Create(apiContext, false);
                this.RecordConnectionDetails();

                Assert.NotNull(createdPayout);
                Assert.True(!string.IsNullOrEmpty(createdPayout.batch_header.payout_batch_id));
                Assert.Equal(payoutSenderBatchId, createdPayout.batch_header.sender_batch_header.sender_batch_id);

                var payoutBatchId = createdPayout.batch_header.payout_batch_id;
                var retrievedPayout = Payout.Get(apiContext, payoutBatchId);
                this.RecordConnectionDetails();

                Assert.NotNull(payout);
                Assert.Equal(payoutBatchId, retrievedPayout.batch_header.payout_batch_id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { TestingUtil.GetApiContext() }
            };

        [Theory(Skip = "Ignore")]
        [MemberData(nameof(Data), null)]
        public static PayoutBatch CreateSingleSynchronousPayoutBatch(APIContext apiContext)
        {
            return Payout.Create(apiContext, new Payout
            {
                sender_batch_header = new PayoutSenderBatchHeader
                {
                    sender_batch_id = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8),
                    email_subject = "You have a Payout!"
                },
                items = new List<PayoutItem>
                {
                    new PayoutItem
                    {
                        recipient_type = PayoutRecipientType.EMAIL,
                        amount = new Currency
                        {
                            value = "1.0",
                            currency = "USD"
                        },
                        note = "Thanks for the payment!",
                        sender_item_id = "2014031400023",
                        receiver = "shirt-supplier-one@gmail.com"
                    }
                }
            },
            true);
        }
    }
}
