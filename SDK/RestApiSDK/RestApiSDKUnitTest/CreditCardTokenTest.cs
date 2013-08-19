using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for CreditCardTokenTest and is intended
    ///to contain all CreditCardTokenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CreditCardTokenTest
    {
        private CreditCardToken GetCreditCardToken()
        {
            CreditCardToken credCardToken = new CreditCardToken();
            credCardToken.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            credCardToken.payer_id = "009";
            credCardToken.expire_month = 10;
            credCardToken.expire_year = 2015;
            return credCardToken;
        }

        /// <summary>
        ///A test for payer_id
        ///</summary>
        [TestMethod()]
        public void payer_idTest()
        {
            CreditCardToken target = GetCreditCardToken();
            string expected = "009";
            string actual = target.payer_id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for credit_card_id
        ///</summary>
        [TestMethod()]
        public void credit_card_idTest()
        {
            CreditCardToken target = GetCreditCardToken();
            string expected = "CARD-8PV12506MG6587946KEBHH4A";
            string actual = target.credit_card_id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            CreditCardToken target = GetCreditCardToken();
            string expected = "{\"credit_card_id\":\"CARD-8PV12506MG6587946KEBHH4A\",\"payer_id\":\"009\",\"expire_month\":10,\"expire_year\":2015}";
            string actual = target.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreditCardToken Constructor
        ///</summary>
        [TestMethod()]
        public void CreditCardTokenConstructorTest()
        {
            CreditCardToken target = new CreditCardToken();
            Assert.IsNotNull(target);
        }
    }
}
