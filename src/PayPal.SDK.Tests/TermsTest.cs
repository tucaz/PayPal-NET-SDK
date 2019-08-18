using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for TermsTest
    /// </summary>
    
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

        [Fact, Trait("Category", "Unit")]
        public void TermsObjectTest()
        {
            var testObject = GetTerms();
            Assert.Equal("1234", testObject.id);
            Assert.Equal("MONTHLY", testObject.type);
            Assert.Equal("2", testObject.occurrences);
            Assert.NotNull(testObject.max_billing_amount);
            Assert.NotNull(testObject.amount_range);
        }

        [Fact, Trait("Category", "Unit")]
        public void TermsConvertToJsonTest()
        {
            Assert.False(GetTerms().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void TermsToStringTest()
        {
            Assert.False(GetTerms().ToString().Length == 0);
        }
    }
}
