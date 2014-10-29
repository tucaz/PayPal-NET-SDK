using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class PaymentExecution
    {
        /// <summary>
        /// PayPal assigned Payer ID returned in the approval return url.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer_id")]
        public string payer_id { get; set; }

        /// <summary>
        /// If the amount needs to be updated after obtaining the PayPal Payer info (eg. shipping address), it can be updated using this element.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transactions")]
        public List<Transactions> transactions { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
