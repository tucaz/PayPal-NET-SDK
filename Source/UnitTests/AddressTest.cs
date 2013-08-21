using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AddressTest
    {
        private Address GetAddress()
        {
            Address addrss = new Address();
            addrss.line1 = "2211";
            addrss.line2 = "N 1st St";
            addrss.city = "San Jose";
            addrss.phone = "408-456-0392";
            addrss.postal_code = "95131";
            addrss.state = "California";
            addrss.country_code = "US";
            return addrss;
        }

        [TestMethod()]
        public void AddressObjectTest()
        {
            Address add = GetAddress();
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
            Address add = GetAddress();
            Assert.IsFalse(add.ToString().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Address add = GetAddress();
            Assert.IsFalse(add.ToString().Length == 0);
        }
    }
}
