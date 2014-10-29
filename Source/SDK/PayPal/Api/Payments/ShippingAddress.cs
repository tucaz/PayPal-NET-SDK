using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class ShippingAddress : Address
    {
        /// <summary>
        /// Address ID assigned in PayPal system.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Name of the recipient at this address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "recipient_name")]
        public string recipient_name { get; set; }

        /// <summary>
        /// Default shipping address of the Payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "default_address")]
        public bool? default_address { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public override string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
