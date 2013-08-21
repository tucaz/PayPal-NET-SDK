using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class FundingInstrumentTest
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

        private CreditCardToken GetCreditCardToken()
        {
            CreditCardToken card = new CreditCardToken();
            card.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            card.payer_id = "009";
            return card;
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

        private FundingInstrument GetFundingInstrument()
        {
            FundingInstrument instrument = new FundingInstrument();
            instrument.credit_card = CreateCreditCard();    
            instrument.credit_card_token = GetCreditCardToken();
            return instrument;
        }              

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            FundingInstrument instrument = GetFundingInstrument();
            Assert.IsFalse(instrument.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            FundingInstrument instrument = GetFundingInstrument();
            Assert.IsFalse(instrument.ToString().Length == 0);
        }
    }
}
