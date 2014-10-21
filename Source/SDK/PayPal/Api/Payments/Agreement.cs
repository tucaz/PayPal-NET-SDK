using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal;
using PayPal.Util;
using PayPal.Api.Payments;
using PayPal.Api.Validation;
using System.Web;

namespace PayPal.Api.Payments
{
    public class Agreement
    {
        /// <summary>
        /// Identifier of the agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

        /// <summary>
        /// Name of the agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        /// <summary>
        /// State of the agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string state { get; set; }

        /// <summary>
        /// Description of the agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        /// <summary>
        /// Start date of the agreement. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string start_date { get; set; }

        /// <summary>
        /// Details of the buyer who is enrolling in this agreement. This information is gathered from execution of the approval URL.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Payer payer { get; set; }

        /// <summary>
        /// Shipping address object of the agreement, which should be provided if it is different from the default address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Address shipping_address { get; set; }

        /// <summary>
        /// Default merchant preferences from the billing plan are used, unless override preferences are provided here.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MerchantPreferences override_merchant_preferences { get; set; }

        /// <summary>
        /// Array of override_charge_model for this agreement if needed to change the default models from the billing plan.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<OverrideChargeModel> override_charge_models { get; set; }

        /// <summary>
        /// Plan details for this agreement.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Plan plan { get; set; }

        /// <summary>
        /// Date and time that this resource was created. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string create_time { get; set; }

        /// <summary>
        /// Date and time that this resource was updated. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string update_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Links> links { get; set; }

        /// <summary>
        /// Get or sets the EC token returned from a call to create an agreement and to be used when executing an agreement.
        /// </summary>
        [JsonIgnore]
        public string token { get; set; }

        /// <summary>
        /// Create a new billing agreement by passing the details for the agreement, including the name, description, start date, payer, and billing plan in the request JSON.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>Agreement</returns>
        public Agreement Create(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Create(apiContext);
        }

        /// <summary>
        /// Create a new billing agreement by passing the details for the agreement, including the name, description, start date, payer, and billing plan in the request JSON.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Agreement</returns>
        public Agreement Create(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            string resourcePath = "v1/payments/billing-agreements";
            string payLoad = this.ConvertToJson();
            var agreement = PayPalResource.ConfigureAndExecute<Agreement>(apiContext, HttpMethod.POST, resourcePath, payLoad);

            // Store the token referenced in the approval_url of the returned object.
            foreach (var links in agreement.links)
            {
                if (links.rel.Equals("approval_url"))
                {
                    var url = new Uri(links.href);
                    agreement.token = HttpUtility.ParseQueryString(url.Query).Get("token");
                    break;
                }
            }
            return agreement;
        }

        /// <summary>
        /// Execute a billing agreement after buyer approval by passing the payment token to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>Agreement</returns>
        public Agreement Execute(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Execute(apiContext);
        }

        /// <summary>
        /// Execute a billing agreement after buyer approval by passing the payment token to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Agreement</returns>
        public Agreement Execute(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.token, "token");

            // Configure and send the request
            object[] parameters = new object[] {this.token};
            string pattern = "v1/payments/billing-agreements/{0}/agreement-execute";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Agreement>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Retrieve details for a particular billing agreement by passing the ID of the agreement to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="agreementId">string</param>
        /// <returns>Agreement</returns>
        public static Agreement Get(string accessToken, string agreementId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, agreementId);
        }

        /// <summary>
        /// Retrieve details for a particular billing agreement by passing the ID of the agreement to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="agreementId">string</param>
        /// <returns>Agreement</returns>
        public static Agreement Get(APIContext apiContext, string agreementId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(agreementId, "agreementId");

            // Configure and send the request
            object[] parameters = new object[] {agreementId};
            string pattern = "v1/payments/billing-agreements/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<Agreement>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Update details of a billing agreement, such as the description, shipping address, and start date, by passing the ID of the agreement to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        public void Update(string accessToken, PatchRequest patchRequest)
        {
            APIContext apiContext = new APIContext(accessToken);
            Update(apiContext, patchRequest);
        }

        /// <summary>
        /// Update details of a billing agreement, such as the description, shipping address, and start date, by passing the ID of the agreement to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        public void Update(APIContext apiContext, PatchRequest patchRequest)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(patchRequest, "patchRequest");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payments/billing-agreements/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = patchRequest.ConvertToJson();
            PayPalResource.ConfigureAndExecute<Agreement>(apiContext, HttpMethod.PATCH, resourcePath, payLoad);
        }

        /// <summary>
        /// Suspend a particular billing agreement by passing the ID of the agreement to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void Suspend(string accessToken, AgreementStateDescriptor agreementStateDescriptor)
        {
            APIContext apiContext = new APIContext(accessToken);
            Suspend(apiContext, agreementStateDescriptor);
            return;
        }

        /// <summary>
        /// Suspend a particular billing agreement by passing the ID of the agreement to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void Suspend(APIContext apiContext, AgreementStateDescriptor agreementStateDescriptor)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(agreementStateDescriptor, "agreementStateDescriptor");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payments/billing-agreements/{0}/suspend";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = agreementStateDescriptor.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Reactivate a suspended billing agreement by passing the ID of the agreement to the appropriate URI. In addition, pass an agreement_state_descriptor object in the request JSON that includes a note about the reason for changing the state of the agreement and the amount and currency for the agreement.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void ReActivate(string accessToken, AgreementStateDescriptor agreementStateDescriptor)
        {
            APIContext apiContext = new APIContext(accessToken);
            ReActivate(apiContext, agreementStateDescriptor);
            return;
        }

        /// <summary>
        /// Reactivate a suspended billing agreement by passing the ID of the agreement to the appropriate URI. In addition, pass an agreement_state_descriptor object in the request JSON that includes a note about the reason for changing the state of the agreement and the amount and currency for the agreement.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void ReActivate(APIContext apiContext, AgreementStateDescriptor agreementStateDescriptor)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(agreementStateDescriptor, "agreementStateDescriptor");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payments/billing-agreements/{0}/re-activate";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = agreementStateDescriptor.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Cancel a billing agreement by passing the ID of the agreement to the request URI. In addition, pass an agreement_state_descriptor object in the request JSON that includes a note about the reason for changing the state of the agreement and the amount and currency for the agreement.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void Cancel(string accessToken, AgreementStateDescriptor agreementStateDescriptor)
        {
            APIContext apiContext = new APIContext(accessToken);
            Cancel(apiContext, agreementStateDescriptor);
            return;
        }

        /// <summary>
        /// Cancel a billing agreement by passing the ID of the agreement to the request URI. In addition, pass an agreement_state_descriptor object in the request JSON that includes a note about the reason for changing the state of the agreement and the amount and currency for the agreement.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void Cancel(APIContext apiContext, AgreementStateDescriptor agreementStateDescriptor)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(agreementStateDescriptor, "agreementStateDescriptor");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payments/billing-agreements/{0}/cancel";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = agreementStateDescriptor.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Bill an outstanding amount for an agreement by passing the ID of the agreement to the request URI. In addition, pass an agreement_state_descriptor object in the request JSON that includes a note about the reason for changing the state of the agreement and the amount and currency for the agreement.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void BillBalance(string accessToken, AgreementStateDescriptor agreementStateDescriptor)
        {
            APIContext apiContext = new APIContext(accessToken);
            BillBalance(apiContext, agreementStateDescriptor);
            return;
        }

        /// <summary>
        /// Bill an outstanding amount for an agreement by passing the ID of the agreement to the request URI. In addition, pass an agreement_state_descriptor object in the request JSON that includes a note about the reason for changing the state of the agreement and the amount and currency for the agreement.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="agreementStateDescriptor">AgreementStateDescriptor</param>
        /// <returns></returns>
        public void BillBalance(APIContext apiContext, AgreementStateDescriptor agreementStateDescriptor)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(agreementStateDescriptor, "agreementStateDescriptor");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payments/billing-agreements/{0}/bill-balance";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = agreementStateDescriptor.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Set the balance for an agreement by passing the ID of the agreement to the request URI. In addition, pass a common_currency object in the request JSON that specifies the currency type and value of the balance.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="currency">Currency</param>
        /// <returns></returns>
        public void SetBalance(string accessToken, Currency currency)
        {
            APIContext apiContext = new APIContext(accessToken);
            SetBalance(apiContext, currency);
            return;
        }

        /// <summary>
        /// Set the balance for an agreement by passing the ID of the agreement to the request URI. In addition, pass a common_currency object in the request JSON that specifies the currency type and value of the balance.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="currency">Currency</param>
        /// <returns></returns>
        public void SetBalance(APIContext apiContext, Currency currency)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(currency, "currency");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/payments/billing-agreements/{0}/set-balance";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = currency.ConvertToJson();
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// List transactions for a billing agreement by passing the ID of the agreement, as well as the start and end dates of the range of transactions to list, to the request URI.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="agreementId">string</param>
        /// <returns>AgreementTransactions</returns>
        public static AgreementTransactions ListTransactions(string accessToken, string agreementId, DateTime startDate, DateTime endDate)
        {
            APIContext apiContext = new APIContext(accessToken);
            return ListTransactions(apiContext, agreementId, startDate, endDate);
        }

        /// <summary>
        /// List transactions for a billing agreement by passing the ID of the agreement, as well as the start and end dates of the range of transactions to list, to the request URI.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="agreementId">string</param>
        /// <returns>AgreementTransactions</returns>
        public static AgreementTransactions ListTransactions(APIContext apiContext, string agreementId, DateTime startDate, DateTime endDate)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(agreementId, "agreementId");
            ArgumentValidator.Validate(startDate, "startDate");
            ArgumentValidator.Validate(endDate, "endDate");

            // Configure and send the request
            var dateFormat = "yyyy-MM-dd";
            object[] parameters = new object[] { agreementId, startDate.ToString(dateFormat), endDate.ToString(dateFormat) };
            string pattern = "v1/payments/billing-agreements/{0}/transactions?start_date={1}&end_date={2}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<AgreementTransactions>(apiContext, HttpMethod.GET, resourcePath, payLoad);
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
