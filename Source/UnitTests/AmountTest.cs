using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AmountTest
    {
        [TestMethod()]
        public void TestAmount()
        {
            var amt = UnitTestUtil.GetAmount();
            Assert.AreEqual("USD", amt.currency);
            Assert.AreEqual("100", amt.total);
            Assert.AreEqual("75", amt.details.subtotal);
            Assert.AreEqual("15", amt.details.tax);
            Assert.AreEqual("2", amt.details.fee);
            Assert.AreEqual("10", amt.details.shipping);
            Assert.AreEqual("75", amt.details.subtotal);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var amt = UnitTestUtil.GetAmount();
            Assert.IsFalse(amt.ConvertToJson().Length == 0);
        }
        
        [TestMethod()]
        public void ToStringTest()
        {
            var amt = UnitTestUtil.GetAmount();
            Assert.IsFalse(amt.ToString().Length == 0);
        }
    }
}
