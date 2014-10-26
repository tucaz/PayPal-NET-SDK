using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class FlowConfig
    {
        /// <summary>
        /// Type of PayPal page to be displayed when a user lands on the PayPal site for checkout. Allowed values: `Billing` or `Login`. When set to `Billing`, the Non-PayPal account landing page is used. When set to `Login`, the PayPal account login landing page is used.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "landing_page_type")]
        public string landing_page_type { get; set; }

        /// <summary>
        /// The URL on the merchant site for transferring to after a bank transfer payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bank_txn_pending_url")]
        public string bank_txn_pending_url { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
