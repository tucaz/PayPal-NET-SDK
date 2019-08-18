using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for InvoiceTest
    /// </summary>
    
    public class InvoiceTest : BaseTest
    {
        public static readonly string InvoiceJson =
            "{\"merchant_info\":" + MerchantInfoTest.MerchantInfoJson + "," +
            "\"billing_info\":[{\"email\":\"example@example.com\"}]," +
            "\"items\":[" + InvoiceItemTest.InvoiceItemJson + "]," +
            "\"note\":\"Medical Invoice 16 Jul, 2013 PST\"," +
            "\"allow_partial_payment\":true," +
            "\"payment_term\":{\"term_type\":\"NET_45\"}," +
            "\"minimum_amount_due\":" + CurrencyTest.CurrencyJson + "," + 
            "\"gratuity\":" + CurrencyTest.CurrencyJson + "," + 
            "\"shipping_info\":" + ShippingInfoTest.ShippingInfoJson + "}";

        public static Invoice GetInvoice()
        {
            return JsonFormatter.ConvertFromJson<Invoice>(InvoiceJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void InvoiceObjectTest()
        {
            var testObject = GetInvoice();
            Assert.NotNull(testObject.merchant_info);
            Assert.NotNull(testObject.billing_info);
            Assert.True(testObject.billing_info.Count == 1);
            Assert.NotNull(testObject.items);
            Assert.True(testObject.items.Count == 1);
            Assert.NotNull(testObject.shipping_info);
            Assert.Equal("Medical Invoice 16 Jul, 2013 PST", testObject.note);
            Assert.NotNull(testObject.payment_term);
            Assert.Equal(testObject.allow_partial_payment, true);
            Assert.Equal(testObject.minimum_amount_due.value, CurrencyTest.GetCurrency().value);
            Assert.Equal(testObject.gratuity.value, CurrencyTest.GetCurrency().value);
        }

        [Fact, Trait("Category", "Unit")]
        public void InvoiceConvertToJsonTest()
        {
            Assert.False(GetInvoice().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void InvoiceToStringTest()
        {
            Assert.False(GetInvoice().ToString().Length == 0);
        }

        [Fact(Skip="Ignore")]
        public void InvoiceCreateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var invoice = GetInvoice();
                invoice.merchant_info.address.phone = null;
                invoice.shipping_info.address.phone = null;
                var createdInvoice = invoice.Create(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(createdInvoice.id);
                Assert.Equal(invoice.note, createdInvoice.note);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [Fact(Skip="Ignore")]
        public void InvoiceQrCodeTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var invoice = GetInvoice();
                var createdInvoice = invoice.Create(apiContext);
                this.RecordConnectionDetails();

                var qrCode = Invoice.QrCode(apiContext, createdInvoice.id);
                this.RecordConnectionDetails();

                Assert.NotNull(qrCode);
                Assert.True(!string.IsNullOrEmpty(qrCode.image));

                createdInvoice.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }
    }
}
