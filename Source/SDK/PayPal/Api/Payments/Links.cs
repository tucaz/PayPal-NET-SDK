using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Links
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string href
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string rel
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public HyperSchema targetSchema
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string method
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string enctype
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public HyperSchema schema
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


