using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal;
using PayPal.Manager;
using PayPal.Util;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentTest
    {
        private string ClientId
        {
            get
            {
                string Id = ConfigManager.Instance.GetProperties()["ClientID"];
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

        private Payment GetPayment(string accessToken)
        {
            Payment pay = new Payment();
            pay.intent = "sale";
            CreditCard card = GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = card;
            fundingInstruments.Add(fundingInstrument);
            Payer payer = new Payer();
            payer.payment_method = "credit_card";
            payer.funding_instruments = fundingInstruments;
            List<Transaction> transactionList = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = GetAmount();
            transactionList.Add(trans);
            pay.transactions = transactionList;
            pay.payer = payer;
            Payment paymnt = pay.Create(accessToken);
            return paymnt;
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

        [TestMethod()]
        public void CreatePaymentTest()
        {
            string accessToken = AccessToken;
            Payment target = new Payment(); 
            target.intent = "sale";
            CreditCard card = GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = card;
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
            Payment actual = new Payment();
            actual = target.Create(accessToken);
            Assert.AreEqual("approved", actual.state);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException), "Value cannot be null. Parameter name: AccessToken cannot be null")]
        public void CreateTestForNullAccessToken()
        {
            string accessToken = null;
            Payment pay = new Payment();
            pay.intent = "sale";
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
            Payment actual = pay.Create(accessToken);           
        }

        [TestMethod()]
        public void TestPayment()
        {
            string accessToken = AccessToken;
            APIContext apiContext = new APIContext(accessToken);
            Payment actual = GetPayment(accessToken);
            Payment retrievedPayment = Payment.Get(apiContext, actual.id);
            Assert.AreEqual(actual.id, retrievedPayment.id);
        }

        [TestMethod()]
        public void TestPaymentHistory()
        {
            string accessToken = AccessToken;
            APIContext apiContext = new APIContext(accessToken);
            Dictionary<string, string> containerDictionary = new Dictionary<string, string>();
            containerDictionary.Add("count", "10");
            PaymentHistory paymentHistory = Payment.List(apiContext, containerDictionary);
            Assert.AreEqual(10, paymentHistory.count);
        }

        [TestMethod()]
        public void TestPaymentHistoryQueryParameters()
        {
            string accessToken = AccessToken;
            APIContext apiContext = new APIContext(accessToken);
            QueryParameters queryParameters = new QueryParameters();
            queryParameters.SetCount("10");
            PaymentHistory paymentHistory = Payment.Get(apiContext, queryParameters);
            Assert.AreEqual(10, paymentHistory.count);
        }
    }
}
