using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for CaptureTest and is intended
    ///to contain all CaptureTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CaptureTest
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

        private List<Link> GetLinkList()
        {
            Link lnk = new Link();
            lnk.href = "http://www.paypal.com";
            lnk.method = "POST";
            lnk.rel = "authorize";
            List<Link> lnks = new List<Link>();
            lnks.Add(lnk);
            return lnks;
        }

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

        private Capture GetCapture()
        {
            Capture cap = new Capture();
            cap.amount = GetAmount();
            cap.authorization_id = "005";
            cap.create_time = "2013-01-15T15:10:05.123Z";
            cap.description = "Description";
            cap.state = "Authorized";
            cap.parent_payment = "1000";
            cap.links = GetLinkList();
            cap.id = "001";
            return cap;
        }

        /// <summary>
        ///A test for state
        ///</summary>
        [TestMethod()]
        public void stateTest()
        {
            Capture target = GetCapture();
            string expected = "Authorized";
            string actual = target.state;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for parent_payment
        ///</summary>
        [TestMethod()]
        public void parent_paymentTest()
        {
            Capture target = GetCapture();
            string expected = "1000";
            string actual = target.parent_payment;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for links
        ///</summary>
        [TestMethod()]
        public void linksTest()
        {
            Capture target = GetCapture();
            List<Link> expected = GetLinkList();
            List<Link> actual = target.links;
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected.Capacity, actual.Capacity);
        }

        /// <summary>
        ///A test for id
        ///</summary>
        [TestMethod()]
        public void idTest()
        {
            Capture target = GetCapture();
            string expected = "001";
            string actual = target.id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for description
        ///</summary>
        [TestMethod()]
        public void descriptionTest()
        {
            Capture target = GetCapture();
            string expected = "Description";
            string actual = target.description;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for create_time
        ///</summary>
        [TestMethod()]
        public void create_timeTest()
        {
            Capture target = GetCapture();
            string expected = "2013-01-15T15:10:05.123Z";
            string actual = target.create_time;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for authorization_id
        ///</summary>
        [TestMethod()]
        public void authorization_idTest()
        {
            Capture target = GetCapture();
            string expected = "005";
            string actual = target.authorization_id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for amount
        ///</summary>
        [TestMethod()]
        public void amountTest()
        {
            Capture target = GetCapture();
            Amount expected = GetAmount();
            Amount actual = target.amount;
            Assert.AreEqual(expected.currency, actual.currency);
            Assert.AreEqual(expected.details.fee, actual.details.fee);
            Assert.AreEqual(expected.details.shipping, actual.details.shipping);
            Assert.AreEqual(expected.details.subtotal, actual.details.subtotal);
            Assert.AreEqual(expected.details.tax, actual.details.tax);
            Assert.AreEqual(expected.total, actual.total);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Capture target = GetCapture();
            string expected = "{\"id\":\"001\",\"create_time\":\"2013-01-15T15:10:05.123Z\",\"state\":\"Authorized\",\"amount\":{\"total\":\"100\",\"currency\":\"USD\",\"details\":{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"2\"}},\"parent_payment\":\"1000\",\"authorization_id\":\"005\",\"description\":\"Description\",\"links\":[{\"href\":\"http://www.paypal.com\",\"rel\":\"authorize\",\"method\":\"POST\"}]}";
            string actual = target.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Capture Constructor
        ///</summary>
        [TestMethod()]
        public void CaptureConstructorTest()
        {
            Capture target = new Capture();
            Assert.IsNotNull(target);
        }
    }
}
