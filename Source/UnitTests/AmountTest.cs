using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AmountTest
    {
        public static Amount GetAmount()
        {
            Amount amt = new Amount();
            amt.currency = "USD";
            amt.details = DetailsTest.GetDetails();
            amt.total = "100";
            return amt;
        }

        [TestMethod()]
        public void AmountObjectTest()
        {
            var amount = GetAmount();
            Assert.AreEqual("USD", amount.currency);
            Assert.AreEqual("100", amount.total);
            Assert.IsNotNull(amount.details);
            Assert.AreEqual("75", amount.details.subtotal);
            Assert.AreEqual("15", amount.details.tax);
            Assert.AreEqual("0", amount.details.fee);
            Assert.AreEqual("10", amount.details.shipping);
            Assert.AreEqual("75", amount.details.subtotal);
        }

        [TestMethod()]
        public void AmountConvertToJsonTest()
        {
            Assert.IsFalse(GetAmount().ConvertToJson().Length == 0);
        }
        
        [TestMethod()]
        public void AmountToStringTest()
        {
            Assert.IsFalse(GetAmount().ToString().Length == 0);
        }
    }
}
