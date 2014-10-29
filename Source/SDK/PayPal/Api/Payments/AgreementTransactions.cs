using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class AgreementTransactions
    {
        /// <summary>
        /// Array of agreement_transaction object.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "agreement_transaction_list")]
        public List<AgreementTransaction> agreement_transaction_list { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
