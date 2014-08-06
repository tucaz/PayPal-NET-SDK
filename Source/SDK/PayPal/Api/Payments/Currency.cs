using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Currency
	{
		/// <summary>
		/// 3 letter currency code
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string currency
		{
			get;
			set;
		}
	
		/// <summary>
		/// amount upto 2 decimals represented as string
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string value
		{
			get;
			set;
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


