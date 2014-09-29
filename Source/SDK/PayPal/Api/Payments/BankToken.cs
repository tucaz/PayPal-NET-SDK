using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class BankToken
    {
        /// <summary>
        /// ID of a previously saved Bank resource using /vault/bank API.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string bank_id { get; set; }

        /// <summary>
        /// The unique identifier of the payer used when saving this bank using /vault/bank API.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string external_customer_id { get; set; }

        /// <summary>
        /// Identifier of the direct debit mandate to validate. Currently supported only for EU bank accounts(SEPA).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string mandate_reference_number { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
