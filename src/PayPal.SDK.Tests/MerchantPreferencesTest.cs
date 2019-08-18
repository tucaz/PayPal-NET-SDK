using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for MerchantPreferencesTest
    /// </summary>
    
    public class MerchantPreferencesTest
    {
        public static readonly string MerchantPreferencesJson = 
            "{\"setup_fee\":" + CurrencyTest.CurrencyJson + "," +
            "\"return_url\":\"http://www.return.com\"," +
		    "\"cancel_url\":\"http://www.cancel.com\"," +
		    "\"auto_bill_amount\":\"YES\"," +
		    "\"initial_fail_amount_action\":\"CONTINUE\"," +
		    "\"max_fail_attempts\":\"0\"}";

        public static MerchantPreferences GetMerchantPreferences()
        {
            return JsonFormatter.ConvertFromJson<MerchantPreferences>(MerchantPreferencesJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void MerchantPreferencesObjectTest()
        {
            var testObject = GetMerchantPreferences();
            Assert.Equal("http://www.return.com", testObject.return_url);
            Assert.Equal("http://www.cancel.com", testObject.cancel_url);
            Assert.Equal("YES", testObject.auto_bill_amount);
            Assert.Equal("CONTINUE", testObject.initial_fail_amount_action);
            Assert.Equal("0", testObject.max_fail_attempts);
            Assert.NotNull(testObject.setup_fee);
        }

        [Fact, Trait("Category", "Unit")]
        public void MerchantPreferencesConvertToJsonTest()
        {
            Assert.False(GetMerchantPreferences().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void MerchantPreferencesToStringTest()
        {
            Assert.False(GetMerchantPreferences().ToString().Length == 0);
        }
    }
}
