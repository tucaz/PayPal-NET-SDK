using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class CreditCardTest
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

        [TestMethod()]
        public void CreditCardObjectTest()
        {
            CreditCard card = GetCreditCard();
            Assert.AreEqual(card.number, "4825854086744369");
            Assert.AreEqual(card.id, "002");
            Assert.AreEqual(card.first_name, "John");
            Assert.AreEqual(card.last_name, "Doe");
            Assert.AreEqual(card.expire_month, 01);
            Assert.AreEqual(card.expire_year, 2015);
            Assert.AreEqual(card.cvv2, "962");
            Assert.AreEqual(card.payer_id, "008");
            Assert.AreEqual(card.state, "New York");
            Assert.AreEqual(GetAddress().city, card.billing_address.city);
            Assert.AreEqual(GetAddress().country_code, card.billing_address.country_code);
            Assert.AreEqual(GetAddress().line1, card.billing_address.line1);
            Assert.AreEqual(GetAddress().line2, card.billing_address.line2);
            Assert.AreEqual(GetAddress().phone, card.billing_address.phone);
            Assert.AreEqual(GetAddress().postal_code, card.billing_address.postal_code);
            Assert.AreEqual(GetAddress().state, card.billing_address.state);
        }

        [TestMethod()]        
        public void ConvertToJsonTest()
        {
            CreditCard card = GetCreditCard();
            string jsonString = card.ConvertToJson();
            CreditCard credit = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.IsNotNull(credit);
        }

        [TestMethod()]
        public void CreditCardGetTest()
        {
            CreditCard card = GetCreditCard();
            CreditCard createdCreditCard = card.Create(AccessToken);
            CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, createdCreditCard.id);
            Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
        }

        [TestMethod()]
        public void CreditCardDeleteTest()
        {
            CreditCard card = GetCreditCard();
            CreditCard createdCreditCard = card.Create(AccessToken);
            CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, createdCreditCard.id);
            retrievedCreditCard.Delete(AccessToken);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException), "Value cannot be null. Parameter name: creditCardId cannot be null")]
        public void GetCreditCardForNullIdTest()
        {
            CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, null);
        }
    }
}
