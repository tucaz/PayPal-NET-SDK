using Newtonsoft.Json;
using PayPal.Util;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
    public class Order
    {
        /// <summary>
        /// Identifier of the order transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Identifier to the purchase unit associated with this object
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "purchase_unit_reference_id")]
        public string purchase_unit_reference_id { get; set; }

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
        /// State of the order transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

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
        /// Obtain the Order resource for the given identifier.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="orderId">string</param>
        /// <returns>Order</returns>
        public static Order Get(string accessToken, string orderId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, orderId);
        }

        /// <summary>
        /// Obtain the Order resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="orderId">string</param>
        /// <returns>Order</returns>
        public static Order Get(APIContext apiContext, string orderId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(orderId, "orderId");

            // Configure and send the request
            object[] parameters = new object[] { orderId };
            string pattern = "v1/payments/orders/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Order>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Creates (and processes) a new Capture Transaction added as a related resource.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="capture">Capture</param>
        /// <returns>Capture</returns>
        public Capture Capture(string accessToken, Capture capture)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Capture(apiContext, capture);
        }

        /// <summary>
        /// Creates (and processes) a new Capture Transaction added as a related resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="capture">Capture</param>
        /// <returns>Capture</returns>
        public Capture Capture(APIContext apiContext, Capture capture)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(capture, "capture");

            // Configure and send the request
            object[] parameters = new object[] { this.id };
            string pattern = "v1/payments/orders/{0}/capture";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = capture.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<Capture>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Voids (cancels) an Order.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>Order</returns>
        public Order Void(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Void(apiContext);
        }

        /// <summary>
        /// Voids (cancels) an Order.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Order</returns>
        public Order Void(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
            object[] parameters = new object[] { this.id };
            string pattern = "v1/payments/orders/{0}/do-void";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Order>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Creates an authorization on an order
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>Authorization</returns>
        public Authorization Authorize(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Authorize(apiContext);
        }

        /// <summary>
        /// Creates an authorization on an order
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Authorization</returns>
        public Authorization Authorize(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
            object[] parameters = new object[] { this.id };
            string pattern = "v1/payments/orders/{0}/authorize";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = this.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.POST, resourcePath, payLoad);
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
            string pattern = "v1/payments/order/{0}/refund";
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
