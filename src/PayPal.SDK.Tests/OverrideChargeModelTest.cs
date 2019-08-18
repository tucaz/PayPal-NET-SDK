using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for OverrideChargeModelTest
    /// </summary>
    
    public class OverrideChargeModelTest
    {
        public static readonly string OverrideChargeModelJson = "{\"charge_id\":\"1234\",\"amount\":" + AmountTest.AmountJson + "}";

        public static OverrideChargeModel GetOverrideChargeModel()
        {
            return JsonFormatter.ConvertFromJson<OverrideChargeModel>(OverrideChargeModelJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void OverrideChargeModelObjectTest()
        {
            var testObject = GetOverrideChargeModel();
            Assert.Equal("1234", testObject.charge_id);
            Assert.NotNull(testObject.amount);
        }

        [Fact, Trait("Category", "Unit")]
        public void OverrideChargeModelConvertToJsonTest()
        {
            Assert.False(GetOverrideChargeModel().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void OverrideChargeModelToStringTest()
        {
            Assert.False(GetOverrideChargeModel().ToString().Length == 0);
        }
    }
}
