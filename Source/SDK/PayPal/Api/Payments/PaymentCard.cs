using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class PaymentCard
    {
        /// <summary>
        /// ID of the credit card being saved for later use.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

        /// <summary>
        /// Card number.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string number { get; set; }

        /// <summary>
        /// Type of the Card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }

        /// <summary>
        /// 2 digit card expiry month.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int expire_month { get; set; }

        /// <summary>
        /// 4 digit card expiry year
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int expire_year { get; set; }

        /// <summary>
        /// 2 digit card start month.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int start_month { get; set; }

        /// <summary>
        /// 4 digit card start year.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int start_year { get; set; }

        /// <summary>
        /// Card validation code. Only supported when making a Payment but not when saving a payment card for future use.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int cvv2 { get; set; }

        /// <summary>
        /// Card holder's first name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string first_name { get; set; }

        /// <summary>
        /// Card holder's last name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string last_name { get; set; }

        /// <summary>
        /// Billing Address associated with this card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Address billing_address { get; set; }

        /// <summary>
        /// A unique identifier of the customer to whom this card account belongs to. Generated and provided by the facilitator. This is required when creating or using a stored funding instrument in vault.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string external_customer_id { get; set; }

        /// <summary>
        /// State of the funding instrument.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }

        /// <summary>
        /// Date/Time until this resource can be used fund a payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string valid_until { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
