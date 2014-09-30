using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class CreditCardTokenTest
    {
        [TestMethod()]
        public void TestCreditCardToken()
        {
            var token = UnitTestUtil.GetCreditCardToken();
            Assert.AreEqual(token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(token.payer_id, "009");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var token = UnitTestUtil.GetCreditCardToken();
            string expected = "{\"credit_card_id\":\"CARD-8PV12506MG6587946KEBHH4A\",\"payer_id\":\"009\",\"expire_month\":10,\"expire_year\":2015}";
            string actual = token.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToStringTest()
        {
            var token = UnitTestUtil.GetCreditCardToken();
            Assert.IsFalse(token.ToString().Length == 0);
        }
    }
}
