using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;
using PayPal;

namespace PayPal.Testing
{
    [TestClass]
    public class RefundTest : BaseTest
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

        [TestMethod, TestCategory("Unit")]
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

        [TestMethod, TestCategory("Functional")]
        public void RefundIdTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var pay = PaymentTest.CreatePaymentAuthorization(apiContext);
                this.RecordConnectionDetails();

                var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
                var authorization = Authorization.Get(apiContext, authorizationId);
                this.RecordConnectionDetails();

                var cap = new Capture
                {
                    amount = new Amount
                    {
                        total = "1",
                        currency = "USD"
                    }
                };
                var response = authorization.Capture(apiContext, cap);
                this.RecordConnectionDetails();

                var fund = new Refund
                {
                    amount = new Amount
                    {
                        total = "1",
                        currency = "USD"
                    }
                };
                var responseRefund = response.Refund(apiContext, fund);
                this.RecordConnectionDetails();

                var retrievedRefund = Refund.Get(apiContext, responseRefund.id);
                this.RecordConnectionDetails();

                Assert.AreEqual(responseRefund.id, retrievedRefund.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void RefundNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Refund.Get(new APIContext("token"), null));
        }

        [TestMethod, TestCategory("Unit")]
        public void RefundConvertToJsonTest()
        {
            Assert.IsFalse(GetRefund().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void RefundToStringTest()
        {
            Assert.IsFalse(GetRefund().ToString().Length == 0);
        }
    }
}
