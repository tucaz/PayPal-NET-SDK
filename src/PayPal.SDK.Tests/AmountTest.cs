
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class AmountTest
    {
        public static readonly string AmountJson = 
            "{\"total\":\"100\"," +
            "\"currency\":\"USD\"," +
            "\"details\":" + DetailsTest.DetailsJson + "}";

        public static Amount GetAmount()
        {
            return JsonFormatter.ConvertFromJson<Amount>(AmountJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AmountObjectTest()
        {
            var amount = GetAmount();
            Assert.Equal("USD", amount.currency);
            Assert.Equal("100", amount.total);
            Assert.NotNull(amount.details);
        }

        [Fact, Trait("Category", "Unit")]
        public void AmountConvertToJsonTest()
        {
            Assert.False(GetAmount().ConvertToJson().Length == 0);
        }
        
        [Fact, Trait("Category", "Unit")]
        public void AmountToStringTest()
        {
            Assert.False(GetAmount().ToString().Length == 0);
        }
    }
}
