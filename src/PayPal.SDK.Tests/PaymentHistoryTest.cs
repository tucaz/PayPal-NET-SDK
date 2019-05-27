using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
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

        [TestMethod, TestCategory("Unit")]
        public void PaymentHistoryObjectTest()
        {
            var history = GetPaymentHistory();
            Assert.AreEqual(history.count, 1);
            Assert.AreEqual(history.next_id, "1");
            Assert.AreEqual(history.payments.Count, 1);
        }

        [TestMethod, TestCategory("Unit")]
        public void PaymentHistoryConvertToJsonTest()
        {
            Assert.IsFalse(GetPaymentHistory().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PaymentHistoryToStringTest()
        {
            Assert.IsFalse(GetPaymentHistory().ToString().Length == 0);
        }
    }
}
