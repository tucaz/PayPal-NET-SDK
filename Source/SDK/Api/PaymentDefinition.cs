using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace PayPal.Api
{
    public class PaymentDefinition
    {
        /// <summary>
        /// Identifier of the payment_definition. 128 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Name of the payment definition. 128 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Type of the payment definition. Allowed values: `TRIAL`, `REGULAR`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string type { get; set; }

        /// <summary>
        /// How frequently the customer should be charged.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "frequency_interval")]
        public string frequency_interval { get; set; }

        /// <summary>
        /// Frequency of the payment definition offered. Allowed values: `WEEK`, `DAY`, `YEAR`, `MONTH`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "frequency")]
        public string frequency { get; set; }

        /// <summary>
        /// Number of cycles in this payment definition.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cycles")]
        public string cycles { get; set; }

        /// <summary>
        /// Amount that will be charged at the end of each cycle for this payment definition.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }

        /// <summary>
        /// Array of charge_models for this payment definition.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "charge_models")]
        public List<ChargeModel> charge_models { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
