using Newtonsoft.Json;
using System;

namespace PayPal.Api
{
    public class Phone
    {
        /// <summary>
        /// Country code (from in E.164 format)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country_code")]
        public string country_code { get; set; }

        /// <summary>
        /// In-country phone number (from in E.164 format)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "number")]
        [Obsolete("Obsolete. Use national_number.")]
        public string number { get; set; }

        /// <summary>
        /// In-country phone number (from in E.164 format)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "national_number")]
        public string national_number { get; set; }

        /// <summary>
        /// Phone extension
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "extension")]
        public string extension { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
