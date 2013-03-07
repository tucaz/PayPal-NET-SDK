using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{

	/// <summary>
	/// 
    /// </summary>
	public class FundingInstrument : Resource  
	{

		/// <summary>
		/// credit_card
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public CreditCard credit_card
		{
			get;
			set;
		}
		

		/// <summary>
		/// credit_card_token
    	/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public CreditCardToken credit_card_token
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
