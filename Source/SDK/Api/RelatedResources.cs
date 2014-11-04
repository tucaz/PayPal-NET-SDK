using Newtonsoft.Json;

namespace PayPal.Api
{
    public class RelatedResources
    {
        /// <summary>
        /// A sale transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sale")]
        public Sale sale { get; set; }

        /// <summary>
        /// An authorization transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "authorization")]
        public Authorization authorization { get; set; }

        /// <summary>
        /// An order transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order")]
        public Order order { get; set; }

        /// <summary>
        /// A capture transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "capture")]
        public Capture capture { get; set; }

        /// <summary>
        /// A refund transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "refund")]
        public Refund refund { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
