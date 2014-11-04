using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api
{
    public class Item
    {
        /// <summary>
        /// Number of items.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "quantity")]
        public string quantity { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Description of the item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
        public string description { get; set; }

        /// <summary>
        /// Cost of the item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "price")]
        public string price { get; set; }

        /// <summary>
        /// tax of the item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax")]
        public string tax { get; set; }

        /// <summary>
        /// 3-letter Currency Code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "currency")]
        public string currency { get; set; }

        /// <summary>
        /// Number or code to identify the item in your catalog/records.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sku")]
        public string sku { get; set; }

        /// <summary>
        /// URL linking to item information. Available to payer in transaction history.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "url")]
        public string url { get; set; }

        /// <summary>
        /// Category type of the item.  This can be either Digital or Physical.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "category")]
        public string category { get; set; }

        /// <summary>
        /// Set of optional data used for PayPal risk determination.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "supplementary_data")]
        public List<NameValuePair> supplementary_data { get; set; }

        /// <summary>
        /// Set of optional data used for PayPal post-transaction notifications.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "postback_data")]
        public List<NameValuePair> postback_data { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
