using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
	public class InvoicingPaymentDetail
	{
		/// <summary>
		/// PayPal payment detail indicating whether payment was made in an invoicing flow via PayPal or externally. In the case of the mark-as-paid API, payment type is EXTERNAL and this is what is now supported. The PAYPAL value is provided for backward compatibility.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string type { get; set; }
	
		/// <summary>
		/// PayPal payment transaction id. Mandatory field in case the type value is PAYPAL.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string transaction_id { get; set; }
	
		/// <summary>
		/// Type of the transaction.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string transaction_type { get; set; }
	
		/// <summary>
		/// Date when the invoice was paid. Date format: yyyy-MM-dd z. For example, 2014-02-27 PST.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string date { get; set; }
	
		/// <summary>
		/// Payment mode or method. This field is mandatory if the value of the type field is OTHER.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string method { get; set; }
	
		/// <summary>
		/// Optional note associated with the payment.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string note { get; set; }
	
		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public virtual string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
	}
}


