using Newtonsoft.Json;

namespace PayPal.Api
{
    public class InvoicingMetaData : PayPalSerializableObject
    {
        /// <summary>
        /// Date when the resource was created.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "created_date")]
        public string created_date { get; set; }

        /// <summary>
        /// Email address of the account that created the resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "created_by")]
        public string created_by { get; set; }

        /// <summary>
        /// Date when the resource was cancelled.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cancelled_date")]
        public string cancelled_date { get; set; }

        /// <summary>
        /// Actor who cancelled the resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cancelled_by")]
        public string cancelled_by { get; set; }

        /// <summary>
        /// Date when the resource was last edited.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_updated_date")]
        public string last_updated_date { get; set; }

        /// <summary>
        /// Email address of the account that last edited the resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_updated_by")]
        public string last_updated_by { get; set; }

        /// <summary>
        /// Date when the resource was first sent.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_sent_date")]
        public string first_sent_date { get; set; }

        /// <summary>
        /// Date when the resource was last sent.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_sent_date")]
        public string last_sent_date { get; set; }

        /// <summary>
        /// Email address of the account that last sent the resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_sent_by")]
        public string last_sent_by { get; set; }
    }
}
