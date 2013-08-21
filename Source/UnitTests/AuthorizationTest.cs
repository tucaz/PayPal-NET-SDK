using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AuthorizationTest
    {
        private string ClientId
        {
            get
            {
                string Id = PayPal.Manager.ConfigManager.Instance.GetProperties()["ClientID"];
                return Id;
            }
        }

        private string ClientSecret
        {
            get
            {
                string secret = ConfigManager.Instance.GetProperties()["ClientSecret"];
                return secret;
            }
        }

        private string AccessToken
        {
            get
            {
                string token = new OAuthTokenCredential(ClientId, ClientSecret).GetAccessToken();
                return token;
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

        private CreditCard GetCreditCard()
        {
            CreditCard card = new CreditCard();
            card.cvv2 = "962";
            card.expire_month = 01;
            card.expire_year = 2015;
            card.first_name = "John";
            card.last_name = "Doe";
            card.number = "4825854086744369";
            card.type = "visa";
            card.state = "New York";
            card.payer_id = "008";
            card.id = "002";
            card.billing_address = GetAddress();
            return card;
        } 

        private Payment GetPayment()
        {
            Payment pay = new Payment();
            pay.intent = "authorize";
            CreditCard card = GetCreditCard();
            List<FundingInstrument> instruments = new List<FundingInstrument>();
            FundingInstrument instrument = new FundingInstrument();
            instrument.credit_card = card;
            instruments.Add(instrument);
            Payer payr = new Payer();
            payr.payment_method = "credit_card";
            payr.funding_instruments = instruments;
            List<Transaction> transacts = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = GetAmount();
            transacts.Add(trans);
            pay.transactions = transacts;
            pay.payer = payr;
            Payment actual = pay.Create(AccessToken);
            return actual;
        }     

        [TestMethod()]
        public void AuthorizationObjectTest()
        {
            Authorization authorize = GetAuthorization();
            Amount expected = GetAmount();
            Amount actual = authorize.amount;
            Assert.AreEqual(expected.currency, actual.currency);
            Assert.AreEqual(expected.details.fee, actual.details.fee);
            Assert.AreEqual(expected.details.shipping, actual.details.shipping);
            Assert.AreEqual(expected.details.subtotal, actual.details.subtotal);
            Assert.AreEqual(expected.details.tax, actual.details.tax);
            Assert.AreEqual(expected.total, actual.total);
            Assert.AreEqual(authorize.id, "007");
            Assert.AreEqual(authorize.create_time, "2013-01-15T15:10:05.123Z");
            Assert.AreEqual(authorize.parent_payment, "1000");
            Assert.AreEqual(authorize.state, "Authorized");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Authorization authorize = GetAuthorization();
            Assert.IsFalse(authorize.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Authorization authorize = GetAuthorization();
            Assert.IsFalse(authorize.ToString().Length == 0);
        }

        [TestMethod()]
        public void AuthorizationGetTest()
        {
            Payment payment = GetPayment();
            string authorizationId = payment.transactions[0].related_resources[0].authorization.id;
            Authorization authorization = Authorization.Get(AccessToken, authorizationId);
            Assert.AreEqual(authorizationId, authorization.id);
        }

        [TestMethod()]
        public void AuthorizationCaptureTest()
        {
            Payment pay = GetPayment();
            string authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            Authorization authorize = Authorization.Get(AccessToken, authorizationId);
            Capture cap = new Capture();
            Amount amount = new Amount();
            amount.total = "1";
            amount.currency = "USD";
            cap.amount = amount;
            Capture response = authorize.Capture(AccessToken, cap);
            Assert.AreEqual("completed", response.state);
        }

        [TestMethod()]
        public void AuthorizationVoidTest()
        {
            Payment pay = GetPayment();
            string authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            Authorization authorize = Authorization.Get(AccessToken, authorizationId);
            Authorization authorizationResponse = authorize.Void(AccessToken);
            Assert.AreEqual("voided", authorizationResponse.state);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException), "Value cannot be null. Parameter name: AccessToken cannot be null")]
        public void GetAuthorizationForNullTokenTest()
        {
            Payment pay = GetPayment();
            string authorizationId = pay.transactions[0].related_resources[0].authorization.id;            
            Authorization authorization = Authorization.Get((string) null, authorizationId);            
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException), "Value cannot be null. Parameter name: AccessToken cannot be null")]
        public void GetAuthorizationForNullIdTest()
        {
            string authorizationId = null;
            Authorization authorization = Authorization.Get(AccessToken, authorizationId);
        }
    }
}
