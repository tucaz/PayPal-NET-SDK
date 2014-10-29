using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class FundingInstrument
    {
        /// <summary>
        /// Credit Card information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "credit_card")]
        public CreditCard credit_card { get; set; }

        /// <summary>
        /// Credit Card information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "credit_card_token")]
        public CreditCardToken credit_card_token { get; set; }

        /// <summary>
        /// Payment Card information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_card")]
        public PaymentCard payment_card { get; set; }

        /// <summary>
        /// Payment card token information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_card_token")]
        public PaymentCardToken payment_card_token { get; set; }

        /// <summary>
        /// Bank Account information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bank_account")]
        public ExtendedBankAccount bank_account { get; set; }

        /// <summary>
        /// Bank Account information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bank_account_token")]
        public BankToken bank_account_token { get; set; }

        /// <summary>
        /// Credit funding information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "credit")]
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
