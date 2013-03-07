using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for AmountDetailsTest and is intended
    ///to contain all AmountDetailsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AmountDetailsTest
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

        /// <summary>
        ///A test for tax
        ///</summary>
        [TestMethod()]
        public void taxTest()
        {
            AmountDetails target = GetAmountDetails();
            string expected = "15";
            string actual = target.tax;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for subtotal
        ///</summary>
        [TestMethod()]
        public void subtotalTest()
        {
            AmountDetails target = GetAmountDetails();
            string expected = "75";
            string actual = target.subtotal;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for shipping
        ///</summary>
        [TestMethod()]
        public void shippingTest()
        {
            AmountDetails target = GetAmountDetails();
            string expected = "10";
            string actual = target.shipping;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for fee
        ///</summary>
        [TestMethod()]
        public void feeTest()
        {
            AmountDetails target = GetAmountDetails();
            string expected = "2";
            string actual = target.fee;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            AmountDetails target = GetAmountDetails();
            string expected = "{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"2\"}";
            string actual = target.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AmountDetails Constructor
        ///</summary>
        [TestMethod()]
        public void AmountDetailsConstructorTest()
        {
            AmountDetails target = new AmountDetails();
            Assert.IsNotNull(target);
        }
    }
}
