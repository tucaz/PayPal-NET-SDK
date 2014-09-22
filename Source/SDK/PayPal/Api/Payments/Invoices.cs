using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
	public class Invoices
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int total_count { get; set; }
	
		/// <summary>
		/// List of invoices belonging to a merchant.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<Invoice> invoices { get; set; }
	
		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public virtual string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
	}
}


