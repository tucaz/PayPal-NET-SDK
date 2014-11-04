using Newtonsoft.Json;

namespace PayPal.Api
{
    public class PaymentTerm : PayPalSerializableObject
    {
        /// <summary>
        /// Terms by which the invoice payment is due.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "term_type")]
        public string term_type { get; set; }

        /// <summary>
        /// Date on which invoice payment is due. It must be always a future date. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "due_date")]
        public string due_date { get; set; }
    }
}
