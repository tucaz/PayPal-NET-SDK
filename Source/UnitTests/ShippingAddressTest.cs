using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ShippingAddressTest
    {
        public static ShippingAddress GetShippingAddress()
        {
            var shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

        [TestMethod()]
        public void ShippingAddressObjectTest()
        {
            var shipping = GetShippingAddress();
            Assert.AreEqual(shipping.recipient_name, "PayPalUser");
        }

        [TestMethod()]
        public void ShippingAddressConvertToJsonTest()
        {
            Assert.IsFalse(GetShippingAddress().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ShippingAddressToStringTest()
        {
            Assert.IsFalse(GetShippingAddress().ToString().Length == 0);
        }
    }
}
