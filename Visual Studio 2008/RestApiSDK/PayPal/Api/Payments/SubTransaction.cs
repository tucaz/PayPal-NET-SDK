using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class SubTransaction : Resource  
	{

		/// <summary>
		/// sale
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Sale sale
		{
			get;
			set;
		}
		

		/// <summary>
		/// authorization
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Authorization authorization
		{
			get;
			set;
		}
		

		/// <summary>
		/// refund
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Refund refund
		{
			get;
			set;
		}
		

		/// <summary>
		/// capture
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Capture capture
		{
			get;
			set;
		}
		

		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public new string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
    	
	}
}
