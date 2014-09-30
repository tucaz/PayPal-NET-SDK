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
        [TestMethod()]
        public void TestPayer()
        {
            var pay = UnitTestUtil.GetPayer();
            Assert.AreEqual(pay.payment_method, "credit_card");
            Assert.AreEqual(pay.funding_instruments[0].credit_card_token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(pay.payer_info.first_name, "Joe");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var pay = UnitTestUtil.GetPayer();
            Assert.IsFalse(pay.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var pay = UnitTestUtil.GetPayer();
            Assert.IsFalse(pay.ToString().Length == 0);
        }
    }    
}
