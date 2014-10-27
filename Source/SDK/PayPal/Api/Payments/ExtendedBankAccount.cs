using Newtonsoft.Json;

namespace PayPal.Api.Payments
{
    public class ExtendedBankAccount : BankAccount
    {
        /// <summary>
        /// Identifier of the direct debit mandate to validate. Currently supported only for EU bank accounts(SEPA).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "mandate_reference_number")]
        public string mandate_reference_number { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public override string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
