using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for AuthorizationTest and is intended
    ///to contain all AuthorizationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AuthorizationTest
    {
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

        private List<Links> GetLinksList()
        {
            Links lnk = new Links();
            lnk.href = "http://www.paypal.com";
            lnk.method = "POST";
            lnk.rel = "authorize";
            List<Links> lnks = new List<Links>();
            lnks.Add(lnk);
            return lnks;
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

        private Amount GetAmount()
        {
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.details = GetDetails();
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
            author.links = GetLinksList();
            return author;
        }

        /// <summary>
        ///A test for state
        ///</summary>
        [TestMethod()]
        public void StateTest()
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
        public void ParentPaymentTest()
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
        public void LinksTest()
        {
            Authorization target = GetAuthorization();
            List<Links> expected = GetLinksList();
            List<Links> actual = target.links;
            Assert.AreEqual(expected.Capacity, actual.Capacity);
            Assert.AreEqual(expected.Count, actual.Count);

        }

        /// <summary>
        ///A test for id
        ///</summary>
        [TestMethod()]
        public void IdTest()
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
        public void CreateTimeTest()
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
        public void AmountTest()
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
            Assert.AreEqual("007", target.id);
            Assert.AreEqual("Authorized", target.state);
            Assert.AreEqual("100", target.amount.total);
            Assert.AreEqual("USD", target.amount.currency);
            Assert.AreEqual("75", target.amount.details.subtotal);
            Assert.AreEqual("15", target.amount.details.tax);
            Assert.AreEqual("10", target.amount.details.shipping);
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

        /// <summary>
        ///A test for Get Authorization
        ///</summary>
        [TestMethod()]
        public void GetAuthorizationTest()
        {
            Payment payment = GetPaymentObject(AccessToken);
            string authorizationId = payment.transactions[0].related_resources[0].authorization.id;
            Authorization authorization = Authorization.Get(AccessToken, authorizationId);
            Assert.AreEqual(authorizationId, authorization.id);
        }

        /// <summary>
        ///A test for Authorization Capture
        ///</summary>
        [TestMethod()]
        public void AuthorizationCaptureTest()
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
            Assert.AreEqual("completed", response.state);
        }

        /// <summary>
        ///A test for Authorization Void
        ///</summary>
        [TestMethod()]
        public void AuthorizationVoidTest()
        {
            Payment payment = GetPaymentObject(AccessToken);
            string authorizationId = payment.transactions[0].related_resources[0].authorization.id;
            Authorization authorization = Authorization.Get(AccessToken, authorizationId);
            Authorization response = authorization.Void(AccessToken);
            Assert.AreEqual("voided", response.state);
        }

        /// <summary>
        ///A test for Get Authorization null Id
        ///</summary>
        [TestMethod()]
        public void GetAuthorizationForNullTokenTest()
        {
            Payment payment = GetPaymentObject(AccessToken);
            string authorizationId = payment.transactions[0].related_resources[0].authorization.id;
            try
            {
                Authorization authorization = Authorization.Get((string) null, authorizationId);
            }
            catch (System.ArgumentNullException exe)
            {
                Assert.IsNotNull(exe);
            }
        }

        /// <summary>
        ///A test for Get Authorization for null Id
        ///</summary>
        [TestMethod()]
        public void GetAuthorizationForNullIdTest()
        {
            string authorizationId = null;
            try
            {
                Authorization authorization = Authorization.Get(AccessToken, authorizationId);
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

        
    }
}
