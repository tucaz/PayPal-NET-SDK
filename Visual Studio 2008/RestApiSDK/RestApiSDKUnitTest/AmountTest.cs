using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for AmountTest and is intended
    ///to contain all AmountTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AmountTest
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

        private AmountDetails GetAmountDetails()
        {
            AmountDetails amntDetails = new AmountDetails();
            amntDetails.tax = "15";
            amntDetails.fee = "2";
            amntDetails.shipping = "10";
            amntDetails.subtotal = "75";
            return amntDetails;
        }

        private Amount GetAmount()
        {
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.details = GetAmountDetails();
            amnt.total = "100";
            return amnt;
        }

        /// <summary>
        ///A test for total
        ///</summary>
        [TestMethod()]
        public void totalTest()
        {
            Amount target = GetAmount();
            string expected = "100";
            string actual = target.total;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for details
        ///</summary>
        [TestMethod()]
        public void detailsTest()
        {
            Amount target = GetAmount();
            AmountDetails expected = GetAmountDetails();
            AmountDetails actual = target.details;
            Assert.AreEqual(expected.subtotal, actual.subtotal);
            Assert.AreEqual(expected.fee, actual.fee);
            Assert.AreEqual(expected.shipping, actual.shipping);
            Assert.AreEqual(expected.subtotal, actual.subtotal);
        }

        /// <summary>
        ///A test for currency
        ///</summary>
        [TestMethod()]
        public void currencyTest()
        {
            Amount target = GetAmount();
            string expected = "USD";
            string actual = target.currency;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Amount target = GetAmount();
            string expected = "{\"total\":\"100\",\"currency\":\"USD\",\"details\":{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"2\"}}";
            string actual = target.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Amount Constructor
        ///</summary>
        [TestMethod()]
        public void AmountConstructorTest()
        {
            Amount target = new Amount();
            Assert.IsNotNull(target);
        }
    }
}
