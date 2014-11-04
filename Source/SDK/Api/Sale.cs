using Newtonsoft.Json;
using System.Collections.Generic;
using PayPal.Util;
using PayPal.Api;

namespace PayPal.Api
{
    public class Sale
    {
        /// <summary>
        /// Identifier of the authorization transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Time the resource was created.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time the resource was last updated.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Amount being collected.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Amount amount { get; set; }

        /// <summary>
        /// specifies payment mode of the transaction
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_mode")]
        public string payment_mode { get; set; }

        /// <summary>
        /// State of the sale transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Reason code for the transaction state being Pending or Reversed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reason_code")]
        public string reason_code { get; set; }

        /// <summary>
        /// Protection Eligibility of the Payer 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "protection_eligibility")]
        public string protection_eligibility { get; set; }

        /// <summary>
        /// Protection Eligibility Type of the Payer 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "protection_eligibility_type")]
        public string protection_eligibility_type { get; set; }

        /// <summary>
        /// Expected clearing time for eCheck Transactions
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "clearing_time")]
        public string clearing_time { get; set; }

        /// <summary>
        /// ID of the Payment resource that this transaction is based on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_payment")]
        public string parent_payment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "links")]
        public List<Links> links { get; set; }

        /// <summary>
        /// Obtain the Sale transaction resource for the given identifier.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="saleId">string</param>
        /// <returns>Sale</returns>
        public static Sale Get(string accessToken, string saleId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, saleId);
        }

        /// <summary>
        /// Obtain the Sale transaction resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="saleId">string</param>
        /// <returns>Sale</returns>
        public static Sale Get(APIContext apiContext, string saleId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(saleId, "saleId");

            // Configure and send the request
            object[] parameters = new object[] { saleId };
            string pattern = "v1/payments/sale/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Sale>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Creates (and processes) a new Refund Transaction added as a related resource.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Refund(string accessToken, Refund refund)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Refund(apiContext, refund);
        }

        /// <summary>
        /// Creates (and processes) a new Refund Transaction added as a related resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Refund(APIContext apiContext, Refund refund)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(refund, "refund");

            // Configure and send the request
            object[] parameters = new object[] { this.id };
            string pattern = "v1/payments/sale/{0}/refund";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = refund.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<Refund>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
