using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Notification
	{
		/// <summary>
		/// Subject of the notification.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string subject
		{
			get;
			set;
		}
	
		/// <summary>
		/// Note to the payer.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string note
		{
			get;
			set;
		}
	
		/// <summary>
		/// A flag indicating whether a copy of the email has to be sent to the merchant.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool send_to_merchant
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


