using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using PayPal.Api;
using PayPal;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for InvoiceItemTest
    /// </summary>
    
    public class InvoiceItemTest
    {
        public static readonly string InvoiceItemJson =
            "{\"name\":\"Sutures\"," +
            "\"quantity\":100," +
            "\"unit_price\":" + CurrencyTest.CurrencyJson + "}";

        public static InvoiceItem GetInvoiceItem()
        {
            return PayPal.Api.JsonFormatter.ConvertFromJson<InvoiceItem>(InvoiceItemJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void InvoiceItemObjectTest()
        {
            var testObject = GetInvoiceItem();
            Assert.Equal("Sutures", testObject.name);
            Assert.Equal(100, testObject.quantity);
            Assert.NotNull(testObject.unit_price);
        }

        [Fact, Trait("Category", "Unit")]
        public void InvoiceItemConvertToJsonTest()
        {
            Assert.False(GetInvoiceItem().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void InvoiceItemToStringTest()
        {
            Assert.False(GetInvoiceItem().ToString().Length == 0);
        }
    }
}
