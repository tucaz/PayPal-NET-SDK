using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Patch
    {
        /// <summary>
        /// The operation to perform.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string op { get; set; }

        /// <summary>
        /// String containing a JSON-Pointer value that references a location within the target document where the operation is performed.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string path { get; set; }

        /// <summary>
        /// New value to apply based on the operation.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string value { get; set; }

        /// <summary>
        /// A string containing a JSON Pointer value that references the location in the target document from which to move the value.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
