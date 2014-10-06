using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentExecutionTest
    {
        public static PaymentExecution GetPaymentExecution()
        {
            List<Transactions> transactions = new List<Transactions>();
            transactions.Add(TransactionsTest.GetTransactions());
            PaymentExecution execution = new PaymentExecution();
            execution.payer_id = PayerInfoTest.GetPayerInfo().payer_id;
            execution.transactions = transactions;
            return execution;
        }

        [TestMethod()]
        public void PaymentExecutionObjectTest()
        {
            var execution = GetPaymentExecution();
            Assert.AreEqual(execution.payer_id, "100");
        }

        [TestMethod()]
        public void PaymentExecutionConvertToJsonTest()
        {
            Assert.IsFalse(GetPaymentExecution().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PaymentExecutionToStringTest()
        {
            Assert.IsFalse(GetPaymentExecution().ToString().Length == 0);
        }
    }
}
