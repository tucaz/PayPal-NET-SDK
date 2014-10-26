using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class Presentation
    {
        /// <summary>
        /// A label that overrides the business name in the PayPal account on the PayPal pages.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "brand_name")]
        public string brand_name { get; set; }

        /// <summary>
        /// A URL to logo image. Allowed values: `.gif`, `.jpg`, or `.png`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "logo_image")]
        public string logo_image { get; set; }

        /// <summary>
        /// Locale of pages displayed by PayPal payment experience.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "locale_code")]
        public string locale_code { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
