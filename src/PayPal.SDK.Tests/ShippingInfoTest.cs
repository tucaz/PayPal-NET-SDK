using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for ShippingInfoTest
    /// </summary>
    
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

        [Fact, Trait("Category", "Unit")]
        public void ShippingInfoObjectTest()
        {
            var testObject = GetShippingInfo();
            Assert.Equal("Sally", testObject.first_name);
            Assert.Equal("Patient", testObject.last_name);
            Assert.Equal("Not applicable", testObject.business_name);
            Assert.NotNull(testObject.address);
        }

        [Fact, Trait("Category", "Unit")]
        public void ShippingInfoConvertToJsonTest()
        {
            Assert.False(GetShippingInfo().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void ShippingInfoToStringTest()
        {
            Assert.False(GetShippingInfo().ToString().Length == 0);
        }
    }
}
