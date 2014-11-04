using Newtonsoft.Json;

namespace PayPal.Api
{
    public class InvoicingNotification : PayPalSerializableObject
    {
        /// <summary>
        /// Subject of the notification.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject")]
        public string subject { get; set; }

        /// <summary>
        /// Note to the payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note")]
        public string note { get; set; }

        /// <summary>
        /// A flag indicating whether a copy of the email has to be sent to the merchant.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "send_to_merchant")]
        public bool? send_to_merchant { get; set; }
    }
}
