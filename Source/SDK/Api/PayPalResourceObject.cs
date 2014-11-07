using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayPal.Api
{
    /// <summary>
    /// Represents a PayPal model object that will be returned from PayPal containing common resource data.
    /// </summary>
    public class PayPalResourceObject : PayPalSerializableObject
    {
        /// <summary>
        /// A list of HATEOAS (Hypermedia as the Engine of Application State) links.
        /// More information: https://developer.paypal.com/docs/api/#hateoas-links
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "links")]
        public List<Links> links { get; set; }
    }
}
