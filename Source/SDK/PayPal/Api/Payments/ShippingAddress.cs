using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class ShippingAddress : Address
    {
        /// <summary>
        /// Name of the recipient at this address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string recipient_name { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public override string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
