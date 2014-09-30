using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PayeeTest
    {
        [TestMethod()]
        public void PayeeObjectTest()
        {
            var pay = UnitTestUtil.GetPayee();
            Assert.AreEqual(pay.merchant_id, "100");
            Assert.AreEqual(pay.email, "paypaluser@email.com");
            Assert.IsNotNull(pay.phone);
            Assert.AreEqual(pay.phone.national_number, "7162981822");
            Assert.AreEqual(pay.phone.country_code, "1");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var pay = UnitTestUtil.GetPayee();
            Assert.IsFalse(pay.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var pay = UnitTestUtil.GetPayee();
            Assert.IsFalse(pay.ToString().Length == 0);
        }
    }
}
