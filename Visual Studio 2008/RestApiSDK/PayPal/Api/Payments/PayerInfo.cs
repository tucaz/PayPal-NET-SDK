using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class PayerInfo : Resource  
	{

		/// <summary>
		/// email
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string email
		{
			get;
			set;
		}
		

		/// <summary>
		/// first_name
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string first_name
		{
			get;
			set;
		}
		

		/// <summary>
		/// last_name
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_name
		{
			get;
			set;
		}
		

		/// <summary>
		/// payer_id
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string payer_id
		{
			get;
			set;
		}
		

		/// <summary>
		/// shipping_address
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Address shipping_address
		{
			get;
			set;
		}
		

		/// <summary>
		/// phone
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string phone
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
