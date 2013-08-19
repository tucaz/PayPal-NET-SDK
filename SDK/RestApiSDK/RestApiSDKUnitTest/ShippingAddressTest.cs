using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;


namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for ShippingAddressTest and is intended
    ///to contain all ShippingAddressTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShippingAddressTest
    {
        public ShippingAddress CreateShippingAddress()
        {
            ShippingAddress shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

        [TestMethod()]
        public void TestShippingAddress()
        {
            ShippingAddress shipping = CreateShippingAddress();
            Assert.AreEqual(shipping.recipient_name, "PayPalUser");
        }

        [TestMethod()]
        public void TestToJSON()
        {
            ShippingAddress shipping = CreateShippingAddress();
            Assert.IsFalse(shipping.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TestToString()
        {
            ShippingAddress shipping = CreateShippingAddress();
            Assert.IsFalse(shipping.ToString().Length == 0);
        }
    }
}
