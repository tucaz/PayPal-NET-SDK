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
        public void CityTest()
        {
            Address target = GetAddress();
            string expected = "San Jose";
            string actual = target.city;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CountryCodeTest()
        {
            Address target = GetAddress();
            string expected = "US";
            string actual = target.country_code;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Line1Test()
        {
            Address target = GetAddress();
            string expected = "2211";
            string actual = target.line1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Line2Test()
        {
            Address target = GetAddress();
            string expected = "N 1st St";
            string actual = target.line2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PhoneTest()
        {
            Address target = GetAddress();
            string expected = "408-456-0392";
            string actual = target.phone;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PostalCodeTest()
        {
            Address target = GetAddress();
            string expected = "95131";
            string actual = target.postal_code;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StateTest()
        {
            Address target = GetAddress();
            string expected = "California";
            string actual = target.state;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Address target = GetAddress();
            string actual = target.ConvertToJson();
            Assert.AreEqual("2211", target.line1);
            Assert.AreEqual("N 1st St", target.line2);
            Assert.AreEqual("San Jose", target.city);
            Assert.AreEqual("California", target.state);
            Assert.AreEqual("95131", target.postal_code);
            Assert.AreEqual("US", target.country_code);
            Assert.IsFalse(target.ToString().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Address addrss = GetAddress();
            Assert.IsFalse(addrss.ToString().Length == 0);
        }
    }
}
