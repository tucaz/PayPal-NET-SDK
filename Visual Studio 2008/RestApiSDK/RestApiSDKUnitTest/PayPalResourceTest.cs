using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;
using System;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for PayPalResourceTest and is intended
    ///to contain all PayPalResourceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PayPalResourceTest
    {
        string resource = "v1/payments/payment";

        private string payLoad
        {
            get
            {
                string loadPay = "{\"intent\":\"sale\",\"payer\":{\"payment_method\":\"credit_card\",\"funding_instruments\":[{\"credit_card\":{\"type\":\"visa\",\"number\":\"4825854086744369\",\"expire_month\":\"01\",\"expire_year\":\"2015\",\"cvv2\":\"962\",\"first_name\":\"John\",\"last_name\":\"Doe\",\"billing_address\":{\"line1\":\"3909 Witmer Road\",\"line2\":\"Niagara Falls\",\"city\":\"New York\",\"state\":\"NY\",\"postal_code\":\"14305\",\"country_code\":\"US\",\"type\":\"Business\",\"phone\":\"716-298-1822\"}}}]},\"transactions\":[{\"amount\":{\"total\":\"100\",\"currency\":\"USD\",\"details\":{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"5\"}},\"description\":\"This is the payment transaction description.\"}]}";
                return loadPay;
            }
        }

        private string ClientID
        {
            get
            {
                string clntID = ConfigManager.Instance.GetProperty("ClientID");
                return clntID;
            }
        }

        private string ClientSecret
        {
            get
            {
                string clntSecret = ConfigManager.Instance.GetProperty("ClientSecret");
                return clntSecret;
            }
        }

        private string AccessToken
        {
            get
            {
                string tokenAccess = new OAuthTokenCredential(ClientID, ClientSecret).GetAccessToken();
                return tokenAccess;
            }
        }

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
                
        /// <summary>
        ///A test for ConfigureAndExecute
        ///</summary>
        public void ConfigureAndExecuteTestHelper<T>()
        {
            string tokenAccess = AccessToken;
            HttpMethod httpMethod = HttpMethod.POST;           
            Payment actual = PayPalResource.ConfigureAndExecute<Payment>(tokenAccess, httpMethod, resource, payLoad);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ConfigureAndExecute
        ///</summary>
        public void ConfigureAndExecuteTest1Helper<T>()
        {
            APIContext apiContext = new APIContext(AccessToken);
            HttpMethod httpMethod = HttpMethod.POST;
            Payment actual = PayPalResource.ConfigureAndExecute<Payment>(apiContext, httpMethod, resource, payLoad);
            Assert.IsNotNull(actual);
        }        
    }
}
