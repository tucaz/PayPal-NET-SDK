using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class PayeeTest
    {
        public static Payee GetPayee()
        {
            Payee pay = new Payee();
            pay.merchant_id = "100";
            pay.email = "paypaluser@email.com";
            pay.phone = PhoneTest.GetPhone();
            return pay;
        }

        [TestMethod, TestCategory("Unit")]
        public void PayeeObjectTest()
        {
            var pay = GetPayee();
            Assert.AreEqual(pay.merchant_id, "100");
            Assert.AreEqual(pay.email, "paypaluser@email.com");
            Assert.IsNotNull(pay.phone);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayeeConvertToJsonTest()
        {
            Assert.IsFalse(GetPayee().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayeeToStringTest()
        {
            Assert.IsFalse(GetPayee().ToString().Length == 0);
        }
    }
}
