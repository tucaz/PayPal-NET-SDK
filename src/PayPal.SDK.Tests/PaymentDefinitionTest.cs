using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for PaymentDefinitionTest
    /// </summary>
    
    public class PaymentDefinitionTest
    {
        public static readonly string PaymentDefinitionJson = 
            "{\"name\":\"Regular Payments\"," +
		    "\"type\":\"REGULAR\"," +
		    "\"frequency\":\"MONTH\"," +
		    "\"frequency_interval\":\"2\"," +
		    "\"amount\":" + CurrencyTest.CurrencyJson + "," +
		    "\"cycles\":\"12\"," +
		    "\"charge_models\":[" + ChargeModelTest.ChargeModelJson + "]}";

        public static PaymentDefinition GetPaymentDefinition()
        {
            return JsonFormatter.ConvertFromJson<PaymentDefinition>(PaymentDefinitionJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentDefinitionObjectTest()
        {
            var testObject = GetPaymentDefinition();
            Assert.Equal("Regular Payments", testObject.name);
            Assert.Equal("REGULAR", testObject.type);
            Assert.Equal("MONTH", testObject.frequency);
            Assert.Equal("2", testObject.frequency_interval);
            Assert.Equal("12", testObject.cycles);
            Assert.NotNull(testObject.amount);
            Assert.NotNull(testObject.charge_models);
            Assert.True(testObject.charge_models.Count == 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentDefinitionConvertToJsonTest()
        {
            Assert.False(GetPaymentDefinition().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PaymentDefinitionToStringTest()
        {
            Assert.False(GetPaymentDefinition().ToString().Length == 0);
        }
    }
}
