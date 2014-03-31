using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Cost
	{
		/// <summary>
		/// Cost in percent. Range of 0 to 100.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public float percent
		{
			get;
			set;
		}
	
		/// <summary>
		/// Cost in amount. Range of 0 to 999999.99.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Currency amount
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


