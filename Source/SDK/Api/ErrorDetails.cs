using Newtonsoft.Json;

namespace PayPal.Api
{
    public class ErrorDetails : PayPalSerializableObject
    {
        /// <summary>
        /// Name of the field that caused the error.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "field")]
        public string field { get; set; }

        /// <summary>
        /// Reason for the error.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "issue")]
        public string issue { get; set; }
    }
}
