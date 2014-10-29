using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class RedirectUrls
    {
        /// <summary>
        /// Url where the payer would be redirected to after approving the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "return_url")]
        public string return_url { get; set; }

        /// <summary>
        /// Url where the payer would be redirected to after canceling the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cancel_url")]
        public string cancel_url { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
