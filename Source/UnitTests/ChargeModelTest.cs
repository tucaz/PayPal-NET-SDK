using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for ChargeModelsTest
    /// </summary>
    [TestClass]
    public class ChargeModelTest
    {
        public static readonly string ChargeModelJson = "{\"id\":\"CHM-92S85978TN737850VRWBZEUA\",\"type\":\"TAX\",\"amount\":" + AmountTest.AmountJson + "}";

        public static ChargeModel GetChargeModel()
        {
            return JsonFormatter.ConvertFromJson<ChargeModel>(ChargeModelJson);
        }

        [TestMethod()]
        public void ChargeModelObjectTest()
        {
            var testObject = GetChargeModel();
            Assert.AreEqual("CHM-92S85978TN737850VRWBZEUA", testObject.id);
            Assert.AreEqual("TAX", testObject.type);
            Assert.IsNotNull(testObject.amount);
        }

        [TestMethod()]
        public void ChargeModelConvertToJsonTest()
        {
            Assert.IsFalse(GetChargeModel().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ChargeModelToStringTest()
        {
            Assert.IsFalse(GetChargeModel().ToString().Length == 0);
        }
    }
}
