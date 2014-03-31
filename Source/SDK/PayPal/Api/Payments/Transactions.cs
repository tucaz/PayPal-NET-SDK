using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Transactions
	{
		/// <summary>
		/// Amount being collected.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Amount amount
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


