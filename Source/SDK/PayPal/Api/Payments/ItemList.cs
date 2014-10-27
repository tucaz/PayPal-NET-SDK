using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class ItemList
    {
        /// <summary>
        /// List of items.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "items")]
        public List<Item> items { get; set; }

        /// <summary>
        /// Shipping address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "shipping_address")]
        public ShippingAddress shipping_address { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
