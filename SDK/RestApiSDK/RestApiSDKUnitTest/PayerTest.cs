using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Api.Payments;
using PayPal.Manager;

namespace RestApiSDKUnitTest
{  
    /// <summary>
    ///This is a test class for PayerTest and is intended
    ///to contain all PayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PayerTest
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

        public ShippingAddress CreateShippingAddress()
        {
            ShippingAddress shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

        public PayerInfo CreatePayerInfo()
        {
            PayerInfo payerInfo = new PayerInfo();
            payerInfo.first_name = "Joe";
            payerInfo.last_name = "Shopper";
            payerInfo.email = "Joe.Shopper@email.com";
            payerInfo.payer_id = "100";
            payerInfo.phone = "12345";
            payerInfo.shipping_address = CreateShippingAddress();
            return payerInfo;
        }

        public CreditCard CreateCreditCard()
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

            CreditCard CrdtCard = credCard.Create(AccessToken);
            return CrdtCard;
        }

        private CreditCard GetCreditCard()
        {
            CreditCard credCard = CreateCreditCard();
            return credCard;
        }

        private CreditCardToken GetCreditCardToken()
        {
            CreditCardToken credCardToken = new CreditCardToken();
            credCardToken.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            credCardToken.payer_id = "009";
            return credCardToken;
        }   

        private FundingInstrument GetFundingInstrument()
        {
            FundingInstrument fundInstrument = new FundingInstrument();
            fundInstrument.credit_card = GetCreditCard();
            fundInstrument.credit_card_token = GetCreditCardToken();
            return fundInstrument;
        }

        public Payer CreatePayer()
        {
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            fundingInstruments.Add(GetFundingInstrument());
            Payer payer = new Payer();
            payer.funding_instruments = fundingInstruments;
            payer.payer_info = CreatePayerInfo();
            payer.payment_method = "credit_card";
            return payer;
        }

        [TestMethod()]
        public void TestPayer()
        {
            Payer pay = CreatePayer();
            Assert.AreEqual(pay.payment_method, "credit_card");
            Assert.AreEqual(pay.funding_instruments[0].credit_card_token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(pay.payer_info.first_name, "Joe");
        }

        [TestMethod()]
        public void TestToJSON()
        {
            Payer pay = CreatePayer();
            Assert.IsFalse(pay.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TestToString()
        {
            Payer pay = CreatePayer();
            Assert.IsFalse(pay.ToString().Length == 0);
        }
    }    
}
