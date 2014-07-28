using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Metadata
	{
		/// <summary>
		/// Date when the resource was created.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string created_date
		{
			get;
			set;
		}
	
		/// <summary>
		/// Email address of the account that created the resource.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string created_by
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date when the resource was cancelled.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string cancelled_date
		{
			get;
			set;
		}
	
		/// <summary>
		/// Actor who cancelled the resource.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string cancelled_by
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date when the resource was last edited.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_updated_date
		{
			get;
			set;
		}
	
		/// <summary>
		/// Email address of the account that last edited the resource.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_updated_by
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date when the resource was first sent.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string first_sent_date
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date when the resource was last sent.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_sent_date
		{
			get;
			set;
		}
	
		/// <summary>
		/// Email address of the account that last sent the resource.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_sent_by
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


