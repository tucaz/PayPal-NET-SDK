using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal;
using PayPal.Util;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{
	public class CreditCard
	{
		/// <summary>
		/// ID of the credit card being saved for later use.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string id
		{
			get;
			set;
		}
	
		/// <summary>
		/// Card number.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string number
		{
			get;
			set;
		}
	
		/// <summary>
		/// Type of the Card (eg. Visa, Mastercard, etc.).
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string type
		{
			get;
			set;
		}
	
		/// <summary>
		/// card expiry month with value 1 - 12.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int expire_month
		{
			get;
			set;
		}
	
		/// <summary>
		/// 4 digit card expiry year
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int expire_year
		{
			get;
			set;
		}
	
		/// <summary>
		/// Card validation code. Only supported when making a Payment but not when saving a credit card for future use.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string cvv2
		{
			get;
			set;
		}
	
		/// <summary>
		/// Card holder's first name.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string first_name
		{
			get;
			set;
		}
	
		/// <summary>
		/// Card holder's last name.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_name
		{
			get;
			set;
		}
	
		/// <summary>
		/// Billing Address associated with this card.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Address billing_address
		{
			get;
			set;
		}
	
		/// <summary>
		/// A unique identifier of the payer generated and provided by the facilitator. This is required when creating or using a tokenized funding instrument.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string payer_id
		{
			get;
			set;
		}
	
		/// <summary>
		/// State of the funding instrument.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string state
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date/Time until this resource can be used fund a payment.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string valid_until
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<Links> links
		{
			get;
			set;
		}
	
		/// <summary>
		/// Creates a new Credit Card Resource (aka Tokenize).
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>CreditCard</returns>
		public CreditCard Create(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Create(apiContext);
		}
		
		/// <summary>
		/// Creates a new Credit Card Resource (aka Tokenize).
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>CreditCard</returns>
		public CreditCard Create(APIContext apiContext)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			string resourcePath = "v1/vault/credit-card";
			string payLoad = this.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<CreditCard>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Obtain the Credit Card resource for the given identifier.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="creditCardId">string</param>
		/// <returns>CreditCard</returns>
		public static CreditCard Get(string accessToken, string creditCardId)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Get(apiContext, creditCardId);
		}
		
		/// <summary>
		/// Obtain the Credit Card resource for the given identifier.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="creditCardId">string</param>
		/// <returns>CreditCard</returns>
		public static CreditCard Get(APIContext apiContext, string creditCardId)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (creditCardId == null)
			{
				throw new ArgumentNullException("creditCardId cannot be null");
			}
			object[] parameters = new object[] {creditCardId};
			string pattern = "v1/vault/credit-card/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			return PayPalResource.ConfigureAndExecute<CreditCard>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Delete the Credit Card resource for the given identifier.
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
		/// Delete the Credit Card resource for the given identifier.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns></returns>
		public void Delete(APIContext apiContext)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (this.id == null)
			{
				throw new ArgumentNullException("Id cannot be null");
			}
			apiContext.MaskRequestId = true;
			object[] parameters = new object[] {this.id};
			string pattern = "v1/vault/credit-card/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.DELETE, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Update information in a previously saved card. Only the modified fields need to be passed in the request.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>CreditCard</returns>
		public CreditCard Update(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Update(apiContext);
		}
		
		/// <summary>
		/// Update information in a previously saved card. Only the modified fields need to be passed in the request.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>CreditCard</returns>
		public CreditCard Update(APIContext apiContext)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (this.id == null)
			{
				throw new ArgumentNullException("Id cannot be null");
			}
			object[] parameters = new object[] {this.id};
			string pattern = "v1/vault/credit-card/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = this.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<CreditCard>(apiContext, HttpMethod.PATCH, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Retrieves a list of Credit Card resources.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="containerDictionary">Dictionary<String, String></param>
		/// <returns>CreditCardHistory</returns>
		public static CreditCardHistory List(string accessToken, Dictionary<String, String> containerDictionary)
		{
			APIContext apiContext = new APIContext(accessToken);
			return List(apiContext, containerDictionary);
		}
		
		/// <summary>
		/// Retrieves a list of Credit Card resources.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="containerDictionary">Dictionary<String, String></param>
		/// <returns>CreditCardHistory</returns>
		public static CreditCardHistory List(APIContext apiContext, Dictionary<String, String> containerDictionary)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (containerDictionary == null)
			{
				throw new ArgumentNullException("containerDictionary cannot be null");
			}
			object[] parameters = new object[] {containerDictionary};
			string pattern = "v1/vault/credit-card?count={0}&start_id={1}&start_index={2}&start_time={3}&end_time={4}&payer_id={5}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			return PayPalResource.ConfigureAndExecute<CreditCardHistory>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
	}
}


