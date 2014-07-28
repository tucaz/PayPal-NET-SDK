using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.Api.Payments
{
	public class MerchantInfo
	{
		/// <summary>
		/// Email address of the merchant. 260 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string email
		{
			get;
			set;
		}
	
		/// <summary>
		/// First name of the merchant. 30 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string first_name
		{
			get;
			set;
		}
	
		/// <summary>
		/// Last name of the merchant. 30 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string last_name
		{
			get;
			set;
		}
	
		/// <summary>
		/// Address of the merchant.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Address address
		{
			get;
			set;
		}
	
		/// <summary>
		/// Company business name of the merchant. 100 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string business_name
		{
			get;
			set;
		}
	
		/// <summary>
		/// Phone number of the merchant.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Phone phone
		{
			get;
			set;
		}
	
		/// <summary>
		/// Fax number of the merchant.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Phone fax
		{
			get;
			set;
		}
	
		/// <summary>
		/// Website of the merchant. 2048 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string website
		{
			get;
			set;
		}
	
		/// <summary>
		/// Tax ID of the merchant. 100 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string tax_id
		{
			get;
			set;
		}
	
		/// <summary>
		/// Option to display additional information such as business hours. 40 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string additional_info
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


