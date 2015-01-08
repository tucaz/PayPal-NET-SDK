using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for ChargeModelsTest
    /// </summary>
    [TestClass]
    public class ChargeModelTest
    {
        public static readonly string ChargeModelJson = "{\"id\":\"CHM-92S85978TN737850VRWBZEUA\",\"type\":\"TAX\",\"amount\":" + CurrencyTest.CurrencyJson + "}";

        public static ChargeModel GetChargeModel()
        {
            return JsonFormatter.ConvertFromJson<ChargeModel>(ChargeModelJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void ChargeModelObjectTest()
        {
            var testObject = GetChargeModel();
            Assert.AreEqual("CHM-92S85978TN737850VRWBZEUA", testObject.id);
            Assert.AreEqual("TAX", testObject.type);
            Assert.IsNotNull(testObject.amount);
        }

        [TestMethod, TestCategory("Unit")]
        public void ChargeModelConvertToJsonTest()
        {
            Assert.IsFalse(GetChargeModel().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ChargeModelToStringTest()
        {
            Assert.IsFalse(GetChargeModel().ToString().Length == 0);
        }
    }
}
