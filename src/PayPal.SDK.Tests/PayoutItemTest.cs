
using PayPal.Api;
using System.Collections.Generic;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayoutItemTest : BaseTest
    {
        public static readonly string PayoutItemJson = 
            "{\"recipient_type\":\"EMAIL\"," +
            "\"amount\":" + CurrencyTest.CurrencyJson + "," +
            "\"receiver\":\"shirt-supplier-one@mail.com\"," +
            "\"note\":\"Thank you.\"," +
            "\"sender_item_id\":\"item_1\"}";

        public static PayoutItem GetPayoutItem()
        {
            return JsonFormatter.ConvertFromJson<PayoutItem>(PayoutItemJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutItemObjectTest()
        {
            var testObject = GetPayoutItem();
            Assert.NotNull(testObject);
            Assert.Equal(PayoutRecipientType.EMAIL, testObject.recipient_type);
            Assert.Equal("shirt-supplier-one@mail.com", testObject.receiver);
            Assert.Equal("Thank you.", testObject.note);
            Assert.Equal("item_1", testObject.sender_item_id);
            Assert.NotNull(testObject.amount);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutItemConvertToJsonTest()
        {
            var json = GetPayoutItem().ConvertToJson();
            Assert.False(json.Length == 0);
            Assert.True(json.Contains("\"recipient_type\":\"EMAIL\""));
        }

        [Fact, Trait("Category", "Unit")]
        public void PayoutItemToStringTest()
        {
            Assert.False(GetPayoutItem().ToString().Length == 0);
        }

        [Fact(Skip="Ignore")]
        public void PayoutItemGetTest()
        {
            try
            {
                var payoutItemId = "G2CFT8SJRB7RN";
                var payoutItemDetails = PayoutItem.Get(TestingUtil.GetApiContext(), payoutItemId);
                this.RecordConnectionDetails();
                Assert.NotNull(payoutItemDetails);
                Assert.Equal(payoutItemId, payoutItemDetails.payout_item_id);
                Assert.Equal("8NX77PFLN255E", payoutItemDetails.payout_batch_id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void PayoutItemDetailsCancelTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a single synchronous payout with an invalid email address.
                // This will cause the status to be marked as 'UNCLAIMED', allowing
                // us to cancel the payout.
                var payoutBatch = PayoutTest.CreateSingleSynchronousPayoutBatch(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(payoutBatch);
                Assert.NotNull(payoutBatch.items);
                Assert.True(payoutBatch.items.Count > 0);

                var payoutItem = payoutBatch.items[0];

                if (payoutItem.transaction_status == PayoutTransactionStatus.UNCLAIMED)
                {
                    var payoutItemDetails = PayoutItem.Cancel(apiContext, payoutItem.payout_item_id);
                    this.RecordConnectionDetails();

                    Assert.NotNull(payoutItemDetails);
                    Assert.Equal(PayoutTransactionStatus.RETURNED, payoutItemDetails.transaction_status);
                }
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}