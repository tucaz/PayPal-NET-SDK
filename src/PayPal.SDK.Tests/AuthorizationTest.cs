
using System.Collections.Generic;
using PayPal.Api;
using PayPal;
using Xunit;


namespace PayPal.Testing
{
    
    public class AuthorizationTest : BaseTest
    {
        public static readonly string AuthorizationJson =
            "{\"amount\":" + AmountTest.AmountJson + "," +
            "\"create_time\":\"" + TestingUtil.GetCurrentDateISO() + "\"," +
            "\"id\":\"007\"," +
            "\"parent_payment\":\"1000\"," +
            "\"state\":\"Authorized\"," +
            "\"links\":[" + LinksTest.LinksJson + "]}";

        public static Authorization GetAuthorization()
        {
            return JsonFormatter.ConvertFromJson<Authorization>(AuthorizationJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AuthorizationObjectTest()
        {
            var authorization = GetAuthorization();
            Assert.Equal(authorization.id, "007");
            Assert.NotNull(authorization.create_time);
            Assert.Equal(authorization.parent_payment, "1000");
            Assert.Equal(authorization.state, "Authorized");
            Assert.NotNull(authorization.amount);
            Assert.NotNull(authorization.links);
        }

        [Fact, Trait("Category", "Unit")]
        public void AuthorizationConvertToJsonTest()
        {
            var authorize = GetAuthorization();
            Assert.False(authorize.ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void AuthorizationToStringTest()
        {
            var authorize = GetAuthorization();
            Assert.False(authorize.ToString().Length == 0);
        }

        [Fact, Trait("Category", "Functional")]
        public void AuthorizationGetTest()
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

                var authorizationId = resource.authorization.id;
                var authorize = Authorization.Get(apiContext, authorizationId);
                this.RecordConnectionDetails();

                Assert.Equal(authorizationId, authorize.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void AuthorizationCaptureTest()
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

                var authorize = Authorization.Get(apiContext, resource.authorization.id);
                this.RecordConnectionDetails();

                var cap = new Capture
                {
                    amount = new Amount
                    {
                        total = "1",
                        currency = "USD"
                    }
                };
                var response = authorize.Capture(apiContext, cap);
                this.RecordConnectionDetails();

                Assert.Equal("completed", response.state);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void AuthorizationVoidTest()
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

                var authorize = Authorization.Get(apiContext, resource.authorization.id);
                this.RecordConnectionDetails();

                var authorizationResponse = authorize.Void(apiContext);
                this.RecordConnectionDetails();

                Assert.Equal("voided", authorizationResponse.state);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void AuthorizationNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Authorization.Get(new APIContext("token"), null));
        }

        [Fact(Skip="Ignore")]
        public void AuthroizationReauthorizeTest()
        {
            var authorization = Authorization.Get(TestingUtil.GetApiContext(), "7GH53639GA425732B");
            var reauthorizeAmount = new Amount();
            reauthorizeAmount.currency = "USD";
            reauthorizeAmount.total = "1";
            authorization.amount = reauthorizeAmount;
            TestingUtil.AssertThrownException<PayPal.PaymentsException>(() => authorization.Reauthorize(TestingUtil.GetApiContext()));
        }
    }
}
