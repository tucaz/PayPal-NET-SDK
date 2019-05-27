using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class PhoneTest
    {
        public static readonly string PhoneJson = "{\"country_code\":\"001\",\"national_number\":\"5032141716\"}";

        public static Phone GetPhone()
        {
            return JsonFormatter.ConvertFromJson<Phone>(PhoneJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void PhoneObjectTest()
        {
            var phone = GetPhone();
            Assert.AreEqual("5032141716", phone.national_number);
            Assert.AreEqual("001", phone.country_code);
        }

        [TestMethod, TestCategory("Unit")]
        public void PhoneConvertToJsonTest()
        {
            Assert.IsFalse(GetPhone().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PhoneToStringTest()
        {
            Assert.IsFalse(GetPhone().ToString().Length == 0);
        }
    }
}
