using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentHistoryTest
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

        private Payment CreatePayment()
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
            return pay.Create(AccessToken);
        }

        private PaymentHistory CreatePaymentHistory()
        {
            List<Payment> payments = new List<Payment>();
            payments.Add(CreatePayment());
            PaymentHistory history = new PaymentHistory();
            history.count = 1;
            history.payments = payments;
            history.next_id = "1";
            return history;
        }

        [TestMethod()]
        public void PaymentHistoryObjectTest()
        {
            PaymentHistory history = CreatePaymentHistory();
            Assert.AreEqual(history.count, 1);
            Assert.AreEqual(history.next_id, "1");
            Assert.AreEqual(history.payments.Count, 1);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            PaymentHistory history = CreatePaymentHistory();
            Assert.IsFalse(history.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            PaymentHistory history = CreatePaymentHistory();
            Assert.IsFalse(history.ToString().Length == 0);
        }
    }
}
