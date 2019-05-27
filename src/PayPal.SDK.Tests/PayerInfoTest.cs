using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class PayerInfoTest
    {
        public static PayerInfo GetPayerInfo()
        {
            var info = GetPayerInfoBasic();
            info.email = "Joe.Shopper@email.com";
            info.phone = "5032141716";
            return info;
        }

        public static PayerInfo GetPayerInfoBasic()
        {
            PayerInfo info = new PayerInfo();
            info.first_name = "Joe";
            info.last_name = "Shopper";
            info.payer_id = "100";
            return info;
        }

        [TestMethod, TestCategory("Unit")]
        public void PayerInfoObjectTest()
        {
            var info = GetPayerInfo();
            Assert.AreEqual("Joe", info.first_name);
            Assert.AreEqual("Shopper", info.last_name);
            Assert.AreEqual("Joe.Shopper@email.com", info.email);
            Assert.AreEqual("100", info.payer_id);
            Assert.AreEqual("5032141716", info.phone);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayerInfoConvertToJsonTest()
        {
            Assert.IsFalse(GetPayerInfo().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayerInfoToStringTest()
        {
            Assert.IsFalse(GetPayerInfo().ToString().Length == 0);
        }
    }
}
