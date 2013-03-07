using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class Item : Resource  
	{

		/// <summary>
		/// name
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string name
		{
			get;
			set;
		}
		

		/// <summary>
		/// sku
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string sku
		{
			get;
			set;
		}
		

		/// <summary>
		/// price
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string price
		{
			get;
			set;
		}
		

		/// <summary>
		/// currency
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string currency
		{
			get;
			set;
		}
		

		/// <summary>
		/// quantity
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string quantity
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
