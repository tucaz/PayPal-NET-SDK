using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Payer
    {
        /// <summary>
        /// Payment method being used - PayPal Wallet payment, Bank Direct Debit  or Direct Credit card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string payment_method { get; set; }

        /// <summary>
        /// Status of Payer PayPal Account.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }

        /// <summary>
        /// List of funding instruments from where the funds of the current payment come from. Typically a credit card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<FundingInstrument> funding_instruments { get; set; }

        /// <summary>
        /// Id of user selected funding option for the payment. 'OneOf' funding_instruments or funding_option_id to be present 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string funding_option_id { get; set; }

        /// <summary>
        /// Information related to the Payer. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PayerInfo payer_info { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
