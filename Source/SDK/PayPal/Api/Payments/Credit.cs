using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Credit
    {
        /// <summary>
        /// Unique identifier of credit resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

        /// <summary>
        /// specifies type of credit
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }

        /// <summary>
        /// URI to the associated terms
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string terms { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
