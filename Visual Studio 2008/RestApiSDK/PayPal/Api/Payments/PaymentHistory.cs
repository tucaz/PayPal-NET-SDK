using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class PaymentHistory : Resource  
	{

		/// <summary>
		/// payments
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<Payment> payments
		{
			get;
			set;
		}
		

		/// <summary>
		/// count
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? count
		{
			get;
			set;
		}
		

		/// <summary>
		/// next_id
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string next_id
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
