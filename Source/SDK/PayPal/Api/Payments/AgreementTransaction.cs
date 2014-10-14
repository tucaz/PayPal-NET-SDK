using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class AgreementTransaction
    {
        /// <summary>
        /// Id corresponding to this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string transaction_id { get; set; }

        /// <summary>
        /// State of the subscription at this time.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }

        /// <summary>
        /// Type of transaction, usually Recurring Payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string transaction_type { get; set; }

        /// <summary>
        /// Amount for this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Currency amount { get; set; }

        /// <summary>
        /// Fee amount for this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Currency fee_amount { get; set; }

        /// <summary>
        /// Net amount for this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Currency net_amount { get; set; }

        /// <summary>
        /// Email id of payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string payer_email { get; set; }

        /// <summary>
        /// Business name of payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string payer_name { get; set; }

        /// <summary>
        /// Time at which this transaction happened.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string time_updated { get; set; }

        /// <summary>
        /// Time zone of time_updated field.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string time_zone { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
