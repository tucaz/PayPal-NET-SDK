using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class CreditCardTokenTest
    {
        public static CreditCardToken GetCreditCardToken()
        {
            CreditCardToken cardToken = new CreditCardToken();
            cardToken.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            cardToken.payer_id = "009";
            cardToken.expire_month = 10;
            cardToken.expire_year = 2015;
            return cardToken;
        }

        [TestMethod, TestCategory("Unit")]
        public void CreditCardTokenObjectTest()
        {
            var token = GetCreditCardToken();
            Assert.AreEqual(token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(token.payer_id, "009");
        }

        [TestMethod, TestCategory("Unit")]
        public void CreditCardTokenConvertToJsonTest()
        {
            var token = GetCreditCardToken();
            string expected = "{\"credit_card_id\":\"CARD-8PV12506MG6587946KEBHH4A\",\"payer_id\":\"009\",\"expire_month\":10,\"expire_year\":2015}";
            string actual = token.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Unit")]
        public void CreditCardTokenToStringTest()
        {
            Assert.IsFalse(GetCreditCardToken().ToString().Length == 0);
        }
    }
}
