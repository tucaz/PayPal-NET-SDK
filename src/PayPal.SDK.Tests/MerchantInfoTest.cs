using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for MerchantInfoTest
    /// </summary>
    
    public class MerchantInfoTest
    {
        public static readonly string MerchantInfoJson =
            "{\"email\":\"jziaja.test.merchant-facilitator@gmail.com\"," +
            "\"first_name\":\"Dennis\"," +
            "\"last_name\":\"Doctor\"," +
            "\"business_name\":\"Medical Professionals, LLC\"," +
            "\"phone\":" + PhoneTest.PhoneJson + "," +
            "\"address\":" + InvoiceAddressTest.InvoiceAddressJson + "}";

        public static MerchantInfo GetMerchantInfo()
        {
            return JsonFormatter.ConvertFromJson<MerchantInfo>(MerchantInfoJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void MerchantInfoObjectTest()
        {
            var testObject = GetMerchantInfo();
            Assert.Equal("jziaja.test.merchant-facilitator@gmail.com", testObject.email);
            Assert.Equal("Dennis", testObject.first_name);
            Assert.Equal("Doctor", testObject.last_name);
            Assert.Equal("Medical Professionals, LLC", testObject.business_name);
            Assert.NotNull(testObject.phone);
            Assert.NotNull(testObject.address);
        }

        [Fact, Trait("Category", "Unit")]
        public void MerchantInfoConvertToJsonTest()
        {
            Assert.False(GetMerchantInfo().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void MerchantInfoToStringTest()
        {
            Assert.False(GetMerchantInfo().ToString().Length == 0);
        }
    }
}
