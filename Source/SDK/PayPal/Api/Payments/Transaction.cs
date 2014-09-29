using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Transaction : TransactionBase
    {
        /// <summary>
        /// Additional transactions for complex payment scenarios.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Transaction> transactions { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public override string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
