
using System.Collections.Generic;
using PayPal;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PaymentHistoryTest
    {
        public static PaymentHistory GetPaymentHistory()
        {
            List<Payment> paymentList = new List<Payment>();
            paymentList.Add(PaymentTest.GetPaymentForSale());
            PaymentHistory history = new PaymentHistory();
            history.count = 1;
            history.payments = paymentList;
            history.next_id = "1";
            return history;
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentHistoryObjectTest()
        {
            var history = GetPaymentHistory();
            Assert.Equal(history.count, 1);
            Assert.Equal(history.next_id, "1");
            Assert.Equal(history.payments.Count, 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentHistoryConvertToJsonTest()
        {
            Assert.False(GetPaymentHistory().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentHistoryToStringTest()
        {
            Assert.False(GetPaymentHistory().ToString().Length == 0);
        }
    }
}
