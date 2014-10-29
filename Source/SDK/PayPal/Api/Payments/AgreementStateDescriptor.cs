using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class AgreementStateDescriptor
    {
        /// <summary>
        /// Reason for changing the state of the agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note")]
        public string note { get; set; }

        /// <summary>
        /// The amount and currency of the agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
