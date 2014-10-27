using Newtonsoft.Json;
using PayPal.Util;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class WebProfile
    {
        /// <summary>
        /// ID of the web experience profile.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Name of the web experience profile.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Parameters for flow configuration.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flow_config")]
        public FlowConfig flow_config { get; set; }

        /// <summary>
        /// Parameters for input fields customization.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "input_fields")]
        public InputFields input_fields { get; set; }

        /// <summary>
        /// Parameters for style and presentation.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "presentation")]
        public Presentation presentation { get; set; }

        /// <summary>
        /// Create a web experience profile by passing the name of the profile and other profile details in the request JSON to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>CreateProfileResponse</returns>
        public CreateProfileResponse Create(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Create(apiContext);
        }

        /// <summary>
        /// Create a web experience profile by passing the name of the profile and other profile details in the request JSON to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>CreateProfileResponse</returns>
        public CreateProfileResponse Create(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            string resourcePath = "v1/payment-experience/web-profiles";
            string payLoad = this.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<CreateProfileResponse>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Update a web experience profile by passing the ID of the profile to the request URI. In addition, pass the profile details in the request JSON. If your request does not include values for all profile detail fields, the previously set values for the omitted fields are removed by this operation.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns></returns>
        public void Update(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            Update(apiContext);
            return;
        }

        /// <summary>
        /// Update a web experience profile by passing the ID of the profile to the request URI. In addition, pass the profile details in the request JSON. If your request does not include values for all profile detail fields, the previously set values for the omitted fields are removed by this operation.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns></returns>
        public void Update(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payment-experience/web-profiles/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = this.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.PUT, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Partially update an existing web experience profile by passing the ID of the profile to the request URI. In addition, pass a patch object in the request JSON that specifies the operation to perform, path of the profile location to update, and a new value if needed to complete the operation.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="patchRequest"></param>
        /// <returns></returns>
        public void PartialUpdate(string accessToken, PatchRequest patchRequest)
        {
            APIContext apiContext = new APIContext(accessToken);
            PartialUpdate(apiContext, patchRequest);
            return;
        }

        /// <summary>
        /// Partially update an existing web experience profile by passing the ID of the profile to the request URI. In addition, pass a patch object in the request JSON that specifies the operation to perform, path of the profile location to update, and a new value if needed to complete the operation.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="patchRequest"></param>
        /// <returns></returns>
        public void PartialUpdate(APIContext apiContext, PatchRequest patchRequest)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(patchRequest, "patchRequest");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payment-experience/web-profiles/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = patchRequest.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.PATCH, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Retrieve the details of a particular web experience profile by passing the ID of the profile to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="profileId">string</param>
        /// <returns>WebProfile</returns>
        public static WebProfile Get(string accessToken, string profileId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, profileId);
        }

        /// <summary>
        /// Retrieve the details of a particular web experience profile by passing the ID of the profile to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="profileId">string</param>
        /// <returns>WebProfile</returns>
        public static WebProfile Get(APIContext apiContext, string profileId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(profileId, "profileId");

            // Configure and send the request
            object[] parameters = new object[] {profileId};
            string pattern = "v1/payment-experience/web-profiles/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<WebProfile>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Lists all web experience profiles that exist for a merchant (or subject).
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>WebProfileList</returns>
        public static WebProfileList GetList(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return GetList(apiContext);
        }

        /// <summary>
        /// Lists all web experience profiles that exist for a merchant (or subject).
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>WebProfileList</returns>
        public static WebProfileList GetList(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            string resourcePath = "v1/payment-experience/web-profiles";
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<WebProfileList>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Delete an existing web experience profile by passing the profile ID to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns></returns>
        public void Delete(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            Delete(apiContext);
            return;
        }

        /// <summary>
        /// Delete an existing web experience profile by passing the profile ID to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns></returns>
        public void Delete(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
            apiContext.MaskRequestId = true;
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payment-experience/web-profiles/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.DELETE, resourcePath, payLoad);
            return;
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
