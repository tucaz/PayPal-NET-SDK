
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
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

        [Fact, Trait("Category", "Unit")]
        public void CreditCardTokenObjectTest()
        {
            var token = GetCreditCardToken();
            Assert.Equal(token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.Equal(token.payer_id, "009");
        }

        [Fact, Trait("Category", "Unit")]
        public void CreditCardTokenConvertToJsonTest()
        {
            var token = GetCreditCardToken();
            string expected = "{\"credit_card_id\":\"CARD-8PV12506MG6587946KEBHH4A\",\"payer_id\":\"009\",\"expire_month\":10,\"expire_year\":2015}";
            string actual = token.ConvertToJson();
            Assert.Equal(expected, actual);
        }

        [Fact, Trait("Category", "Unit")]
        public void CreditCardTokenToStringTest()
        {
            Assert.False(GetCreditCardToken().ToString().Length == 0);
        }
    }
}
