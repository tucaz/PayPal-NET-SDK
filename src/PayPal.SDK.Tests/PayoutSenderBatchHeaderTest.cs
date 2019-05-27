using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class PayoutSenderBatchHeaderTest
    {
        public static readonly string PayoutSenderBatchHeaderJson = 
            "{\"sender_batch_id\":\"batch_25\"," +
            "\"email_subject\":\"You have a payment\"}";

        public static PayoutSenderBatchHeader GetPayoutSenderBatchHeader()
        {
            return JsonFormatter.ConvertFromJson<PayoutSenderBatchHeader>(PayoutSenderBatchHeaderJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayoutSenderBatchHeaderObjectTest()
        {
            var testObject = GetPayoutSenderBatchHeader();
            Assert.IsNotNull(testObject);
            Assert.IsTrue(!string.IsNullOrEmpty(testObject.sender_batch_id));
            Assert.AreEqual("You have a payment", testObject.email_subject);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayoutSenderBatchHeaderConvertToJsonTest()
        {
            Assert.IsFalse(GetPayoutSenderBatchHeader().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayoutSenderBatchHeaderToStringTest()
        {
            Assert.IsFalse(GetPayoutSenderBatchHeader().ToString().Length == 0);
        }
    }
}