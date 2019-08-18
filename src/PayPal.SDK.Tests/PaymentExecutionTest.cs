
using System.Collections.Generic;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
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

        [Fact, Trait("Category", "Unit")]
        public void PaymentExecutionObjectTest()
        {
            var execution = GetPaymentExecution();
            Assert.Equal(execution.payer_id, "100");
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentExecutionConvertToJsonTest()
        {
            Assert.False(GetPaymentExecution().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentExecutionToStringTest()
        {
            Assert.False(GetPaymentExecution().ToString().Length == 0);
        }
    }
}
