using Newtonsoft.Json;
using System.Collections.Generic;
using PayPal.Util;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Capture
    {
        /// <summary>
        /// Identifier of the Capture transaction.
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
        /// Amount being captured. If no amount is specified, amount is used from the authorization being captured. If amount is same as the amount that's authorized for, the state of the authorization changes to captured. If not, the state of the authorization changes to partially_captured. Alternatively, you could indicate a final capture by seting the is_final_capture flag to true.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Amount amount { get; set; }

        /// <summary>
        /// whether this is a final capture for the given authorization or not. If it's final, all the remaining funds held by the authorization, will be released in the funding instrument.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "is_final_capture")]
        public bool? is_final_capture { get; set; }

        /// <summary>
        /// State of the capture transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

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
        /// Obtain the Capture transaction resource for the given identifier.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="captureId">string</param>
        /// <returns>Capture</returns>
        public static Capture Get(string accessToken, string captureId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, captureId);
        }

        /// <summary>
        /// Obtain the Capture transaction resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="captureId">string</param>
        /// <returns>Capture</returns>
        public static Capture Get(APIContext apiContext, string captureId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(captureId, "captureId");

            // Configure and send the request
            object[] parameters = new object[] { captureId };
            string pattern = "v1/payments/capture/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Capture>(apiContext, HttpMethod.GET, resourcePath, payLoad);
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
            string pattern = "v1/payments/capture/{0}/refund";
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
