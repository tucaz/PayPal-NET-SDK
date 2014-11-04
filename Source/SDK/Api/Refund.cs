using Newtonsoft.Json;
using System.Collections.Generic;
using PayPal.Util;
using PayPal.Api;

namespace PayPal.Api
{
    public class Refund
    {
        /// <summary>
        /// Identifier of the refund transaction in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Time the resource was created in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time the resource was last updated in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Details including both refunded amount (to Payer) and refunded fee (to Payee).If amount is not specified, it's assumed to be full refund.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Amount amount { get; set; }

        /// <summary>
        /// State of the refund transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// ID of the Sale transaction being refunded. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sale_id")]
        public string sale_id { get; set; }

        /// <summary>
        /// ID of the Capture transaction being refunded. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "capture_id")]
        public string capture_id { get; set; }

        /// <summary>
        /// ID of the Payment resource that this transaction is based on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_payment")]
        public string parent_payment { get; set; }

        /// <summary>
        /// Description of what is being refunded for.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
        public string description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "links")]
        public List<Links> links { get; set; }

        /// <summary>
        /// Obtain the Refund transaction resource for the given identifier.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="refundId">string</param>
        /// <returns>Refund</returns>
        public static Refund Get(string accessToken, string refundId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, refundId);
        }

        /// <summary>
        /// Obtain the Refund transaction resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="refundId">string</param>
        /// <returns>Refund</returns>
        public static Refund Get(APIContext apiContext, string refundId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(refundId, "refundId");

            // Configure and send the request
            object[] parameters = new object[] { refundId };
            string pattern = "v1/payments/refund/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Refund>(apiContext, HttpMethod.GET, resourcePath, payLoad);
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
