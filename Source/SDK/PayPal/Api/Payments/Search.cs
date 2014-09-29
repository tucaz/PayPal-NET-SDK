using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Search
    {
        /// <summary>
        /// Initial letters of the email address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string email { get; set; }

        /// <summary>
        /// Initial letters of the recipient's first name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string recipient_first_name { get; set; }

        /// <summary>
        /// Initial letters of the recipient's last name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string recipient_last_name { get; set; }

        /// <summary>
        /// Initial letters of the recipient's business name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string recipient_business_name { get; set; }

        /// <summary>
        /// The invoice number that appears on the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string number { get; set; }

        /// <summary>
        /// Status of the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }

        /// <summary>
        /// Lower limit of total amount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Currency lower_total_amount { get; set; }

        /// <summary>
        /// Upper limit of total amount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Currency upper_total_amount { get; set; }

        /// <summary>
        /// Start invoice date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string start_invoice_date { get; set; }

        /// <summary>
        /// End invoice date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string end_invoice_date { get; set; }

        /// <summary>
        /// Start invoice due date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string start_due_date { get; set; }

        /// <summary>
        /// End invoice due date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string end_due_date { get; set; }

        /// <summary>
        /// Start invoice payment date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string start_payment_date { get; set; }

        /// <summary>
        /// End invoice payment date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string end_payment_date { get; set; }

        /// <summary>
        /// Start invoice creation date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string start_creation_date { get; set; }

        /// <summary>
        /// End invoice creation date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string end_creation_date { get; set; }

        /// <summary>
        /// Offset of the search results.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float page { get; set; }

        /// <summary>
        /// Page size of the search results.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float page_size { get; set; }

        /// <summary>
        /// A flag indicating whether total count is required in the response.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool total_count_required { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
