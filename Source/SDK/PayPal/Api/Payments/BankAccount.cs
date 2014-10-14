using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class BankAccount
    {
        /// <summary>
        /// ID of the bank account being saved for later use.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Account number in either IBAN (max length 34) or BBAN (max length 17) format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_number")]
        public string account_number { get; set; }

        /// <summary>
        /// Type of the bank account number (International or Basic Bank Account Number). For more information refer to http://en.wikipedia.org/wiki/International_Bank_Account_Number.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_number_type")]
        public string account_number_type { get; set; }

        /// <summary>
        /// Routing transit number (aka Bank Code) of the bank (typically for domestic use only - for international use, IBAN includes bank code). For more information refer to http://en.wikipedia.org/wiki/Bank_code.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "routing_number")]
        public string routing_number { get; set; }

        /// <summary>
        /// Type of the bank account.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_type")]
        public string account_type { get; set; }

        /// <summary>
        /// A customer designated name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_name")]
        public string account_name { get; set; }

        /// <summary>
        /// Type of the check when this information was obtained through a check by the facilitator or merchant.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "check_type")]
        public string check_type { get; set; }

        /// <summary>
        /// How the check was obtained from the customer, if check was the source of the information provided.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "auth_type")]
        public string auth_type { get; set; }

        /// <summary>
        /// Time at which the authorization (or check) was captured. Use this field if the user authorization needs to be captured due to any privacy requirements.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "auth_capture_timestamp")]
        public string auth_capture_timestamp { get; set; }

        /// <summary>
        /// Name of the bank.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bank_name")]
        public string bank_name { get; set; }

        /// <summary>
        /// 2 letter country code of the Bank.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country_code")]
        public string country_code { get; set; }

        /// <summary>
        /// Account holder's first name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_name")]
        public string first_name { get; set; }

        /// <summary>
        /// Account holder's last name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_name")]
        public string last_name { get; set; }

        /// <summary>
        /// Birth date of the bank account holder.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "birth_date")]
        public string birth_date { get; set; }

        /// <summary>
        /// Billing address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_address")]
        public Address billing_address { get; set; }

        /// <summary>
        /// State of this funding instrument.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Confirmation status of a bank account.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "confirmation_status")]
        public string confirmation_status { get; set; }

        /// <summary>
        /// Deprecated - Use external_customer_id instead.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer_id")]
        public string payer_id { get; set; }

        /// <summary>
        /// A unique identifier of the customer to whom this bank account belongs to. Generated and provided by the facilitator. This is required when creating or using a stored funding instrument in vault.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_customer_id")]
        public string external_customer_id { get; set; }

        /// <summary>
        /// A unique identifier of the merchant for which this bank account has been stored for. Generated and provided by the facilitator so it can be used to restrict the usage of the bank account to the specific merchnt.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_id")]
        public string merchant_id { get; set; }

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
        /// Date/Time until this resource can be used to fund a payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "valid_until")]
        public string valid_until { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "links")]
        public List<Links> links { get; set; }

        /// <summary>
        /// Creates a new Bank Account Resource.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <returns>BankAccount</returns>
        public BankAccount Create(string accessToken)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Create(apiContext);
        }

        /// <summary>
        /// Creates a new Bank Account Resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>BankAccount</returns>
        public BankAccount Create(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            string resourcePath = "v1/vault/bank-accounts";
            string payLoad = this.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<BankAccount>(apiContext, HttpMethod.POST, resourcePath, payLoad);
        }

        /// <summary>
        /// Obtain the Bank Account resource for the given identifier.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="bankAccountId">string</param>
        /// <returns>BankAccount</returns>
        public static BankAccount Get(string accessToken, string bankAccountId)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Get(apiContext, bankAccountId);
        }

        /// <summary>
        /// Obtain the Bank Account resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="bankAccountId">string</param>
        /// <returns>BankAccount</returns>
        public static BankAccount Get(APIContext apiContext, string bankAccountId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(bankAccountId, "bankAccountId");

            // Configure and send the request
            object[] parameters = new object[] {bankAccountId};
            string pattern = "v1/vault/bank-accounts/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            return PayPalResource.ConfigureAndExecute<BankAccount>(apiContext, HttpMethod.GET, resourcePath, payLoad);
        }

        /// <summary>
        /// Delete the bank account resource for the given identifier.
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
        /// Delete the bank account resource for the given identifier.
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
            string pattern = "v1/vault/bank-accounts/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = "";
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.DELETE, resourcePath, payLoad);
            return;
        }

        /// <summary>
        /// Update information in a previously saved bank account. Only the modified fields need to be passed in the request.
        /// </summary>
        /// <param name="accessToken">Access Token used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        /// <returns>BankAccount</returns>
        public BankAccount Update(string accessToken, PatchRequest patchRequest)
        {
            APIContext apiContext = new APIContext(accessToken);
            return Update(apiContext, patchRequest);
        }

        /// <summary>
        /// Update information in a previously saved bank account. Only the modified fields need to be passed in the request.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        /// <returns>BankAccount</returns>
        public BankAccount Update(APIContext apiContext, PatchRequest patchRequest)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(patchRequest, "patchRequest");

            // Configure and send the request
            object[] parameters = new object[] {this.id};
            string pattern = "v1/vault/bank-accounts/{0}";
            string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
            string payLoad = patchRequest.ConvertToJson();
            return PayPalResource.ConfigureAndExecute<BankAccount>(apiContext, HttpMethod.PATCH, resourcePath, payLoad);
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
