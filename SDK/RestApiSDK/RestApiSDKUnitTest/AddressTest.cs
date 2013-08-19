using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for AddressTest and is intended
    ///to contain all AddressTest Unit Tests
    ///</summary>
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

        /// <summary>
        ///A test for Address Constructor
        ///</summary>
        [TestMethod()]
        public void AddressConstructorTest()
        {
            Address target = new Address();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
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
        }

        /// <summary>
        ///A test for city
        ///</summary>
        [TestMethod()]
        public void CityTest()
        {
            Address target = GetAddress();
            string expected = "San Jose";
            string actual = target.city;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for country_code
        ///</summary>
        [TestMethod()]
        public void CountryCodeTest()
        {
            Address target = GetAddress();
            string expected = "US";
            string actual = target.country_code;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for line1
        ///</summary>
        [TestMethod()]
        public void Line1Test()
        {
            Address target = GetAddress();
            string expected = "2211";
            string actual = target.line1;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for line2
        ///</summary>
        [TestMethod()]
        public void Line2Test()
        {
            Address target = GetAddress();
            string expected = "N 1st St";
            string actual = target.line2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for phone
        ///</summary>
        [TestMethod()]
        public void PhoneTest()
        {
            Address target = GetAddress();
            string expected = "408-456-0392";
            string actual = target.phone;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for postal_code
        ///</summary>
        [TestMethod()]
        public void PostalCodeTest()
        {
            Address target = GetAddress();
            string expected = "95131";
            string actual = target.postal_code;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for state
        ///</summary>
        [TestMethod()]
        public void StateTest()
        {
            Address target = GetAddress();
            string expected = "California";
            string actual = target.state;
            Assert.AreEqual(expected, actual);
        }
    }
}
