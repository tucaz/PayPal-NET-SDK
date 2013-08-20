using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class RefundTest
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
        
        private Payment GetPayment()
        {
            Payment target = new Payment();
            target.intent = "authorize";
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
            Payment actual = target.Create(AccessToken);
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

        private CreditCard GetCreditCard()
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
        public void GetRefundTest()
        {
            Payment payment = GetPayment();
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

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException), "Value cannot be null. Parameter name: refundId cannot be null")]
        public void GetRefundNullIdTest()
        {
            Refund retrievedRefund = Refund.Get(AccessToken, null);
        }
    }
}
