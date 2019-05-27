using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for MerchantPreferencesTest
    /// </summary>
    [TestClass]
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

        [TestMethod, TestCategory("Unit")]
        public void MerchantPreferencesObjectTest()
        {
            var testObject = GetMerchantPreferences();
            Assert.AreEqual("http://www.return.com", testObject.return_url);
            Assert.AreEqual("http://www.cancel.com", testObject.cancel_url);
            Assert.AreEqual("YES", testObject.auto_bill_amount);
            Assert.AreEqual("CONTINUE", testObject.initial_fail_amount_action);
            Assert.AreEqual("0", testObject.max_fail_attempts);
            Assert.IsNotNull(testObject.setup_fee);
        }

        [TestMethod, TestCategory("Unit")]
        public void MerchantPreferencesConvertToJsonTest()
        {
            Assert.IsFalse(GetMerchantPreferences().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void MerchantPreferencesToStringTest()
        {
            Assert.IsFalse(GetMerchantPreferences().ToString().Length == 0);
        }
    }
}
