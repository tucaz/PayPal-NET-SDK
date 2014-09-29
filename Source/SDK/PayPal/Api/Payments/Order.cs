using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Order
    {
        /// <summary>
        /// Identifier of the order transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

        /// <summary>
        /// Identifier to the purchase unit associated with this object
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string purchase_unit_reference_id { get; set; }

        /// <summary>
        /// Time the resource was created in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string create_time { get; set; }

        /// <summary>
        /// Time the resource was last updated in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string update_time { get; set; }

        /// <summary>
        /// Amount being collected.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Amount amount { get; set; }

        /// <summary>
        /// specifies payment mode of the transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string payment_mode { get; set; }

        /// <summary>
        /// State of the order transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string state { get; set; }

        /// <summary>
        /// Protection Eligibility of the Payer 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string protection_eligibility { get; set; }

        /// <summary>
        /// Protection Eligibility Type of the Payer 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string protection_eligibility_type { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
