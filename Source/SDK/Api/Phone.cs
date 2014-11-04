using Newtonsoft.Json;

namespace PayPal.Api
{
    public class Phone : PayPalSerializableObject
    {
        /// <summary>
        /// Country code (in E.164 format). Assume length is n.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country_code")]
        public string country_code { get; set; }

        /// <summary>
        /// In-country phone number (in E.164 format). Maximum (15 - n) digits.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "national_number")]
        public string national_number { get; set; }
    }
}
