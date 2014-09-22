using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
	public class ShippingInfo
	{
		/// <summary>
		/// First name of the invoice recipient. 30 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string first_name { get; set; }
	
		/// <summary>
		/// Last name of the invoice recipient. 30 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_name { get; set; }
	
		/// <summary>
		/// Company business name of the invoice recipient. 100 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string business_name { get; set; }
	
		/// <summary>
		/// Address of the invoice recipient.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Address address { get; set; }
	
		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public virtual string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
	}
}


