using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class FlowConfigTest
    {
        public static readonly string FlowConfigJson = "{\"landing_page_type\": \"billing\",\"bank_txn_pending_url\": \"http://www.paypal.com\",\"user_action\":\"commit\",\"return_uri_http_method\":\"GET\"}";

        public static FlowConfig GetFlowConfig()
        {
            return JsonFormatter.ConvertFromJson<FlowConfig>(FlowConfigJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void FlowConfigObjectTest()
        {
            var flowConfig = GetFlowConfig();
            Assert.Equal("billing", flowConfig.landing_page_type);
            Assert.Equal("http://www.paypal.com", flowConfig.bank_txn_pending_url);
            Assert.Equal("commit", flowConfig.user_action);
            Assert.Equal("GET", flowConfig.return_uri_http_method);
        }

        [Fact, Trait("Category", "Unit")]
        public void FlowConfigConvertToJsonTest()
        {
            Assert.False(GetFlowConfig().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void FlowConfigToStringTest()
        {
            Assert.False(GetFlowConfig().ToString().Length == 0);
        }
    }
}
