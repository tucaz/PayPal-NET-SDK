using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for ChargeModelsTest
    /// </summary>
    
    public class ChargeModelTest
    {
        public static readonly string ChargeModelJson = "{\"id\":\"CHM-92S85978TN737850VRWBZEUA\",\"type\":\"TAX\",\"amount\":" + CurrencyTest.CurrencyJson + "}";

        public static ChargeModel GetChargeModel()
        {
            return JsonFormatter.ConvertFromJson<ChargeModel>(ChargeModelJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void ChargeModelObjectTest()
        {
            var testObject = GetChargeModel();
            Assert.Equal("CHM-92S85978TN737850VRWBZEUA", testObject.id);
            Assert.Equal("TAX", testObject.type);
            Assert.NotNull(testObject.amount);
        }

        [Fact, Trait("Category", "Unit")]
        public void ChargeModelConvertToJsonTest()
        {
            Assert.False(GetChargeModel().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void ChargeModelToStringTest()
        {
            Assert.False(GetChargeModel().ToString().Length == 0);
        }
    }
}
