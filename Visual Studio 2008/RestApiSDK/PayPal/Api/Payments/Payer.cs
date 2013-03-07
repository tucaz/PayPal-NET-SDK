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
	public class Payer : Resource  
	{

		/// <summary>
		/// payment_method
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string payment_method
		{
			get;
			set;
		}
		

		/// <summary>
		/// payer_info
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public PayerInfo payer_info
		{
			get;
			set;
		}
		

		/// <summary>
		/// funding_instruments
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<FundingInstrument> funding_instruments
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
