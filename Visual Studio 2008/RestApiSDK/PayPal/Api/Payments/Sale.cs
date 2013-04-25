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
	public class Sale : Resource  
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
		/// create_time
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string create_time
		{
			get;
			set;
		}
		

		/// <summary>
		/// update_time
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string update_time
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
		/// amount
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Amount amount
		{
			get;
			set;
		}
		

		/// <summary>
		/// parent_payment
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string parent_payment
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
		/// Get call for Sale.
		/// GET /v1/payments/sale/:saleId
        /// <param name="accessToken">Access Token</param>
	 	/// <param name="saleId">SaleId</param>
		/// <returns>Returns Sale object</returns>
		/// </summary>
		public static Sale Get(string accessToken, string saleId)
		{
			if (String.IsNullOrEmpty(saleId))
			{
				throw new System.ArgumentNullException("saleId cannot be null or empty");
			}
			string pattern = "v1/payments/sale/{0}";
			object[] container = new Object[] { saleId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<Sale>(accessToken, HttpMethod.GET, resourcePath, payLoad);
		}
		
		/// <summary>
		/// Get call for Sale.
		/// GET /v1/payments/sale/:saleId
        /// <param name="apiContext">APIContext required for the call</param>
	 	/// <param name="saleId">SaleId</param>
		/// <returns>Returns Sale object</returns>
		/// </summary>
		public static Sale Get(APIContext apiContext, string saleId)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			if (String.IsNullOrEmpty(saleId))
			{
				throw new System.ArgumentNullException("saleId cannot be null or empty");
			}
			string pattern = "v1/payments/sale/{0}";
			object[] container = new Object[] { saleId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<Sale>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}

		/// <summary>
		/// Refund call for Sale.
		/// POST /v1/payments/sale/:saleId/refund
        /// <param name="accessToken">Access Token</param>
	 	/// <param name="refund">Refund</param>
		/// <returns>Returns Refund object</returns>
		/// </summary>
		public Refund Refund(string accessToken, Refund refund)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Refund(apiContext, refund);
		}
		
		/// <summary>
		/// Refund call for Sale.
		/// POST /v1/payments/sale/:saleId/refund
        /// <param name="apiContext">APIContext used for the API call</param>
	 	/// <param name="refund">Refund</param>
		/// <returns>Returns Refund object</returns>
		/// </summary>
		public Refund Refund(APIContext apiContext, Refund refund)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			if (refund == null)
			{
				throw new System.ArgumentNullException("refund cannot be null");
			}
			if (this.id == null)
			{
				throw new System.ArgumentNullException("Id cannot be null");
			}
			string pattern = "v1/payments/sale/{0}/refund";
			object[] container = new Object[] { this.id };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = refund.ConvertToJson();	
		return PayPalResource.ConfigureAndExecute<Refund>(apiContext, HttpMethod.POST, resourcePath, payLoad);
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
