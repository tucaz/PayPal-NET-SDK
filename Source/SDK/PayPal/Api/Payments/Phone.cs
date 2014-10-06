using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Phone
    {
        /// <summary>
        /// Country code (from in E.164 format)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string country_code { get; set; }

        /// <summary>
        /// In-country phone number (from in E.164 format)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string number { get; set; }

        /// <summary>
        /// Phone extension
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
