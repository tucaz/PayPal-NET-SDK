using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api
{
    public class AgreementTransaction
    {
        /// <summary>
        /// Id corresponding to this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_id")]
        public string transaction_id { get; set; }

        /// <summary>
        /// State of the subscription at this time.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
        public string status { get; set; }

        /// <summary>
        /// Type of transaction, usually Recurring Payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_type")]
        public string transaction_type { get; set; }

        /// <summary>
        /// Amount for this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }

        /// <summary>
        /// Fee amount for this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fee_amount")]
        public Currency fee_amount { get; set; }

        /// <summary>
        /// Net amount for this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "net_amount")]
        public Currency net_amount { get; set; }

        /// <summary>
        /// Email id of payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer_email")]
        public string payer_email { get; set; }

        /// <summary>
        /// Business name of payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer_name")]
        public string payer_name { get; set; }

        /// <summary>
        /// Time at which this transaction happened.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "time_updated")]
        public string time_updated { get; set; }

        /// <summary>
        /// Time zone of time_updated field.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "time_zone")]
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
