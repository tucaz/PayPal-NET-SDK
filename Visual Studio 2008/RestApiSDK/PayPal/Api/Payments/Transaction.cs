using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class Transaction : Resource  
	{

		/// <summary>
		/// amount
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Amount amount
		{
			get;
			set;
		}
		

		/// <summary>
		/// payee
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Payee payee
		{
			get;
			set;
		}
		

		/// <summary>
		/// description
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description
		{
			get;
			set;
		}
		

		/// <summary>
		/// item_list
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public ItemList item_list
		{
			get;
			set;
		}
		

		/// <summary>
		/// related_resources
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<SubTransaction> related_resources
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
