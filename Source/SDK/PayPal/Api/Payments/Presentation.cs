using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Presentation
    {
        /// <summary>
        /// A label that overrides the business name in the PayPal account on the PayPal pages.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string brand_name { get; set; }

        /// <summary>
        /// A URL to logo image. Allowed vaues: `.gif`, `.jpg`, or `.png`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string logo_image { get; set; }

        /// <summary>
        /// Locale of pages displayed by PayPal payment experience.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
