using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for ShippingInfoTest
    /// </summary>
    [TestClass]
    public class ShippingInfoTest
    {
        public static readonly string ShippingInfoJson =
            "{\"first_name\":\"Sally\"," +
            "\"last_name\":\"Patient\"," +
            "\"business_name\":\"Not applicable\"," +
            "\"address\":" + InvoiceAddressTest.InvoiceAddressJson + "}";

        public static ShippingInfo GetShippingInfo()
        {
            return JsonFormatter.ConvertFromJson<ShippingInfo>(ShippingInfoJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShippingInfoObjectTest()
        {
            var testObject = GetShippingInfo();
            Assert.AreEqual("Sally", testObject.first_name);
            Assert.AreEqual("Patient", testObject.last_name);
            Assert.AreEqual("Not applicable", testObject.business_name);
            Assert.IsNotNull(testObject.address);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShippingInfoConvertToJsonTest()
        {
            Assert.IsFalse(GetShippingInfo().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShippingInfoToStringTest()
        {
            Assert.IsFalse(GetShippingInfo().ToString().Length == 0);
        }
    }
}
