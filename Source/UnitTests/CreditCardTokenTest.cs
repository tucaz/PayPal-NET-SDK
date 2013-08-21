using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class CreditCardTokenTest
    {
        private CreditCardToken GetCreditCardToken()
        {
            CreditCardToken cardToken = new CreditCardToken();
            cardToken.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            cardToken.payer_id = "009";
            cardToken.expire_month = 10;
            cardToken.expire_year = 2015;
            return cardToken;
        }

        [TestMethod()]
        public void PayerIdTest()
        {
            CreditCardToken target = GetCreditCardToken();
            string expected = "009";
            string actual = target.payer_id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreditCardIdTest()
        {
            CreditCardToken target = GetCreditCardToken();
            string expected = "CARD-8PV12506MG6587946KEBHH4A";
            string actual = target.credit_card_id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            CreditCardToken target = GetCreditCardToken();
            string expected = "{\"credit_card_id\":\"CARD-8PV12506MG6587946KEBHH4A\",\"payer_id\":\"009\",\"expire_month\":10,\"expire_year\":2015}";
            string actual = target.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToString()
        {
            CreditCardToken token = GetCreditCardToken();
            Assert.IsFalse(token.ToString().Length == 0);
        }
    }
}
