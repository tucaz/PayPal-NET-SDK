using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for CurrencyTest
    /// </summary>
    [TestClass]
    public class CurrencyTest
    {
        public static readonly string CurrencyJson = "{\"value\":\"1\",\"currency\":\"USD\"}";

        public static Currency GetCurrency()
        {
            return JsonFormatter.ConvertFromJson<Currency>(CurrencyJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void CurrencyObjectTest()
        {
            var testObject = GetCurrency();
            Assert.AreEqual("1", testObject.value);
            Assert.AreEqual("USD", testObject.currency);
        }

        [TestMethod, TestCategory("Unit")]
        public void CurrencyConvertToJsonTest()
        {
            Assert.IsFalse(GetCurrency().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void CurrencyToStringTest()
        {
            Assert.IsFalse(GetCurrency().ToString().Length == 0);
        }
    }
}
