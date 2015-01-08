using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for OverrideChargeModelTest
    /// </summary>
    [TestClass]
    public class OverrideChargeModelTest
    {
        public static readonly string OverrideChargeModelJson = "{\"charge_id\":\"1234\",\"amount\":" + AmountTest.AmountJson + "}";

        public static OverrideChargeModel GetOverrideChargeModel()
        {
            return JsonFormatter.ConvertFromJson<OverrideChargeModel>(OverrideChargeModelJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void OverrideChargeModelObjectTest()
        {
            var testObject = GetOverrideChargeModel();
            Assert.AreEqual("1234", testObject.charge_id);
            Assert.IsNotNull(testObject.amount);
        }

        [TestMethod, TestCategory("Unit")]
        public void OverrideChargeModelConvertToJsonTest()
        {
            Assert.IsFalse(GetOverrideChargeModel().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void OverrideChargeModelToStringTest()
        {
            Assert.IsFalse(GetOverrideChargeModel().ToString().Length == 0);
        }
    }
}
