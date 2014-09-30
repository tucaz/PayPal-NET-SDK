using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal;
using PayPal.Manager;
using PayPal.Util;
using System;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentTest
    {
        [TestMethod()]
        public void PaymentStateTest()
        {
            var actual = UnitTestUtil.CreatePaymentForSale();
            Assert.AreEqual("approved", actual.state);
        }

        [TestMethod()]
        public void PaymentNullAccessToken()
        {
            var payment = UnitTestUtil.GetPaymentForSale();
            string accessToken = null;
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => payment.Create(accessToken));
        }

        [TestMethod()]
        public void TestPayment()
        {
            var context = UnitTestUtil.GetApiContext();
            var pay = UnitTestUtil.CreatePaymentForSale();
            var retrievedPayment = Payment.Get(context, pay.id);
            Assert.AreEqual(pay.id, retrievedPayment.id);
        }

        [TestMethod()]
        public void PaymentHistoryTest()
        {
            var context = UnitTestUtil.GetApiContext();
            var containerDictionary = new Dictionary<string, string>();
            containerDictionary.Add("count", "10");
            var paymentHistory = Payment.List(context, containerDictionary);
            Assert.AreEqual(10, paymentHistory.count);
        }

        [TestMethod()]
        public void FuturePaymentTest()
        {
            var context = UnitTestUtil.GetApiContext();
            var futurePayment = UnitTestUtil.GetFuturePayment();
            var retrievedPayment = FuturePayment.Get(context, futurePayment.id);
            Assert.AreEqual(futurePayment.id, retrievedPayment.id);
        }
    }
}
