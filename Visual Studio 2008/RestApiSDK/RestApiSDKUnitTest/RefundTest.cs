using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;


namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for RefundTest and is intended
    ///to contain all RefundTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RefundTest
    {
        private TestContext testContextInstance;

        private string ClientID
        {
            get
            {
                string clntID = PayPal.Manager.ConfigManager.Instance.GetProperties()["ClientID"];
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

        /// <summary>
        ///A test for Get Refund
        ///</summary>
        [TestMethod()]
        public void GetRefundTest()
        {
            Payment payment = GetPaymentObject(AccessToken);
            string authorizationId = payment.transactions[0].related_resources[0].authorization.id;
            Authorization authorization = Authorization.Get(AccessToken, authorizationId);
            Capture capture = new Capture();
            Amount amount = new Amount();
            amount.total = "1";
            amount.currency = "USD";
            capture.amount = amount;
            Capture response = authorization.Capture(AccessToken, capture);
            Refund refund = new Refund();
            Amount rAmount = new Amount();
            rAmount.total = "1";
            rAmount.currency = "USD";
            refund.amount = rAmount;
            Refund responseRefund = response.Refund(AccessToken, refund);
            Refund retrievedRefund = Refund.Get(AccessToken, responseRefund.id);
            Assert.AreEqual(responseRefund.id, retrievedRefund.id);
        }

        /// <summary>
        ///A test for Refund using null Id
        ///</summary>
        [TestMethod()]
        public void GetRefundNullIdTest()
        {
            try
            {
                Refund retrievedRefund = Refund.Get(AccessToken, null);
            }
            catch (System.ArgumentNullException exe)
            {
                Assert.IsNotNull(exe);
            }
        }

        private Payment GetPaymentObject(string accessToken)
        {
            Payment target = new Payment();
            target.intent = "authorize";
            CreditCard creditCard = GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = creditCard;
            fundingInstruments.Add(fundingInstrument);
            Payer payer = new Payer();
            payer.payment_method = "credit_card";
            payer.funding_instruments = fundingInstruments;
            List<Transaction> transacts = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = GetAmount();
            transacts.Add(trans);
            target.transactions = transacts;
            target.payer = payer;
            Payment actual = target.Create(accessToken);
            return actual;
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
            return addrss;
        }

        public CreditCard GetCreditCard()
        {
            CreditCard credCard = new CreditCard();
            credCard.cvv2 = "962";
            credCard.expire_month = 01;
            credCard.expire_year = 2015;
            credCard.first_name = "John";
            credCard.last_name = "Doe";
            credCard.number = "4825854086744369";
            credCard.type = "visa";
            credCard.state = "New York";
            credCard.payer_id = "008";
            credCard.id = "002";
            credCard.billing_address = GetAddress();
            return credCard;
        }

        private Amount GetAmount()
        {
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.details = GetDetails();
            amnt.total = "100";
            return amnt;
        }

        private Details GetDetails()
        {
            Details amntDetails = new Details();
            amntDetails.tax = "15";
            amntDetails.fee = "2";
            amntDetails.shipping = "10";
            amntDetails.subtotal = "75";
            return amntDetails;
        }
         
    }
}
