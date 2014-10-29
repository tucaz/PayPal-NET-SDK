using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class PaymentCard
    {
        /// <summary>
        /// ID of the credit card being saved for later use.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Card number.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "number")]
        public string number { get; set; }

        /// <summary>
        /// Type of the Card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string type { get; set; }

        /// <summary>
        /// 2 digit card expiry month.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expire_month")]
        public int expire_month { get; set; }

        /// <summary>
        /// 4 digit card expiry year
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expire_year")]
        public int expire_year { get; set; }

        /// <summary>
        /// 2 digit card start month.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start_month")]
        public int start_month { get; set; }

        /// <summary>
        /// 4 digit card start year.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start_year")]
        public int start_year { get; set; }

        /// <summary>
        /// Card validation code. Only supported when making a Payment but not when saving a payment card for future use.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cvv2")]
        public int cvv2 { get; set; }

        /// <summary>
        /// Card holder's first name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_name")]
        public string first_name { get; set; }

        /// <summary>
        /// Card holder's last name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_name")]
        public string last_name { get; set; }

        /// <summary>
        /// Billing Address associated with this card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_address")]
        public Address billing_address { get; set; }

        /// <summary>
        /// A unique identifier of the customer to whom this card account belongs to. Generated and provided by the facilitator. This is required when creating or using a stored funding instrument in vault.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_customer_id")]
        public string external_customer_id { get; set; }

        /// <summary>
        /// State of the funding instrument.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
        public string status { get; set; }

        /// <summary>
        /// Date/Time until this resource can be used fund a payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "valid_until")]
        public string valid_until { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "links")]
        public List<Links> links { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
