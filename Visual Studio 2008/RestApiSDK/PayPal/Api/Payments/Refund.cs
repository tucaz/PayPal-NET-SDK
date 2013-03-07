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
	public class Refund : Resource  
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
		/// sale_id
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string sale_id
		{
			get;
			set;
		}
		

		/// <summary>
		/// capture_id
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string capture_id
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
		/// description
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description
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
		/// Get call for Refund.
		/// GET /v1/payments/refund/:refundId
        /// <param name="accessToken">Access Token</param>
	 	/// <param name="refundId">RefundId</param>
		/// <returns>Returns Refund object</returns>
		/// </summary>
		public static Refund Get(string accessToken, string refundId)
		{
			if (String.IsNullOrEmpty(refundId))
			{
				throw new System.ArgumentNullException("refundId cannot be null or empty");
			}
			string pattern = "v1/payments/refund/{0}";
			object[] container = new Object[] { refundId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<Refund>(accessToken, HttpMethod.GET, resourcePath, payLoad);
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
