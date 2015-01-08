using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class PaymentExecutionTest
    {
        public static PaymentExecution GetPaymentExecution()
        {
            var transactions = new List<Transaction>();
            transactions.Add(TransactionTest.GetTransaction());
            PaymentExecution execution = new PaymentExecution();
            execution.payer_id = PayerInfoTest.GetPayerInfo().payer_id;
            execution.transactions = transactions;
            return execution;
        }

        [TestMethod, TestCategory("Unit")]
        public void PaymentExecutionObjectTest()
        {
            var execution = GetPaymentExecution();
            Assert.AreEqual(execution.payer_id, "100");
        }

        [TestMethod, TestCategory("Unit")]
        public void PaymentExecutionConvertToJsonTest()
        {
            Assert.IsFalse(GetPaymentExecution().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PaymentExecutionToStringTest()
        {
            Assert.IsFalse(GetPaymentExecution().ToString().Length == 0);
        }
    }
}
