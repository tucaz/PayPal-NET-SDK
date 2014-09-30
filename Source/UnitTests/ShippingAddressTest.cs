using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ShippingAddressTest
    {
        [TestMethod()]
        public void TestShippingAddress()
        {
            var shipping = UnitTestUtil.GetShippingAddress();
            Assert.AreEqual(shipping.recipient_name, "PayPalUser");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var shipping = UnitTestUtil.GetShippingAddress();
            Assert.IsFalse(shipping.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var shipping = UnitTestUtil.GetShippingAddress();
            Assert.IsFalse(shipping.ToString().Length == 0);
        }
    }
}
