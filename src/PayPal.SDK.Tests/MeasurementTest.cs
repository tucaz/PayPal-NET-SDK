
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class MeasurementTest
    {
        public static readonly string MeasurementJson =
            "{\"value\":\"2\"," +
            "\"unit\":\"meters\"}";

        public static Measurement GetMeasurement()
        {
            return JsonFormatter.ConvertFromJson<Measurement>(MeasurementJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void MeasurementObjectTest()
        {
            var testObject = GetMeasurement();
            Assert.Equal("2", testObject.value);
            Assert.Equal("meters", testObject.unit);
        }

        [Fact, Trait("Category", "Unit")]
        public void MeasurementConvertToJsonTest()
        {
            Assert.False(GetMeasurement().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void MeasurementToStringTest()
        {
            Assert.False(GetMeasurement().ToString().Length == 0);
        }
    }
}
