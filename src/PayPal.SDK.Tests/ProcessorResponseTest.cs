using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class ProcessorResponseTest
    {
        public static readonly string ProcessorResponseJson =
            "{\"response_code\":\"1000\"," +
            "\"avs_code\":\"2000\"," +
            "\"cvv_code\":\"3000\"," +
            "\"advice_code\":\"4000\"," +
            "\"eci_submitted\":\"5000\"," +
            "\"vpas\":\"6000\"}";

        public static ProcessorResponse GetProcessorResponse()
        {
            return JsonFormatter.ConvertFromJson<ProcessorResponse>(ProcessorResponseJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void ProcessorResponseObjectTest()
        {
            var testObject = GetProcessorResponse();
            Assert.Equal("1000", testObject.response_code);
            Assert.Equal("2000", testObject.avs_code);
            Assert.Equal("3000", testObject.cvv_code);
            Assert.Equal("4000", testObject.advice_code);
            Assert.Equal("5000", testObject.eci_submitted);
            Assert.Equal("6000", testObject.vpas);
        }

        [Fact, Trait("Category", "Unit")]
        public void ProcessorResponseConvertToJsonTest()
        {
            Assert.False(GetProcessorResponse().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void ProcessorResponseToStringTest()
        {
            Assert.False(GetProcessorResponse().ToString().Length == 0);
        }
    }
}
