using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
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

        [TestMethod()]
        public void CurrencyObjectTest()
        {
            var testObject = GetCurrency();
            Assert.AreEqual("1", testObject.value);
            Assert.AreEqual("USD", testObject.currency);
        }

        [TestMethod()]
        public void CurrencyConvertToJsonTest()
        {
            Assert.IsFalse(GetCurrency().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void CurrencyToStringTest()
        {
            Assert.IsFalse(GetCurrency().ToString().Length == 0);
        }
    }
}
