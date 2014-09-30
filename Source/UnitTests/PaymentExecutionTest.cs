using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentExecutionTest
    {
        [TestMethod()]
        public void TestPaymentExecution()
        {
            var execution = UnitTestUtil.GetPaymentExecution();
            Assert.AreEqual(execution.payer_id, "100");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var execution = UnitTestUtil.GetPaymentExecution();
            Assert.IsFalse(execution.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var execution = UnitTestUtil.GetPaymentExecution();
            Assert.IsFalse(execution.ToString().Length == 0);
        }
    }
}
