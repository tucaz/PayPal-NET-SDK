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
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

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
        public void cityTest()
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
        public void country_codeTest()
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
        public void line1Test()
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
        public void line2Test()
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
        public void phoneTest()
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
        public void postal_codeTest()
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
        public void stateTest()
        {
            Address target = GetAddress();
            string expected = "California";
            string actual = target.state;
            Assert.AreEqual(expected, actual);
        }

    }
}
