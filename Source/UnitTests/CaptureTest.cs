using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;
using PayPal;

namespace PayPal.UnitTest
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

        [TestMethod()]
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

        [TestMethod()]
        public void CaptureConvertToJsonTest()
        {
            var cap = GetCapture();
            Assert.IsFalse(cap.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void CaptureToStringTest()
        {
            var cap = GetCapture();
            Assert.IsFalse(cap.ToString().Length == 0);
        }

        [TestMethod()]
        public void CaptureIdTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorization = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            var cap = new Capture();
            var amt = new Amount();
            amt.total = "1";
            amt.currency = "USD";
            cap.amount = amt;
            var responseCapture = authorization.Capture(UnitTestUtil.GetApiContext(), cap);
            var returnCapture = Capture.Get(UnitTestUtil.GetApiContext(), responseCapture.id);
            Assert.AreEqual(responseCapture.id, returnCapture.id);
        }

        [TestMethod()]
        public void CaptureRefundTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorization = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            var cap = new Capture();
            var amnt = new Amount();
            amnt.total = "1";
            amnt.currency = "USD";
            cap.amount = amnt;
            var response = authorization.Capture(UnitTestUtil.GetApiContext(), cap);
            var fund = new Refund();
            var refundAmount = new Amount();
            refundAmount.total = "1";
            refundAmount.currency = "USD";
            fund.amount = refundAmount;
            var responseRefund = response.Refund(UnitTestUtil.GetApiContext(), fund);
            Assert.AreEqual("completed", responseRefund.state);
        }

        [TestMethod()]
        public void CaptureNullIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Capture.Get(UnitTestUtil.GetApiContext(), null));
        } 
    }
}
