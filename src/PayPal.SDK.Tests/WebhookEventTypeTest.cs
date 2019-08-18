using System;

using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebhookEventTypeTest : BaseTest
    {
        public static readonly string WebhookEventTypeJsonCreated = "{\"name\":\"PAYMENT.AUTHORIZATION.CREATED\"}";
        public static readonly string WebhookEventTypeJsonVoided = "{\"name\":\"PAYMENT.AUTHORIZATION.VOIDED\"}";

        public static WebhookEventType GetWebhookEventType()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventType>(WebhookEventTypeJsonCreated);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventTypeObjectTest()
        {
            var testObject = GetWebhookEventType();
            Assert.Equal("PAYMENT.AUTHORIZATION.CREATED", testObject.name);
            Assert.True(string.IsNullOrEmpty(testObject.description));
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventTypeConvertToJsonTest()
        {
            Assert.False(GetWebhookEventType().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventTypeToStringTest()
        {
            Assert.False(GetWebhookEventType().ToString().Length == 0);
        }

        [Fact(Skip="Ignore")]
        public void WebhookEventTypeSubscribedEventsTest()
        {
            var webhookEventTypeList = WebhookEventType.SubscribedEventTypes(TestingUtil.GetApiContext(), "45R80540W07069023");
            Assert.NotNull(webhookEventTypeList);
            Assert.NotNull(webhookEventTypeList.event_types);
            Assert.Equal(2, webhookEventTypeList.event_types.Count);
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventTypeAvailableEventsTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhookEventTypeList = WebhookEventType.AvailableEventTypes(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(webhookEventTypeList);
                Assert.NotNull(webhookEventTypeList.event_types);
                Assert.True(webhookEventTypeList.event_types.Count > 2);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
