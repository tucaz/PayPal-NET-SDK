using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class PayoutTest
    {
        public static readonly string PayoutJson = 
            "{\"sender_batch_header\":" + PayoutSenderBatchHeaderTest.PayoutSenderBatchHeaderJson + "," +
            "\"items\":[" + PayoutItemTest.PayoutItemJson + "]}";

        public static Payout GetPayout()
        {
            return JsonFormatter.ConvertFromJson<Payout>(PayoutJson);
        }

        [TestMethod()]
        public void PayoutObjectTest()
        {
            var testObject = GetPayout();
            Assert.IsNotNull(testObject);
            Assert.IsNotNull(testObject.sender_batch_header);
            Assert.IsNotNull(testObject.items);
            Assert.IsTrue(testObject.items.Count == 1);
        }

        [TestMethod()]
        public void PayoutConvertToJsonTest()
        {
            Assert.IsFalse(GetPayout().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PayoutToStringTest()
        {
            Assert.IsFalse(GetPayout().ToString().Length == 0);
        }

        [TestMethod()]
        public void PayoutCreateTest()
        {
            var payout = PayoutTest.GetPayout();
            var payoutSenderBatchId = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8);
            payout.sender_batch_header.sender_batch_id = payoutSenderBatchId;
            var createdPayout = payout.Create(UnitTestUtil.GetApiContext(), false);
            Assert.IsNotNull(createdPayout);
            Assert.IsTrue(!string.IsNullOrEmpty(createdPayout.batch_header.payout_batch_id));
            Assert.AreEqual(payoutSenderBatchId, createdPayout.batch_header.sender_batch_header.sender_batch_id);
        }

        [TestMethod()]
        public void PayoutGetTest()
        {
            var payoutBatchId = "8NX77PFLN255E";
            var payout = Payout.Get(UnitTestUtil.GetApiContext(), payoutBatchId);
            Assert.IsNotNull(payout);
            Assert.AreEqual(payoutBatchId, payout.batch_header.payout_batch_id);
        }
    }
}
