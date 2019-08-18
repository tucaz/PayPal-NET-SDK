using System.Collections.Generic;
using PayPal.Api;
using PayPal;
using Xunit;


namespace PayPal.Testing
{
    
    public class CaptureTest : BaseTest
    {
        public static readonly string CaptureJson =
            "{\"amount\":" + AmountTest.AmountJson + "," +
            "\"create_time\":\"" + TestingUtil.GetCurrentDateISO() + "\"," +
            "\"id\":\"001\"," +
            "\"parent_payment\":\"1000\"," +
            "\"state\":\"COMPLETED\"," +
            "\"links\":[" + LinksTest.LinksJson + "]}";

        public static Capture GetCapture()
        {
            return JsonFormatter.ConvertFromJson<Capture>(CaptureJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void CaptureObjectTest()
        {
            var cap = GetCapture();
            var expected = AmountTest.GetAmount();
            var actual = cap.amount;
            Assert.Equal(expected.currency, actual.currency);
            Assert.Equal(expected.details.fee, actual.details.fee);
            Assert.Equal(expected.details.shipping, actual.details.shipping);
            Assert.Equal(expected.details.subtotal, actual.details.subtotal);
            Assert.Equal(expected.details.tax, actual.details.tax);
            Assert.Equal(expected.total, actual.total);
            Assert.NotNull(cap.create_time);
            Assert.Equal("001", cap.id);
            Assert.Equal("1000", cap.parent_payment);
            Assert.Equal("COMPLETED", cap.state);
        }

        [Fact, Trait("Category", "Unit")]
        public void CaptureConvertToJsonTest()
        {
            var cap = GetCapture();
            Assert.False(cap.ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void CaptureToStringTest()
        {
            var cap = GetCapture();
            Assert.False(cap.ToString().Length == 0);
        }

        [Fact, Trait("Category", "Functional")]
        public void CaptureIdTest()
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
                var responseCapture = authorization.Capture(apiContext, cap);
                this.RecordConnectionDetails();

                Assert.NotNull(responseCapture);

                var returnCapture = Capture.Get(apiContext, responseCapture.id);
                this.RecordConnectionDetails();

                Assert.Equal(responseCapture.id, returnCapture.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void CaptureRefundTest()
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

                Assert.Equal("completed", responseRefund.state);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void CaptureNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Capture.Get(new APIContext("token"), null));
        } 
    }
}
