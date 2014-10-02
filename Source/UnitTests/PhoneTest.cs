using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass]
    public class PhoneTest
    {
        public static Phone GetPhone()
        {
            var phone = new Phone();
            phone.number = "7162981822";
            phone.country_code = "1";
            return phone;
        }

        [TestMethod()]
        public void PhoneObjectTest()
        {
            var phone = GetPhone();
            Assert.AreEqual("7162981822", phone.number);
            Assert.AreEqual("1", phone.country_code);
        }

        [TestMethod()]
        public void PhoneConvertToJsonTest()
        {
            Assert.IsFalse(GetPhone().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PhoneToStringTest()
        {
            Assert.IsFalse(GetPhone().ToString().Length == 0);
        }
    }
}
