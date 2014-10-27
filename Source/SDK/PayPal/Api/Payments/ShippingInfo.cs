using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class ShippingInfo
    {
        /// <summary>
        /// First name of the invoice recipient. 30 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_name")]
        public string first_name { get; set; }

        /// <summary>
        /// Last name of the invoice recipient. 30 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_name")]
        public string last_name { get; set; }

        /// <summary>
        /// Company business name of the invoice recipient. 100 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "business_name")]
        public string business_name { get; set; }

        /// <summary>
        /// Address of the invoice recipient.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "address")]
        public Address address { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
