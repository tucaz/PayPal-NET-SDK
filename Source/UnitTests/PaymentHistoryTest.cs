using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentHistoryTest
    {
        [TestMethod()]
        public void TestPaymentHistory()
        {
            var history = UnitTestUtil.GetPaymentHistory();
            Assert.AreEqual(history.count, 1);
            Assert.AreEqual(history.next_id, "1");
            Assert.AreEqual(history.payments.Count, 1);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var history = UnitTestUtil.GetPaymentHistory();
            Assert.IsFalse(history.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var history = UnitTestUtil.GetPaymentHistory();
            Assert.IsFalse(history.ToString().Length == 0);
        }
    }
}
