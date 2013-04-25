using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for FundingInstrumentTest and is intended
    ///to contain all FundingInstrumentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FundingInstrumentTest
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

        private string ClientID
        {
            get
            {
                string clntID = ConfigManager.Instance.GetProperties()["ClientID"];
                return clntID;
            }
        }

        private string ClientSecret
        {
            get
            {
                string clntSecret = ConfigManager.Instance.GetProperties()["ClientSecret"];
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

        private CreditCardToken GetCreditCardToken()
        {
            CreditCardToken credCardToken = new CreditCardToken();
            credCardToken.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            credCardToken.payer_id = "009";
            return credCardToken;
        }

       

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
            addrss.type = "E-commerce";
            return addrss;
        }

        public CreditCard CreateCreditCard()
        {
            CreditCard credCard = new CreditCard();
            credCard.cvv2 = "962";
            credCard.expire_month = "01";
            credCard.expire_year = "2015";
            credCard.first_name = "John";
            credCard.last_name = "Doe";
            credCard.number = "4825854086744369";
            credCard.type = "visa";
            credCard.state = "New York";
            credCard.payer_id = "008";
            credCard.id = "002";

            CreditCard CrdtCard = credCard.Create(AccessToken);
            return CrdtCard;
        }

        private CreditCard GetCreditCard()
        {
            CreditCard credCard = CreateCreditCard();
            return credCard;
        }      

        private FundingInstrument GetFundingInstrument()
        {
            FundingInstrument fundInstrument = new FundingInstrument();
            fundInstrument.credit_card = GetCreditCard();
            fundInstrument.credit_card_token = GetCreditCardToken();
            return fundInstrument;
        }
           

        /// <summary>
        ///A test for FundingInstrument Constructor
        ///</summary>
        [TestMethod()]
        public void FundingInstrumentConstructorTest()
        {
            FundingInstrument target = new FundingInstrument();
            Assert.IsNotNull(target);
        }
    }
}
