using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
	public class Error
	{
		/// <summary>
		/// Human readable, unique name of the error.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string name
		{
			get;
			set;
		}
	
		/// <summary>
		/// PayPal internal identifier used for correlation purposes.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string debug_id
		{
			get;
			set;
		}
	
		/// <summary>
		/// Message describing the error.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string message
		{
			get;
			set;
		}
	
		/// <summary>
		/// URI for detailed information related to this error for the developer.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string information_link
		{
			get;
			set;
		}
	
		/// <summary>
		/// Additional details of the error
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<ErrorDetails> details
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


