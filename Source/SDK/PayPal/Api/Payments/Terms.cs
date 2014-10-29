using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Terms
    {
        /// <summary>
        /// Identifier of the terms. 128 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Term type. Allowed values: `MONTHLY`, `WEEKLY`, `YEARLY`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string type { get; set; }

        /// <summary>
        /// Max Amount associated with this term.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "max_billing_amount")]
        public Currency max_billing_amount { get; set; }

        /// <summary>
        /// How many times money can be pulled during this term.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "occurrences")]
        public string occurrences { get; set; }

        /// <summary>
        /// Amount_range associated with this term.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount_range")]
        public Currency amount_range { get; set; }

        /// <summary>
        /// Buyer's ability to edit the amount in this term.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "buyer_editable")]
        public string buyer_editable { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
