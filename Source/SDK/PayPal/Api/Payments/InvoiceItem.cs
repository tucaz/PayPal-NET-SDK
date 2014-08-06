using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class InvoiceItem
	{
		/// <summary>
		/// Name of the item. 60 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string name
		{
			get;
			set;
		}
	
		/// <summary>
		/// Description of the item. 1000 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description
		{
			get;
			set;
		}
	
		/// <summary>
		/// Quantity of the item. Range of 0 to 9999.999.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public float quantity
		{
			get;
			set;
		}
	
		/// <summary>
		/// Unit price of the item. Range of -999999.99 to 999999.99.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Currency unit_price
		{
			get;
			set;
		}
	
		/// <summary>
		/// Tax associated with the item.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Tax tax
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date on which the item or service was provided. Date format: yyyy-MM-dd z. For example, 2014-02-27 PST.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string date
		{
			get;
			set;
		}
	
		/// <summary>
		/// Item discount in percent or amount.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Cost discount
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


