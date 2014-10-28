using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for InvoiceTest
    /// </summary>
    [TestClass]
    public class InvoiceTest
    {
        public static readonly string InvoiceJson =
            "{\"merchant_info\":" + MerchantInfoTest.MerchantInfoJson + "," +
            "\"billing_info\":[{\"email\":\"example@example.com\"}]," +
            "\"items\":[" + InvoiceItemTest.InvoiceItemJson + "]," +
            "\"note\":\"Medical Invoice 16 Jul, 2013 PST\"," +
            "\"payment_term\":{\"term_type\":\"NET_45\"}," +
            "\"shipping_info\":" + ShippingInfoTest.ShippingInfoJson + "}";

        public static Invoice GetInvoice()
        {
            return JsonFormatter.ConvertFromJson<Invoice>(InvoiceJson);
        }

        [TestMethod()]
        public void InvoiceObjectTest()
        {
            var testObject = GetInvoice();
            Assert.IsNotNull(testObject.merchant_info);
            Assert.IsNotNull(testObject.billing_info);
            Assert.IsTrue(testObject.billing_info.Count == 1);
            Assert.IsNotNull(testObject.items);
            Assert.IsTrue(testObject.items.Count == 1);
            Assert.IsNotNull(testObject.shipping_info);
            Assert.AreEqual("Medical Invoice 16 Jul, 2013 PST", testObject.note);
            Assert.IsNotNull(testObject.payment_term);
        }

        [TestMethod()]
        public void InvoiceConvertToJsonTest()
        {
            Assert.IsFalse(GetInvoice().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void InvoiceToStringTest()
        {
            Assert.IsFalse(GetInvoice().ToString().Length == 0);
        }

        [TestMethod()]
        public void InvoiceCreateTest()
        {
            var invoice = GetInvoice();
            invoice.merchant_info.address.phone = null;
            invoice.shipping_info.address.phone = null;
            var createdInvoice = invoice.Create(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(createdInvoice.id);
            Assert.AreEqual(invoice.note, createdInvoice.note);
        }
    }
}
