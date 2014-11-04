using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api
{
    public class TransactionBase : CartBase
    {
        /// <summary>
        /// List of financial transactions (Sale, Authorization, Capture, Refund) related to the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "related_resources")]
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
