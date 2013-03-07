using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class ShippingAddress : Address  
	{

		/// <summary>
		/// recipient_name
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string recipient_name
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
