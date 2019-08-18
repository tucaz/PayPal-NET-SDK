using System.Collections.Generic;

using PayPal.Api;
using System;
using System.Net;
using Xunit;


namespace PayPal.Testing
{
    
    public class SaleTest : BaseTest
    {
        public static readonly string SaleJson =
            "{\"amount\":" + AmountTest.AmountJson + "," +
            "\"parent_payment\":\"103\"," +
            "\"state\":\"completed\"," +
            "\"create_time\":\"" + TestingUtil.GetCurrentDateISO() + "\"," +
            "\"links\":[" + LinksTest.LinksJson + "]}";

        public static Sale GetSale()
        {
            return JsonFormatter.ConvertFromJson<Sale>(SaleJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void SaleObjectTest()
        {
            var sale = GetSale();
            Assert.Equal("103", sale.parent_payment);
            Assert.Equal("completed", sale.state);
            Assert.NotNull(sale.create_time);
            Assert.NotNull(sale.amount);
            Assert.NotNull(sale.links);
        }

        [Fact, Trait("Category", "Unit")]
        public void SaleNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Sale.Get(new APIContext("token"), null));
        }

        [Fact, Trait("Category", "Unit")]
        public void SaleConvertToJsonTest()
        {
            Assert.False(GetSale().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void SaleToStringTest()
        {
            Assert.False(GetSale().ToString().Length == 0);
        }

        [Fact(Skip="Ignore")]
        public void SaleGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var saleId = "4V7971043K262623A";
                var sale = Sale.Get(apiContext, saleId);
                this.RecordConnectionDetails();

                Assert.NotNull(sale);
                Assert.Equal(saleId, sale.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void SaleRefundTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a credit card sale payment
                var payment = PaymentTest.CreatePaymentForSale(apiContext);
                this.RecordConnectionDetails();

                // Get the sale resource
                var sale = payment.transactions[0].related_resources[0].sale;

                var refund = new Refund
                {
                    amount = new Amount
                    {
                        currency = "USD",
                        total = "0.01"
                    }
                };

                apiContext.ResetRequestId();
                var response = sale.Refund(apiContext, refund);
                this.RecordConnectionDetails();

                Assert.NotNull(response);
                Assert.Equal("completed", response.state);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
