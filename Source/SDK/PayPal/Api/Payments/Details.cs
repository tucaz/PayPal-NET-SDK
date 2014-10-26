using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class Details
    {
        /// <summary>
        /// Amount being charged for shipping.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "shipping")]
        public string shipping { get; set; }

        /// <summary>
        /// Sub-total (amount) of items being paid for.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subtotal")]
        public string subtotal { get; set; }

        /// <summary>
        /// Amount being charged as tax.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax")]
        public string tax { get; set; }

        /// <summary>
        /// Fee charged by PayPal. In case of a refund, this is the fee amount refunded to the original receipient of the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fee")]
        public string fee { get; set; }

        /// <summary>
        /// Amount being charged as handling fee.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "handling_fee")]
        public string handling_fee { get; set; }

        /// <summary>
        /// Amount being charged as gift wrap fee.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "gift_wrap")]
        public string gift_wrap { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
