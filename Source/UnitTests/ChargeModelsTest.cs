using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for ChargeModelsTest
    /// </summary>
    [TestClass]
    public class ChargeModelsTest
    {
        public static readonly string ChargeModelsJson = "{\"id\":\"CHM-92S85978TN737850VRWBZEUA\",\"type\":\"TAX\",\"amount\":" + AmountTest.AmountJson + "}";

        public static ChargeModels GetChargeModels()
        {
            return JsonFormatter.ConvertFromJson<ChargeModels>(ChargeModelsJson);
        }

        [TestMethod()]
        public void ChargeModelsObjectTest()
        {
            var testObject = GetChargeModels();
            Assert.AreEqual("CHM-92S85978TN737850VRWBZEUA", testObject.id);
            Assert.AreEqual("TAX", testObject.type);
            Assert.IsNotNull(testObject.amount);
        }

        [TestMethod()]
        public void ChargeModelsConvertToJsonTest()
        {
            Assert.IsFalse(GetChargeModels().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ChargeModelsToStringTest()
        {
            Assert.IsFalse(GetChargeModels().ToString().Length == 0);
        }
    }
}
