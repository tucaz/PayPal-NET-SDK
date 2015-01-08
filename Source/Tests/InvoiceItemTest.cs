using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using PayPal;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for InvoiceItemTest
    /// </summary>
    [TestClass]
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

        [TestMethod, TestCategory("Unit")]
        public void InvoiceItemObjectTest()
        {
            var testObject = GetInvoiceItem();
            Assert.AreEqual("Sutures", testObject.name);
            Assert.AreEqual(100, testObject.quantity);
            Assert.IsNotNull(testObject.unit_price);
        }

        [TestMethod, TestCategory("Unit")]
        public void InvoiceItemConvertToJsonTest()
        {
            Assert.IsFalse(GetInvoiceItem().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void InvoiceItemToStringTest()
        {
            Assert.IsFalse(GetInvoiceItem().ToString().Length == 0);
        }
    }
}
