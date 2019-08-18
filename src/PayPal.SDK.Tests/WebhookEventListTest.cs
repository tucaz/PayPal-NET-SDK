using System;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebhookEventListTest
    {
        public static readonly string WebhookEventListJson = 
            "{\"events\":[" + WebhookEventTest.WebhookEventJson + "]," +
            "\"count\": 2," + 
            "\"links\": [" +
            "{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/?start_time=2014-08-04T12:46:47-07:00&amp;amp;end_time=2014-09-18T12:46:47-07:00&amp;amp;page_size=2&amp;amp;move_to=next&amp;amp;index_time=2014-09-17T23:07:35Z&amp;amp;index_id=3\"," +
                "\"rel\":\"next\"," +
                "\"method\":\"GET\"" +
            "},{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/?start_time=2014-08-04T12:46:47-07:00&amp;amp;end_time=2014-09-18T12:46:47-07:00&amp;amp;page_size=2&amp;amp;move_to=previous&amp;amp;index_time=2014-09-17T23:07:35Z&amp;amp;index_id=0\"," +
                "\"rel\":\"previous\"," +
                "\"method\":\"GET\"}]}";

        public static WebhookEventList GetWebhookEventList()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventList>(WebhookEventListJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventListObjectTest()
        {
            var testObject = GetWebhookEventList();
            Assert.NotNull(testObject.events);
            Assert.Equal(2, testObject.count);
            Assert.NotNull(testObject.links);
            Assert.True(testObject.links.Count == 2);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventListConvertToJsonTest()
        {
            Assert.False(GetWebhookEventList().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventListToStringTest()
        {
            Assert.False(GetWebhookEventList().ToString().Length == 0);
        }
    }
}
