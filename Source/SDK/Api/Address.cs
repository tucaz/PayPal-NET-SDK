using Newtonsoft.Json;

namespace PayPal.Api
{
    public class Address : PayPalSerializableObject
    {
        /// <summary>
        /// Line 1 of the Address (eg. number, street, etc).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "line1")]
        public string line1 { get; set; }

        /// <summary>
        /// Optional line 2 of the Address (eg. suite, apt #, etc.).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "line2")]
        public string line2 { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "city")]
        public string city { get; set; }

        /// <summary>
        /// 2 letter country code.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country_code")]
        public string country_code { get; set; }

        /// <summary>
        /// Zip code or equivalent is usually required for countries that have them. For list of countries that do not have postal codes please refer to http://en.wikipedia.org/wiki/Postal_code.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "postal_code")]
        public string postal_code { get; set; }

        /// <summary>
        /// 2 letter code for US states, and the equivalent for other countries.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Phone number in E.123 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "phone")]
        public string phone { get; set; }
    }
}
