using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class CreditCardHistory
    {
        /// <summary>
        /// A list of credit card resources
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "credit_cards")]
        public List<CreditCard> credit_cards { get; set; }

        /// <summary>
        /// Number of items returned in each range of results. Note that the last results range could have fewer items than the requested number of items.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "count")]
        public int count { get; set; }

        /// <summary>
        /// Identifier of the next element to get the next range of results.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "next_id")]
        public string next_id { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
