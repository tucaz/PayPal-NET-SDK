using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class InputFields
    {
        /// <summary>
        /// Enables the buyer to enter a note to the merchant on the PayPal page during checkout.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? allow_note { get; set; }

        /// <summary>
        /// Determines whether or not PayPal displays shipping address fields on the experience pages. Allowed values: `0`, `1`, or `2`. When set to `0`, PayPal displays the shipping address on the PayPal pages. When set to `1`, PayPal does not display shipping address fields whatsoever. When set to `2`, if you do not pass the shipping address, PayPal obtains it from the buyer's account profile. For digital goods, this field is required, and you must set it to `1`. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int no_shipping { get; set; }

        /// <summary>
        /// Determines whether or not the PayPal pages should display the shipping address and not the shipping address on file with PayPal for this buyer. Displaying the PayPal street address on file does not allow the buyer to edit that address. Allowed values: `0` or `1`. When set to `0`, the PayPal pages should not display the shipping address. When set to `1`, the PayPal pages should display the shipping address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int address_override { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
