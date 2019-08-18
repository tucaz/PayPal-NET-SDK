using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for CurrencyTest
    /// </summary>
    
    public class CurrencyTest
    {
        public static readonly string CurrencyJson = "{\"value\":\"1\",\"currency\":\"USD\"}";

        public static Currency GetCurrency()
        {
            return JsonFormatter.ConvertFromJson<Currency>(CurrencyJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void CurrencyObjectTest()
        {
            var testObject = GetCurrency();
            Assert.Equal("1", testObject.value);
            Assert.Equal("USD", testObject.currency);
        }

        [Fact, Trait("Category", "Unit")]
        public void CurrencyConvertToJsonTest()
        {
            Assert.False(GetCurrency().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void CurrencyToStringTest()
        {
            Assert.False(GetCurrency().ToString().Length == 0);
        }
    }
}
