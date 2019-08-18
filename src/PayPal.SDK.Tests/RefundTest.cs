using System.Collections.Generic;
using PayPal.Api;
using PayPal;
using Xunit;


namespace PayPal.Testing
{
    
    public class RefundTest : BaseTest
    {
        public static Refund GetRefund()
        {
            var refund = new Refund();
            refund.capture_id = "101";
            refund.id = "102";
            refund.parent_payment = "103";
            refund.sale_id = "104";
            refund.state = "COMPLETED";
            refund.amount = AmountTest.GetAmount();
            refund.create_time = TestingUtil.GetCurrentDateISO(-1);
            refund.links = LinksTest.GetLinksList();
            return refund;
        }

        [Fact, Trait("Category", "Unit")]
        public void RefundObjectTest()
        {
            var refund = GetRefund();
            Assert.Equal("101", refund.capture_id);
            Assert.Equal("102", refund.id);
            Assert.Equal("103", refund.parent_payment);
            Assert.Equal("104", refund.sale_id);
            Assert.Equal("COMPLETED", refund.state);
            Assert.NotNull(refund.create_time);
            Assert.NotNull(refund.amount);
            Assert.NotNull(refund.links);
        }

        [Fact, Trait("Category", "Functional")]
        public void RefundIdTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var pay = PaymentTest.CreatePaymentAuthorization(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(pay);
                Assert.NotNull(pay.transactions);
                Assert.True(pay.transactions.Count > 0);
                var transaction = pay.transactions[0];

                Assert.NotNull(transaction.related_resources);
                Assert.True(transaction.related_resources.Count > 0);

                var resource = transaction.related_resources[0];
                Assert.NotNull(resource.authorization);

                var authorization = Authorization.Get(apiContext, resource.authorization.id);
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

                apiContext.ResetRequestId();
                var responseRefund = response.Refund(apiContext, fund);
                this.RecordConnectionDetails();

                var retrievedRefund = Refund.Get(apiContext, responseRefund.id);
                this.RecordConnectionDetails();

                Assert.Equal(responseRefund.id, retrievedRefund.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void RefundNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Refund.Get(new APIContext("token"), null));
        }

        [Fact, Trait("Category", "Unit")]
        public void RefundConvertToJsonTest()
        {
            Assert.False(GetRefund().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void RefundToStringTest()
        {
            Assert.False(GetRefund().ToString().Length == 0);
        }
    }
}
