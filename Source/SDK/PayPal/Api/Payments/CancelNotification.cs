using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class CancelNotification
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

        /// <summary>
        /// A flag indicating whether a copy of the email has to be sent to the payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "send_to_payer")]
        public bool? send_to_payer { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
