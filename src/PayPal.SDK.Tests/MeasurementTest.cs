using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class MeasurementTest
    {
        public static readonly string MeasurementJson =
            "{\"value\":\"2\"," +
            "\"unit\":\"meters\"}";

        public static Measurement GetMeasurement()
        {
            return JsonFormatter.ConvertFromJson<Measurement>(MeasurementJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void MeasurementObjectTest()
        {
            var testObject = GetMeasurement();
            Assert.AreEqual("2", testObject.value);
            Assert.AreEqual("meters", testObject.unit);
        }

        [TestMethod, TestCategory("Unit")]
        public void MeasurementConvertToJsonTest()
        {
            Assert.IsFalse(GetMeasurement().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void MeasurementToStringTest()
        {
            Assert.IsFalse(GetMeasurement().ToString().Length == 0);
        }
    }
}
