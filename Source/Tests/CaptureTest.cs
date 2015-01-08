using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;
using PayPal;

namespace PayPal.Testing
{
    [TestClass()]
    public class CaptureTest
    {
        public static readonly string CaptureJson =
            "{\"amount\":" + AmountTest.AmountJson + "," +
            "\"create_time\":\"2013-01-15T15:10:05.123Z\"," +
            "\"id\":\"001\"," +
            "\"parent_payment\":\"1000\"," +
            "\"state\":\"Authorized\"," +
            "\"links\":[" + LinksTest.LinksJson + "]}";

        public static Capture GetCapture()
        {
            return JsonFormatter.ConvertFromJson<Capture>(CaptureJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void CaptureObjectTest()
        {
            var cap = GetCapture();
            var expected = AmountTest.GetAmount();
            var actual = cap.amount;
            Assert.AreEqual(expected.currency, actual.currency);
            Assert.AreEqual(expected.details.fee, actual.details.fee);
            Assert.AreEqual(expected.details.shipping, actual.details.shipping);
            Assert.AreEqual(expected.details.subtotal, actual.details.subtotal);
            Assert.AreEqual(expected.details.tax, actual.details.tax);
            Assert.AreEqual(expected.total, actual.total);
            Assert.AreEqual(cap.create_time, "2013-01-15T15:10:05.123Z");
            Assert.AreEqual("001", cap.id);
            Assert.AreEqual("1000", cap.parent_payment);
            Assert.AreEqual("Authorized", cap.state);
        }

        [TestMethod, TestCategory("Unit")]
        public void CaptureConvertToJsonTest()
        {
            var cap = GetCapture();
            Assert.IsFalse(cap.ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void CaptureToStringTest()
        {
            var cap = GetCapture();
            Assert.IsFalse(cap.ToString().Length == 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void CaptureIdTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorization = Authorization.Get(TestingUtil.GetApiContext(), authorizationId);
            var cap = new Capture();
            var amt = new Amount();
            amt.total = "1";
            amt.currency = "USD";
            cap.amount = amt;
            var responseCapture = authorization.Capture(TestingUtil.GetApiContext(), cap);
            var returnCapture = Capture.Get(TestingUtil.GetApiContext(), responseCapture.id);
            Assert.AreEqual(responseCapture.id, returnCapture.id);
        }

        [TestMethod, TestCategory("Functional")]
        public void CaptureRefundTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorization = Authorization.Get(TestingUtil.GetApiContext(), authorizationId);
            var cap = new Capture();
            var amnt = new Amount();
            amnt.total = "1";
            amnt.currency = "USD";
            cap.amount = amnt;
            var response = authorization.Capture(TestingUtil.GetApiContext(), cap);
            var fund = new Refund();
            var refundAmount = new Amount();
            refundAmount.total = "1";
            refundAmount.currency = "USD";
            fund.amount = refundAmount;
            var responseRefund = response.Refund(TestingUtil.GetApiContext(), fund);
            Assert.AreEqual("completed", responseRefund.state);
        }

        [TestMethod, TestCategory("Unit")]
        public void CaptureNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Capture.Get(new APIContext("token"), null));
        } 
    }
}
