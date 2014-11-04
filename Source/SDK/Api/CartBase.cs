using Newtonsoft.Json;

namespace PayPal.Api
{
    public class CartBase
    {
        /// <summary>
        /// Amount being collected.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Amount amount { get; set; }

        /// <summary>
        /// Recipient of the funds in this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payee")]
        public Payee payee { get; set; }

        /// <summary>
        /// Description of what is being paid for.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
        public string description { get; set; }

        /// <summary>
        /// Note to the recipient of the funds in this transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note_to_payee")]
        public string note_to_payee { get; set; }

        /// <summary>
        /// free-form field for the use of clients
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "custom")]
        public string custom { get; set; }

        /// <summary>
        /// invoice number to track this payment
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "invoice_number")]
        public string invoice_number { get; set; }

        /// <summary>
        /// Soft descriptor used when charging this funding source.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "soft_descriptor")]
        public string soft_descriptor { get; set; }

        /// <summary>
        /// Payment options requested for this purchase unit
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_options")]
        public PaymentOptions payment_options { get; set; }

        /// <summary>
        /// List of items being paid for.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_list")]
        public ItemList item_list { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
