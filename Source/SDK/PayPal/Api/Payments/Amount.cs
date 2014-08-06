using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class Amount
	{
		/// <summary>
		/// 3 letter currency code
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string currency
		{
			get;
			set;
		}
	
		/// <summary>
		/// Total amount charged from the Payer account (or card) to Payee. In case of a refund, this is the refunded amount to the original Payer from Payee account.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string total
		{
			get;
			set;
		}
	
		/// <summary>
		/// Additional details of the payment amount.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Details details
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


