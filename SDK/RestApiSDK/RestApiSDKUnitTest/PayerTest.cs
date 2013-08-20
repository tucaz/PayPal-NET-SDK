using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Api.Payments;
using PayPal.Manager;

namespace RestApiSDKUnitTest
{
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

        private ShippingAddress CreateShippingAddress()
        {
            ShippingAddress shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

        private PayerInfo CreatePayerInfo()
        {
            PayerInfo info = new PayerInfo();
            info.first_name = "Joe";
            info.last_name = "Shopper";
            info.email = "Joe.Shopper@email.com";
            info.payer_id = "100";
            info.phone = "12345";
            info.shipping_address = CreateShippingAddress();
            return info;
        }

        private CreditCard CreateCreditCard()
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
            return card.Create(AccessToken);
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
            fundInstrument.credit_card = CreateCreditCard();
            fundInstrument.credit_card_token = GetCreditCardToken();
            return fundInstrument;
        }

        private Payer CreatePayer()
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
        public void PayerObjectTest()
        {
            Payer pay = CreatePayer();
            Assert.AreEqual(pay.payment_method, "credit_card");
            Assert.AreEqual(pay.funding_instruments[0].credit_card_token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(pay.payer_info.first_name, "Joe");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Payer pay = CreatePayer();
            Assert.IsFalse(pay.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Payer pay = CreatePayer();
            Assert.IsFalse(pay.ToString().Length == 0);
        }
    }    
}
