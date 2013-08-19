using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for CreditCardTest and is intended
    ///to contain all CreditCardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CreditCardTest
    {
        private string ClientID
        {
            get
            {
                string clntID = ConfigManager.Instance.GetProperties()["ClientID"];
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

        /// <summary>
        ///A test for state
        ///</summary>
        [TestMethod()]
        public void stateTest()
        {
            CreditCard target = GetCreditCard();
            string expected = "New York";
            string actual = target.state;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for payer_id
        ///</summary>
        [TestMethod()]
        public void payer_idTest()
        {
            CreditCard target = GetCreditCard();
            string expected = "008";
            string actual = target.payer_id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for number
        ///</summary>
        [TestMethod()]
        public void numberTest()
        {
            CreditCard target = GetCreditCard();
            string expected = "4825854086744369";
            string actual = target.number;
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for last_name
        ///</summary>
        [TestMethod()]
        public void last_nameTest()
        {
            CreditCard target = GetCreditCard();
            string expected = "Doe";
            string actual = target.last_name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for id
        ///</summary>
        [TestMethod()]
        public void idTest()
        {
            CreditCard target = GetCreditCard();
            string expected = "002";
            string actual = target.id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for first_name
        ///</summary>
        [TestMethod()]
        public void first_nameTest()
        {
            CreditCard target = GetCreditCard();
            string expected = "John";
            string actual = target.first_name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for expire_year
        ///</summary>
        [TestMethod()]
        public void expire_yearTest()
        {
            CreditCard target = GetCreditCard();
            int expected = 2015;
            int actual = target.expire_year;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for expire_month
        ///</summary>
        [TestMethod()]
        public void expire_monthTest()
        {
            CreditCard target = GetCreditCard();
            int expected = 01;
            int actual = target.expire_month;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for cvv2
        ///</summary>
        [TestMethod()]
        public void cvv2Test()
        {
            CreditCard target = GetCreditCard();
            string expected = "962";
            string actual = target.cvv2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for billing_address
        ///</summary>
        [TestMethod()]
        public void billing_addressTest()
        {
            CreditCard target = GetCreditCard();
            Address expected = GetAddress();
            Address actual = target.billing_address;
            Assert.AreEqual(expected.city, actual.city);
            Assert.AreEqual(expected.country_code, actual.country_code);
            Assert.AreEqual(expected.line1, actual.line1);
            Assert.AreEqual(expected.line2, actual.line2);
            Assert.AreEqual(expected.phone, actual.phone);
            Assert.AreEqual(expected.postal_code, actual.postal_code);
            Assert.AreEqual(expected.state, actual.state);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        [TestMethod()]        
        public void ConvertToJsonTest()
        {
            CreditCard target = GetCreditCard();
            string jsonString = target.ConvertToJson();
            CreditCard credCard = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.IsNotNull(credCard);
        }

        /// <summary>
        ///A test for CreditCard Constructor
        ///</summary>
        [TestMethod()]
        public void CreditCardConstructorTest()
        {
            CreditCard target = new CreditCard();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Create Credit Card
        ///</summary>
        [TestMethod()]
        public void CreateCreditCardTest()
        {
            CreditCard creditCard = GetCreditCard();
            CreditCard createdCreditCard = creditCard.Create(AccessToken);
            Assert.AreEqual("ok", createdCreditCard.state);
        }

        /// <summary>
        ///A test for Get CreditCard
        ///</summary>
        [TestMethod()]
        public void GetCreditCardTest()
        {
            CreditCard creditCard = GetCreditCard();
            CreditCard createdCreditCard = creditCard.Create(AccessToken);
            CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, createdCreditCard.id);
            Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
        }

        /// <summary>
        ///A test for Delete CreditCard
        ///</summary>
        [TestMethod()]
        public void DeleteCreditCardTest()
        {
            CreditCard creditCard = GetCreditCard();
            CreditCard createdCreditCard = creditCard.Create(AccessToken);
            CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, createdCreditCard.id);
            retrievedCreditCard.Delete(AccessToken);
        }

        /// <summary>
        ///A test for Get CreditCard for null Id
        ///</summary>
        [TestMethod()]
        public void GetCreditCardForNullIdTest()
        {
            try
            {
                CreditCard retrievedCreditCard = CreditCard.Get(AccessToken, null);
            }
            catch (System.ArgumentNullException exe)
            {
                Assert.IsNotNull(exe);
            }
        }

    }
}
