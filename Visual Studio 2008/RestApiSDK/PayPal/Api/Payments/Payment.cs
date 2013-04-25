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
	public class Payment : Resource  
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
		/// intent
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string intent
		{
			get;
			set;
		}
		

		/// <summary>
		/// payer
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Payer payer
		{
			get;
			set;
		}
		

		/// <summary>
		/// transactions
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<Transaction> transactions
		{
			get;
			set;
		}
		

		/// <summary>
		/// redirect_urls
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public RedirectUrls redirect_urls
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
		/// Get call for Payment.
		/// GET /v1/payments/payment?count=:count&start_id=:start_id&start_index=:start_index&start_time=:start_time&end_time=:end_time&payee_id=:payee_id&sort_by=:sort_by&sort_order=:sort_order
		/// <param name="accessToken">Access Token</param>
		/// <param name="parameters">Dictionary holding query string name and values
		/// having the following values for keys
		/// count,
		/// start_id,
		/// start_index,
		/// start_time,
		/// end_time,
		/// payee_id,
		/// sort_by,
		/// sort_order,
		/// All other keys are ignored
		/// </param>
		/// <returns>Returns PaymentHistory object</returns>
		/// </summary>
		public static PaymentHistory Get(string accessToken, Dictionary<String, String> parameters)
		{
			string pattern = "v1/payments/payment?count={0}&start_id={1}&start_index={2}&start_time={3}&end_time={4}&payee_id={5}&sort_by={6}&sort_order={7}";
			object[] container = new object[] { parameters };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<PaymentHistory>(accessToken, HttpMethod.GET, resourcePath, payLoad);
		}
		
		/// <summary>
		/// Get call for Payment.
		/// GET /v1/payments/payment?count=:count&start_id=:start_id&start_index=:start_index&start_time=:start_time&end_time=:end_time&payee_id=:payee_id&sort_by=:sort_by&sort_order=:sort_order
		/// <param name="apiContext">APIContext required for the call</param>
		/// <param name="parameters">Dictionary holding query string name and values
		/// having the following values for keys
		/// count,
		/// start_id,
		/// start_index,
		/// start_time,
		/// end_time,
		/// payee_id,
		/// sort_by,
		/// sort_order,
		/// All other keys are ignored
		/// </param>
		/// <returns>Returns PaymentHistory object</returns>
		/// </summary>
		public static PaymentHistory Get(APIContext apiContext, Dictionary<String, String> parameters)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			string pattern = "v1/payments/payment?count={0}&start_id={1}&start_index={2}&start_time={3}&end_time={4}&payee_id={5}&sort_by={6}&sort_order={7}";
			object[] container = new object[] { parameters };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<PaymentHistory>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}

		/// <summary>
		/// Get call for Payment.
		/// GET /v1/payments/payment?count=:count&start_id=:start_id&start_index=:start_index&start_time=:start_time&end_time=:end_time&payee_id=:payee_id&sort_by=:sort_by&sort_order=:sort_order
        /// <param name="accessToken">Access Token</param>
		/// <param name="parameters">Container for query strings</param>
		/// <returns>Returns PaymentHistory object</returns>
		/// </summary>
		public static PaymentHistory Get(string accessToken, QueryParameters parameters)
		{
			string pattern = "v1/payments/payment?count={0}&start_id={1}&start_index={2}&start_time={3}&end_time={4}&payee_id={5}&sort_by={6}&sort_order={7}";
			object[] container = new object[] { parameters };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<PaymentHistory>(accessToken, HttpMethod.GET, resourcePath, payLoad);
		}
		
		/// <summary>
		/// Get call for Payment.
		/// GET /v1/payments/payment?count=:count&start_id=:start_id&start_index=:start_index&start_time=:start_time&end_time=:end_time&payee_id=:payee_id&sort_by=:sort_by&sort_order=:sort_order
        /// <param name="apiContext">APIContext required for the call</param>
		/// <param name="parameters">Container for query strings</param>
		/// <returns>Returns PaymentHistory object</returns>
		/// </summary>
		public static PaymentHistory Get(APIContext apiContext, QueryParameters parameters)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			string pattern = "v1/payments/payment?count={0}&start_id={1}&start_index={2}&start_time={3}&end_time={4}&payee_id={5}&sort_by={6}&sort_order={7}";
			object[] container = new object[] { parameters };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<PaymentHistory>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}

		/// <summary>
		/// Create call for Payment.
		/// POST /v1/payments/payment
        /// <param name="accessToken">Access Token</param>
		/// <returns>Returns Payment object</returns>
		/// </summary>
		public Payment Create(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Create(apiContext);
		}
		
		/// <summary>
		/// Create call for Payment.
		/// POST /v1/payments/payment
        /// <param name="apiContext">APIContext used for the API call</param>
		/// <returns>Returns Payment object</returns>
		/// </summary>
		public Payment Create(APIContext apiContext)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			string resourcePath = "v1/payments/payment";
			string payLoad = this.ConvertToJson();	
		return PayPalResource.ConfigureAndExecute<Payment>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}		

		/// <summary>
		/// Get call for Payment.
		/// GET /v1/payments/payment/:paymentId
        /// <param name="accessToken">Access Token</param>
	 	/// <param name="paymentId">PaymentId</param>
		/// <returns>Returns Payment object</returns>
		/// </summary>
		public static Payment Get(string accessToken, string paymentId)
		{
			if (String.IsNullOrEmpty(paymentId))
			{
				throw new System.ArgumentNullException("paymentId cannot be null or empty");
			}
			string pattern = "v1/payments/payment/{0}";
			object[] container = new Object[] { paymentId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<Payment>(accessToken, HttpMethod.GET, resourcePath, payLoad);
		}
		
		/// <summary>
		/// Get call for Payment.
		/// GET /v1/payments/payment/:paymentId
        /// <param name="apiContext">APIContext required for the call</param>
	 	/// <param name="paymentId">PaymentId</param>
		/// <returns>Returns Payment object</returns>
		/// </summary>
		public static Payment Get(APIContext apiContext, string paymentId)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			if (String.IsNullOrEmpty(paymentId))
			{
				throw new System.ArgumentNullException("paymentId cannot be null or empty");
			}
			string pattern = "v1/payments/payment/{0}";
			object[] container = new Object[] { paymentId };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = string.Empty;
			return PayPalResource.ConfigureAndExecute<Payment>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}

		/// <summary>
		/// Execute call for Payment.
		/// POST /v1/payments/payment/:paymentId/execute
        /// <param name="accessToken">Access Token</param>
	 	/// <param name="paymentExecution">PaymentExecution</param>
		/// <returns>Returns Payment object</returns>
		/// </summary>
		public Payment Execute(string accessToken, PaymentExecution paymentExecution)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Execute(apiContext, paymentExecution);
		}
		
		/// <summary>
		/// Execute call for Payment.
		/// POST /v1/payments/payment/:paymentId/execute
        /// <param name="apiContext">APIContext used for the API call</param>
	 	/// <param name="paymentExecution">PaymentExecution</param>
		/// <returns>Returns Payment object</returns>
		/// </summary>
		public Payment Execute(APIContext apiContext, PaymentExecution paymentExecution)
		{
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null");
			}
			if (paymentExecution == null)
			{
				throw new System.ArgumentNullException("paymentExecution cannot be null");
			}
			if (this.id == null)
			{
				throw new System.ArgumentNullException("Id cannot be null");
			}
			string pattern = "v1/payments/payment/{0}/execute";
			object[] container = new Object[] { this.id };
			string resourcePath = SDKUtil.FormatURIPath(pattern, container);
			string payLoad = paymentExecution.ConvertToJson();	
		return PayPalResource.ConfigureAndExecute<Payment>(apiContext, HttpMethod.POST, resourcePath, payLoad);
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
