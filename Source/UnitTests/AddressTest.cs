using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AddressTest
    {
        [TestMethod()]
        public void AddressObjectTest()
        {
            var add = UnitTestUtil.GetAddress();
            Assert.AreEqual("2211", add.line1);
            Assert.AreEqual("N 1st St", add.line2);
            Assert.AreEqual("San Jose", add.city);
            Assert.AreEqual("California", add.state);
            Assert.AreEqual("95131", add.postal_code);
            Assert.AreEqual("US", add.country_code);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var add = UnitTestUtil.GetAddress();
            Assert.IsFalse(add.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var add = UnitTestUtil.GetAddress();
            Assert.IsFalse(add.ToString().Length == 0);
        }
    }
}
