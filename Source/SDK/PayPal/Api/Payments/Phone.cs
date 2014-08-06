using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Phone
	{
		/// <summary>
		/// Country code (in E.164 format). Assume length is n.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string country_code
		{
			get;
			set;
		}
	
		/// <summary>
		/// In-country phone number (in E.164 format). Maximum (15 - n) digits.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string national_number
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


