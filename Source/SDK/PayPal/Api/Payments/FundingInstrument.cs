using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class FundingInstrument
    {
        /// <summary>
        /// Credit Card information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CreditCard credit_card { get; set; }

        /// <summary>
        /// Credit Card information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CreditCardToken credit_card_token { get; set; }

        /// <summary>
        /// Payment Card information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PaymentCard payment_card { get; set; }

        /// <summary>
        /// Payment card token information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PaymentCardToken payment_card_token { get; set; }

        /// <summary>
        /// Bank Account information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ExtendedBankAccount bank_account { get; set; }

        /// <summary>
        /// Bank Account information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BankToken bank_account_token { get; set; }

        /// <summary>
        /// Credit funding information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Credit credit { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
