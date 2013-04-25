using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal;
using PayPal.Util;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class CreditCard : Resource  
	{

		/// <summary>
		/// id
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string id
		{
			get;
			set;
		}
		

		/// <summary>
		/// valid_until
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string valid_until
		{
			get;
			set;
		}
		

		/// <summary>
		/// state
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string state
		{
			get;
			set;
		}
		

		/// <summary>
		/// payer_id
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string payer_id
		{
			get;
			set;
		}
		

		/// <summary>
		/// type
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string type
		{
			get;
			set;
		}
		

		/// <summary>
		/// number
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string number
		{
			get;
			set;
		}
		

		/// <summary>
		/// expire_month
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string expire_month
		{
			get;
			set;
		}
		

		/// <summary>
		/// expire_year
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string expire_year
		{
			get;
			set;
		}
		

		/// <summary>
		/// cvv2
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string cvv2
		{
			get;
			set;
		}
		

		/// <summary>
		/// first_name
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string first_name
		{
			get;
			set;
		}
		

		/// <summary>
		/// last_name
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_name
		{
			get;
			set;
		}
		

		/// <summary>
		/// billing_address
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Address billing_address
		{
			get;
			set;
		}
		

		/// <summary>
		/// links
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<Link> links
		{
			get;
			set;
		}
		

		/// <summary>
		/// Create call for CreditCard.
		/// POST /v1/vault/credit-card
        /// <param name="accessToken">Access Token</param>
		/// <returns>Returns CreditCard object</returns>
		/// </summary>
		public CreditCard Create(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Create(apiContext);
		}
		
		/// <summary>
		/// Create call for CreditCard.
		/// POST /v1/vault/credit-card
        /// <param name="apiContext">APIContext used for the API call</param>
		/// <returns>Returns CreditCard object</returns>
		/// </summary>
		public CreditCard Create(APIContext apiContext)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			string resourcePath = "v1/vault/credit-card";
			string payLoad = this.ConvertToJson();	
		return PayPalResource.ConfigureAndExecute<CreditCard>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}		

		/// <summary>
		/// Get call for CreditCard.
		/// GET /v1/vault/credit-card/:creditCardId
        /// <param name="accessToken">Access Token</param>
	 	/// <param name="creditCardId">CreditCardId</param>
		/// <returns>Returns CreditCard object</returns>
		/// </summary>
		public static CreditCard Get(string accessToken, string creditCardId)
		{
			if (String.IsNullOrEmpty(creditCardId))
			{
				throw new System.ArgumentNullException("creditCardId cannot be null or empty");
			}
			string pattern = "v1/vault/credit-card/{0}";
			object[] container = new Object[] { creditCardId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<CreditCard>(accessToken, HttpMethod.GET, resourcePath, payLoad);
		}
		
		/// <summary>
		/// Get call for CreditCard.
		/// GET /v1/vault/credit-card/:creditCardId
        /// <param name="apiContext">APIContext required for the call</param>
	 	/// <param name="creditCardId">CreditCardId</param>
		/// <returns>Returns CreditCard object</returns>
		/// </summary>
		public static CreditCard Get(APIContext apiContext, string creditCardId)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			if (String.IsNullOrEmpty(creditCardId))
			{
				throw new System.ArgumentNullException("creditCardId cannot be null or empty");
			}
			string pattern = "v1/vault/credit-card/{0}";
			object[] container = new Object[] { creditCardId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<CreditCard>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}

		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public new string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
    	
	}
}
