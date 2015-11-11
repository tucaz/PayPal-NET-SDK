using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
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

        [TestMethod, TestCategory("Unit")]
        public void ProcessorResponseObjectTest()
        {
            var testObject = GetProcessorResponse();
            Assert.AreEqual("1000", testObject.response_code);
            Assert.AreEqual("2000", testObject.avs_code);
            Assert.AreEqual("3000", testObject.cvv_code);
            Assert.AreEqual("4000", testObject.advice_code);
            Assert.AreEqual("5000", testObject.eci_submitted);
            Assert.AreEqual("6000", testObject.vpas);
        }

        [TestMethod, TestCategory("Unit")]
        public void ProcessorResponseConvertToJsonTest()
        {
            Assert.IsFalse(GetProcessorResponse().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ProcessorResponseToStringTest()
        {
            Assert.IsFalse(GetProcessorResponse().ToString().Length == 0);
        }
    }
}
