using System;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebhookListTest
    {
        public static readonly string WebhookListJson = "{\"webhooks\":[" + WebhookTest.WebhookJson + "]}";

        public static WebhookList GetWebhookList()
        {
            return JsonFormatter.ConvertFromJson<WebhookList>(WebhookListJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookListObjectTest()
        {
            var testObject = GetWebhookList();
            Assert.NotNull(testObject.webhooks);
            Assert.True(testObject.webhooks.Count == 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookListConvertToJsonTest()
        {
            Assert.False(GetWebhookList().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookListToStringTest()
        {
            Assert.False(GetWebhookList().ToString().Length == 0);
        }
    }
}
