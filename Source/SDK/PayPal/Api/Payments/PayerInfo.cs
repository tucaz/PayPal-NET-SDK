using System;
using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class PayerInfo
    {
        /// <summary>
        /// Email address representing the Payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
        public string email { get; set; }

        /// <summary>
        /// External Remember Me id representing the Payer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_remember_me_id")]
        public string external_remember_me_id { get; set; }

        /// <summary>
        /// Account Number representing the Payer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "buyer_account_number")]
        public string buyer_account_number { get; set; }

        /// <summary>
        /// First Name of the Payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_name")]
        public string first_name { get; set; }

        /// <summary>
        /// Last Name of the Payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_name")]
        public string last_name { get; set; }

        /// <summary>
        /// PayPal assigned Payer ID.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer_id")]
        public string payer_id { get; set; }

        /// <summary>
        /// Phone number representing the Payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "phone")]
        public string phone { get; set; }

        /// <summary>
        /// Phone type
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "phone_type")]
        public string phone_type { get; set; }

        /// <summary>
        /// Birth date of the Payer in ISO8601 format (YYYY-MM-DD).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "birth_date")]
        public string birth_date { get; set; }

        /// <summary>
        /// Payer's tax ID.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax_id")]
        public string tax_id { get; set; }

        /// <summary>
        /// Payer's tax ID type.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax_id_type")]
        public string tax_id_type { get; set; }

        /// <summary>
        /// Billing address of the Payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_address")]
        public Address billing_address { get; set; }

        /// <summary>
        /// Obsolete. Use shipping address present in purchase unit.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "shipping_address")]
        [Obsolete("Obsolete. Use shipping address present in purchase unit.")]
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
