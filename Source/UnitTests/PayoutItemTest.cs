using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class PayoutItemTest
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

        [TestMethod, TestCategory("Unit")]
        public void PayoutItemObjectTest()
        {
            var testObject = GetPayoutItem();
            Assert.IsNotNull(testObject);
            Assert.AreEqual(PayoutRecipientType.EMAIL, testObject.recipient_type);
            Assert.AreEqual("shirt-supplier-one@mail.com", testObject.receiver);
            Assert.AreEqual("Thank you.", testObject.note);
            Assert.AreEqual("item_1", testObject.sender_item_id);
            Assert.IsNotNull(testObject.amount);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayoutItemConvertToJsonTest()
        {
            var json = GetPayoutItem().ConvertToJson();
            Assert.IsFalse(json.Length == 0);
            Assert.IsTrue(json.Contains("\"recipient_type\":\"EMAIL\""));
        }

        [TestMethod, TestCategory("Unit")]
        public void PayoutItemToStringTest()
        {
            Assert.IsFalse(GetPayoutItem().ToString().Length == 0);
        }
    }
}