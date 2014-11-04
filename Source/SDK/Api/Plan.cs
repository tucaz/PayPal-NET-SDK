using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal;
using PayPal.Util;
using PayPal.Api;

namespace PayPal.Api
{
    public class Plan
    {
        /// <summary>
        /// Identifier of the billing plan. 128 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Name of the billing plan. 128 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Description of the billing plan. 128 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
        public string description { get; set; }

        /// <summary>
        /// Type of the billing plan. Allowed values: `FIXED`, `INFINITE`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string type { get; set; }

        /// <summary>
        /// Status of the billing plan. Allowed values: `CREATED`, `ACTIVE`, `INACTIVE`, and `DELETED`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Time when the billing plan was created. Format YYYY-MM-DDTimeTimezone, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time when this billing plan was updated. Format YYYY-MM-DDTimeTimezone, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Array of payment definitions for this billing plan.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_definitions")]
        public List<PaymentDefinition> payment_definitions { get; set; }

        /// <summary>
        /// Array of terms for this billing plan.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "terms")]
        public List<Terms> terms { get; set; }

        /// <summary>
        /// Specific preferences such as: set up fee, max fail attempts, autobill amount, and others that are configured for this billing plan.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_preferences")]
        public MerchantPreferences merchant_preferences { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "links")]
        public List<Links> links { get; set; }

        /// <summary>
        /// Retrieve the details for a particular billing plan by passing the billing plan ID to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="planId">string</param>
        /// <returns>Plan</returns>
        public static Plan Get(string accessToken, string planId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, planId);
        }

        /// <summary>
        /// Retrieve the details for a particular billing plan by passing the billing plan ID to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="planId">string</param>
        /// <returns>Plan</returns>
        public static Plan Get(APIContext apiContext, string planId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(planId, "planId");

            // Configure and send the request
            object[] parameters = new object[] { planId };
            string pattern = "v1/payments/billing-plans/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Plan>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Create a new billing plan by passing the details for the plan, including the plan name, description, and type, to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>Plan</returns>
        public Plan Create(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Create(apiContext);
        }

        /// <summary>
        /// Create a new billing plan by passing the details for the plan, including the plan name, description, and type, to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Plan</returns>
        public Plan Create(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            string resourcePath = "v1/payments/billing-plans";
            string payLoad = this.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<Plan>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Replace specific fields within a billing plan by passing the ID of the billing plan to the request URI. In addition, pass a patch object in the request JSON that specifies the operation to perform, field to update, and new value for each update.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        /// <returns></returns>
        public void Update(string accessToken, PatchRequest patchRequest)
        {
            APIContext apiContext = new APIContext(accessToken);
            Update(apiContext, patchRequest);
            return;
        }

        /// <summary>
        /// Replace specific fields within a billing plan by passing the ID of the billing plan to the request URI. In addition, pass a patch object in the request JSON that specifies the operation to perform, field to update, and new value for each update.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        /// <returns></returns>
        public void Update(APIContext apiContext, PatchRequest patchRequest)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(patchRequest, "patchRequest");

            // Configure and send the request
            object[] parameters = new object[] { this.id };
            string pattern = "v1/payments/billing-plans/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = patchRequest.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.PATCH, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// List billing plans according to optional query string parameters specified.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>PlanList</returns>
        public static PlanList List(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return List(apiContext);
        }

        /// <summary>
        /// List billing plans according to optional query string parameters specified.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>PlanList</returns>
        public static PlanList List(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            string resourcePath = "v1/payments/billing-plans";
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<PlanList>(apiContext, HttpMethod.GET, resourcePath, payLoad);
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
