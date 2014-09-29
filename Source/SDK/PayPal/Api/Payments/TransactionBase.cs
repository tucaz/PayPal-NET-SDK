using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class TransactionBase : CartBase
    {
        /// <summary>
        /// List of financial transactions (Sale, Authorization, Capture, Refund) related to the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<RelatedResources> related_resources { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public override string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
