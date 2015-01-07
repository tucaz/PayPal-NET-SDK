using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass]
    public class FlowConfigTest
    {
        public static readonly string FlowConfigJson = "{\"landing_page_type\": \"billing\",\"bank_txn_pending_url\": \"http://www.paypal.com\"}";

        public static FlowConfig GetFlowConfig()
        {
            return JsonFormatter.ConvertFromJson<FlowConfig>(FlowConfigJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void FlowConfigObjectTest()
        {
            var flowConfig = GetFlowConfig();
            Assert.AreEqual("billing", flowConfig.landing_page_type);
            Assert.AreEqual("http://www.paypal.com", flowConfig.bank_txn_pending_url);
        }

        [TestMethod, TestCategory("Unit")]
        public void FlowConfigConvertToJsonTest()
        {
            Assert.IsFalse(GetFlowConfig().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void FlowConfigToStringTest()
        {
            Assert.IsFalse(GetFlowConfig().ToString().Length == 0);
        }
    }
}
