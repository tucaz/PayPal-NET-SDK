using Newtonsoft.Json;

namespace PayPal.Api
{
    public class PaymentCardToken
    {
        /// <summary>
        /// ID of a previously saved Payment Card resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_card_id")]
        public string payment_card_id { get; set; }

        /// <summary>
        /// The unique identifier of the payer used when saving this payment card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_customer_id")]
        public string external_customer_id { get; set; }

        /// <summary>
        /// Last 4 digits of the card number from the saved card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last4")]
        public string last4 { get; set; }

        /// <summary>
        /// Type of the Card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string type { get; set; }

        /// <summary>
        /// card expiry month from the saved card with value 1 - 12
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expire_month")]
        public int expire_month { get; set; }

        /// <summary>
        /// 4 digit card expiry year from the saved card
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expire_year")]
        public int expire_year { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
