using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

        private List<Links> GetLinkList()
        {
            Links lnk = new Links();
            lnk.href = "http://www.paypal.com";
            lnk.method = "POST";
            lnk.rel = "authorize";
            List<Links> lnks = new List<Links>();
            lnks.Add(lnk);
            return lnks;
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
        public void StateTest()
        {
            CreditCard card = GetCreditCard();
            string expected = "New York";
            string actual = card.state;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PayerIdTest()
        {
            CreditCard card = GetCreditCard();
            string expected = "008";
            string actual = card.payer_id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NumberTest()
        {
            CreditCard card = GetCreditCard();
            string expected = "4825854086744369";
            string actual = card.number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LastNameTest()
        {
            CreditCard card = GetCreditCard();
            string expected = "Doe";
            string actual = card.last_name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IdTest()
        {
            CreditCard card = GetCreditCard();
            string expected = "002";
            string actual = card.id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FirstNameTest()
        {
            CreditCard card = GetCreditCard();
            string expected = "John";
            string actual = card.first_name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpireYearTest()
        {
            CreditCard card = GetCreditCard();
            int expected = 2015;
            int actual = card.expire_year;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExpireMonthTest()
        {
            CreditCard card = GetCreditCard();
            int expected = 01;
            int actual = card.expire_month;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Cvv2Test()
        {
            CreditCard card = GetCreditCard();
            string expected = "962";
            string actual = card.cvv2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BillingAddressTest()
        {
            CreditCard card = GetCreditCard();
            Address expected = GetAddress();
            Address actual = card.billing_address;
            Assert.AreEqual(expected.city, actual.city);
            Assert.AreEqual(expected.country_code, actual.country_code);
            Assert.AreEqual(expected.line1, actual.line1);
            Assert.AreEqual(expected.line2, actual.line2);
            Assert.AreEqual(expected.phone, actual.phone);
            Assert.AreEqual(expected.postal_code, actual.postal_code);
            Assert.AreEqual(expected.state, actual.state);
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
        public void CreditCardObjectTest()
        {
            CreditCard card = new CreditCard();
            Assert.IsNotNull(card);
        }

        [TestMethod()]
        public void CreateCreditCardTest()
        {
            CreditCard card = GetCreditCard();
            CreditCard createdCreditCard = card.Create(AccessToken);
            Assert.AreEqual("ok", createdCreditCard.state);
        }

        [TestMethod()]
        public void GetCreditCardTest()
        {
            CreditCard card = GetCreditCard();
            CreditCard createdCreditCard = card.Create(AccessToken);
            CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, createdCreditCard.id);
            Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
        }

        [TestMethod()]
        public void DeleteCreditCardTest()
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
