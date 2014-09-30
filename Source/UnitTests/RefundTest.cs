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
        [TestMethod()]
        public void RefundIdTest()
        {
            var pay = UnitTestUtil.CreatePaymentAuthorization();
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
        public void NullRefundIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Refund.Get(UnitTestUtil.GetApiContext(), null));
        }
    }
}
