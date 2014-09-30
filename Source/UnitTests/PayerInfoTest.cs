using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PayerInfoTest
    {
        public static PayerInfo GetPayerInfo()
        {
            PayerInfo info = new PayerInfo();
            info.first_name = "Joe";
            info.last_name = "Shopper";
            info.email = "Joe.Shopper@email.com";
            info.payer_id = "100";
            info.phone = "12345";
            info.shipping_address = ShippingAddressTest.GetShippingAddress();
            return info;
        }

        [TestMethod()]
        public void PayerInfoObjectTest()
        {
            var info = GetPayerInfo();
            Assert.AreEqual("Joe", info.first_name);
            Assert.AreEqual("Shopper", info.last_name);
            Assert.AreEqual("Joe.Shopper@email.com", info.email);
            Assert.AreEqual("100", info.payer_id);
            Assert.AreEqual("12345", info.phone);
            Assert.IsNotNull(info.shipping_address);
        }

        [TestMethod()]
        public void PayerInfoConvertToJsonTest()
        {
            Assert.IsFalse(GetPayerInfo().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PayerInfoToStringTest()
        {
            Assert.IsFalse(GetPayerInfo().ToString().Length == 0);
        }
    }
}
