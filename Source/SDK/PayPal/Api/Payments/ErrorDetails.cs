using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class ErrorDetails
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

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
