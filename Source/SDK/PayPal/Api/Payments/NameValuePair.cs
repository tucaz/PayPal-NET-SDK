using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class NameValuePair
    {
        /// <summary>
        /// Key for the name value pair.  The value name types should be correlated 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Value for the name value pair.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value")]
        public string value { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
