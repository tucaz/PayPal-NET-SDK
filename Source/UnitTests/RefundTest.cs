using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class RefundTest
    {
        public static Refund GetRefund()
        {
            var refund = new Refund();
            refund.capture_id = "101";
            refund.id = "102";
            refund.parent_payment = "103";
            refund.sale_id = "104";
            refund.state = "Approved";
            refund.amount = AmountTest.GetAmount();
            refund.create_time = "2013-01-17T18:12:02.347Z";
            refund.links = LinksTest.GetLinksList();
            return refund;
        }

        [TestMethod()]
        public void RefundObjectTest()
        {
            var refund = GetRefund();
            Assert.AreEqual("101", refund.capture_id);
            Assert.AreEqual("102", refund.id);
            Assert.AreEqual("103", refund.parent_payment);
            Assert.AreEqual("104", refund.sale_id);
            Assert.AreEqual("Approved", refund.state);
            Assert.AreEqual("2013-01-17T18:12:02.347Z", refund.create_time);
            Assert.IsNotNull(refund.amount);
            Assert.IsNotNull(refund.links);
        }

        [TestMethod()]
        public void RefundIdTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorization = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            var cap = new Capture();
            var amt = new Amount();
            amt.total = "1";
            amt.currency = "USD";
            cap.amount = amt;
            var response = authorization.Capture(UnitTestUtil.GetApiContext(), cap);
            var fund = new Refund();
            var refundAmount = new Amount();
            refundAmount.total = "1";
            refundAmount.currency = "USD";
            fund.amount = refundAmount;
            var responseRefund = response.Refund(UnitTestUtil.GetApiContext(), fund);
            var retrievedRefund = Refund.Get(UnitTestUtil.GetApiContext(), responseRefund.id);
            Assert.AreEqual(responseRefund.id, retrievedRefund.id);
        }

        [TestMethod()]
        public void RefundNullIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Refund.Get(UnitTestUtil.GetApiContext(), null));
        }

        [TestMethod()]
        public void RefundConvertToJsonTest()
        {
            Assert.IsFalse(GetRefund().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void RefundToStringTest()
        {
            Assert.IsFalse(GetRefund().ToString().Length == 0);
        }
    }
}
