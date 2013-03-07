using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayPal;
using PayPal.Manager;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for APIContext and is intended
    ///to contain all APIContext Unit Tests
    ///</summary>
    [TestClass()]
    public class APIContextTest
    {
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
        ///A test for CallParameters Constructor
        ///</summary>
        [TestMethod()]
        public void APIContextConstructorTest()
        {
            string tokenAccess = AccessToken;
            string requestId = Convert.ToString(Guid.NewGuid());
            APIContext apiContext = new APIContext(tokenAccess, requestId);
            Assert.IsNotNull(apiContext);
            Assert.AreEqual(tokenAccess, apiContext.AccessToken);
            Assert.AreEqual(requestId, apiContext.RequestID);
        }  
    }
}
