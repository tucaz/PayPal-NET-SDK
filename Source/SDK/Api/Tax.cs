using Newtonsoft.Json;

namespace PayPal.Api
{
    public class Tax : PayPalSerializableObject
    {
        /// <summary>
        /// Identifier of the resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Name of the tax. 10 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Rate of the specified tax. Range of 0.001 to 99.999.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "percent")]
        public float percent { get; set; }

        /// <summary>
        /// Tax in the form of money. Cannot be specified in a request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }
    }
}
