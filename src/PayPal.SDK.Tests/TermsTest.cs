using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for TermsTest
    /// </summary>
    [TestClass]
    public class TermsTest
    {
        public static readonly string TermsJson =
            "{\"id\":\"1234\"," +
            "\"type\":\"MONTHLY\"," +
            "\"max_billing_amount\":" + CurrencyTest.CurrencyJson + "," +
            "\"occurrences\":\"2\"," +
            "\"amount_range\":" + CurrencyTest.CurrencyJson + "}";

        public static Terms GetTerms()
        {
            return JsonFormatter.ConvertFromJson<Terms>(TermsJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void TermsObjectTest()
        {
            var testObject = GetTerms();
            Assert.AreEqual("1234", testObject.id);
            Assert.AreEqual("MONTHLY", testObject.type);
            Assert.AreEqual("2", testObject.occurrences);
            Assert.IsNotNull(testObject.max_billing_amount);
            Assert.IsNotNull(testObject.amount_range);
        }

        [TestMethod, TestCategory("Unit")]
        public void TermsConvertToJsonTest()
        {
            Assert.IsFalse(GetTerms().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void TermsToStringTest()
        {
            Assert.IsFalse(GetTerms().ToString().Length == 0);
        }
    }
}
