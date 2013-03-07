using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class RedirectUrls : Resource  
	{

		/// <summary>
		/// return_url
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string return_url
		{
			get;
			set;
		}
		

		/// <summary>
		/// cancel_url
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string cancel_url
		{
			get;
			set;
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
