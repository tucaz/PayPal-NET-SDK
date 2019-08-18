using System;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebhookEventTypeListTest
    {
        public static readonly string WebhookEventTypeListJson = 
            "{\"event_types\": [" +
            WebhookEventTypeTest.WebhookEventTypeJsonCreated + "," +
            WebhookEventTypeTest.WebhookEventTypeJsonVoided + "]}";

        public static WebhookEventTypeList GetWebhookEventTypeList()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventTypeList>(WebhookEventTypeListJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventTypeListObjectTest()
        {
            var testObject = GetWebhookEventTypeList();
            Assert.NotNull(testObject.event_types);
            Assert.True(testObject.event_types.Count == 2);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventTypeListConvertToJsonTest()
        {
            Assert.False(GetWebhookEventTypeList().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventTypeListToStringTest()
        {
            Assert.False(GetWebhookEventTypeList().ToString().Length == 0);
        }
    }
}
