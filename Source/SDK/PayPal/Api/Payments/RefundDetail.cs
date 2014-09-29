using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class RefundDetail
    {
        /// <summary>
        /// PayPal refund type indicating whether refund was done in invoicing flow via PayPal or externally. In the case of the mark-as-refunded API, refund type is EXTERNAL and this is what is now supported. The PAYPAL value is provided for backward compatibility.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }

        /// <summary>
        /// Date when the invoice was marked as refunded. If no date is specified, the current date and time is used as the default. In addition, the date must be after the invoice payment date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string date { get; set; }

        /// <summary>
        /// Optional note associated with the refund.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string note { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
