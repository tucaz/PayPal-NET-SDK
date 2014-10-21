using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class Patch
    {
        /// <summary>
        /// The operation to perform.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "op")]
        public string op { get; set; }

        /// <summary>
        /// String containing a JSON-Pointer value that references a location within the target document where the operation is performed.
        /// </summary>
        /// [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "path")]
        public string path { get; set; }

        /// <summary>
        /// New value to apply based on the operation.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value")]
        public object value { get; set; }

        /// <summary>
        /// A string containing a JSON Pointer value that references the location in the target document from which to move the value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "from")]
        public string from { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
