using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for AuthorizationTest and is intended
    ///to contain all AuthorizationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AuthorizationTest
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

        private Authorization GetAuthorization()
        {
            Authorization author = new Authorization();
            author.amount = GetAmount();
            author.create_time = "2013-01-15T15:10:05.123Z";
            author.id = "007";
            author.parent_payment = "1000";
            author.state = "Authorized";
            author.links = GetLinkList();
            return author;
        }

        /// <summary>
        ///A test for state
        ///</summary>
        [TestMethod()]
        public void stateTest()
        {
            Authorization target = GetAuthorization();
            string expected = "Authorized";
            string actual;
            target.state = expected;
            actual = target.state;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for parent_payment
        ///</summary>
        [TestMethod()]
        public void parent_paymentTest()
        {
            Authorization target = GetAuthorization();
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
            Authorization target = GetAuthorization();
            List<Link> expected = GetLinkList();
            List<Link> actual = target.links;
            Assert.AreEqual(expected.Capacity, actual.Capacity);
            Assert.AreEqual(expected.Count, actual.Count);

        }

        /// <summary>
        ///A test for id
        ///</summary>
        [TestMethod()]
        public void idTest()
        {
            Authorization target = GetAuthorization();
            string expected = "007";
            string actual = target.id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for create_time
        ///</summary>
        [TestMethod()]
        public void create_timeTest()
        {
            Authorization target = GetAuthorization();
            string expected = "2013-01-15T15:10:05.123Z";
            string actual = target.create_time;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for amount
        ///</summary>
        [TestMethod()]
        public void amountTest()
        {
            Authorization target = GetAuthorization();
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
            Authorization target = GetAuthorization();
            string expected = "{\"id\":\"007\",\"create_time\":\"2013-01-15T15:10:05.123Z\",\"state\":\"Authorized\",\"amount\":{\"total\":\"100\",\"currency\":\"USD\",\"details\":{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"2\"}},\"parent_payment\":\"1000\",\"links\":[{\"href\":\"http://www.paypal.com\",\"rel\":\"authorize\",\"method\":\"POST\"}]}";
            string actual = target.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Authorization Constructor
        ///</summary>
        [TestMethod()]
        public void AuthorizationConstructorTest()
        {
            Authorization target = new Authorization();
            Assert.IsNotNull(target);
        }
    }
}
