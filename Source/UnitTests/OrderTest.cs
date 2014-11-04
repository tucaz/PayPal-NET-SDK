using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    /// <summary>
    /// Summary description for OrderTest
    /// </summary>
    [TestClass]
    public class OrderTest
    {
        public static Order GetOrder()
        {
            var order = new Order();
            order.amount = AmountTest.GetAmount();
            return order;
        }

        [TestMethod()]
        public void OrderObjectTest()
        {
            var order = GetOrder();
            Assert.IsNotNull(order.amount);
        }

        [TestMethod()]
        public void OrderConvertToJsonTest()
        {
            Assert.IsFalse(GetOrder().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void OrderToStringTest()
        {
            Assert.IsFalse(GetOrder().ToString().Length == 0);
        }

        [TestMethod()]
        public void OrderGetTest()
        {
            var orderId = "O-2HT09787H36911800";
            var order = Order.Get(UnitTestUtil.GetApiContext(), orderId);
            Assert.AreEqual(orderId, order.id);
        }

        /// <summary>
        /// Tests that use this method must be ignored when run in an automated environment because executing an order
        /// will require approval via the executed payment's approval_url.
        /// </summary>
        /// <returns></returns>
        private Order GetExecutedPaymentOrder(PayPal.Api.APIContext apiContext)
        {
            var pay = PaymentTest.CreatePaymentOrder();
            var paymentExecution = PaymentExecutionTest.GetPaymentExecution();
            paymentExecution.payer_id = pay.id;
            paymentExecution.transactions[0].amount.details = null;
            var executedPayment = pay.Execute(apiContext, paymentExecution);
            var orderId = executedPayment.transactions[0].related_resources[0].order.id;
            return Order.Get(apiContext, orderId);
        }

        [Ignore()]
        public void OrderAuthorizeTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var order = GetExecutedPaymentOrder(apiContext);

            // Authorize the order and verify it was successful (goes to 'Pending' state)
            var response = order.Authorize(apiContext);
            Assert.AreEqual("Pending", response.state);
        }

        [Ignore()]
        public void OrderCaptureTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var order = GetExecutedPaymentOrder(apiContext);

            // Capture a payment for the order and verify it completed successfully
            var capture = CaptureTest.GetCapture();
            var response = order.Capture(apiContext, capture);
            Assert.AreEqual("completed", response.state);
        }

        [Ignore()]
        public void OrderDoVoidTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var order = GetExecutedPaymentOrder(apiContext);

            // Void the order and verify it was successfully voided
            var response = order.Void(apiContext);
            Assert.AreEqual("voided", response.state);
        }

        [Ignore()]
        public void OrderRefundTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var order = GetExecutedPaymentOrder(apiContext);

            // Refund the order and verify it completed successfully
            var refund = RefundTest.GetRefund();
            var response = order.Refund(UnitTestUtil.GetApiContext(), refund);
            Assert.AreEqual("completed", response.state);
        }
    }
}
