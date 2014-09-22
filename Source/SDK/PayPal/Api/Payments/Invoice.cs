using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal;
using PayPal.Util;
using PayPal.Api.Payments;
using PayPal.Api.Validation;

namespace PayPal.Api.Payments
{
	public class Invoice
	{
		/// <summary>
		/// Unique invoice resource identifier.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string id { get; set; }
	
		/// <summary>
		/// Unique number that appears on the invoice. If left blank will be auto-incremented from the last number. 25 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string number { get; set; }
	
		/// <summary>
		/// URI of the invoice resource.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string uri { get; set; }
	
		/// <summary>
		/// Status of the invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string status { get; set; }
	
		/// <summary>
		/// Information about the merchant who is sending the invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public MerchantInfo merchant_info { get; set; }
	
		/// <summary>
		/// Email address of invoice recipient (required) and optional billing information. (Note: We currently only allow one recipient).
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<BillingInfo> billing_info { get; set; }
	
		/// <summary>
		/// Shipping information for entities to whom items are being shipped.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public ShippingInfo shipping_info { get; set; }
	
		/// <summary>
		/// List of items included in the invoice. 100 items max per invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<InvoiceItem> items { get; set; }
	
		/// <summary>
		/// Date on which the invoice was enabled. Date format: yyyy-MM-dd z. For example, 2014-02-27 PST
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string invoice_date { get; set; }
	
		/// <summary>
		/// Optional field to pass payment deadline for the invoice. Either term_type or due_date can be passed, but not both.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public PaymentTerm payment_term { get; set; }
	
		/// <summary>
		/// Invoice level discount in percent or amount.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Cost discount { get; set; }
	
		/// <summary>
		/// Shipping cost in percent or amount.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public ShippingCost shipping_cost { get; set; }
	
		/// <summary>
		/// Custom amount applied on an invoice. If a label is included then the amount cannot be empty.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public CustomAmount custom { get; set; }
	
		/// <summary>
		/// Indicates whether tax is calculated before or after a discount. If false (the default), the tax is calculated before a discount. If true, the tax is calculated after a discount.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool tax_calculated_after_discount { get; set; }
	
		/// <summary>
		/// A flag indicating whether the unit price includes tax. Default is false
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool tax_inclusive { get; set; }
	
		/// <summary>
		/// General terms of the invoice. 4000 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string terms { get; set; }
	
		/// <summary>
		/// Note to the payer. 4000 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string note { get; set; }
	
		/// <summary>
		/// Bookkeeping memo that is private to the merchant. 150 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string merchant_memo { get; set; }
	
		/// <summary>
		/// Full URL of an external image to use as the logo. 4000 characters max.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string logo_url { get; set; }
	
		/// <summary>
		/// The total amount of the invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Currency total_amount { get; set; }
	
		/// <summary>
		/// List of payment details for the invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<PaymentDetail> payment_details { get; set; }
	
		/// <summary>
		/// List of refund details for the invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<RefundDetail> refund_details { get; set; }
	
		/// <summary>
		/// Audit information for the invoice.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Metadata metadata { get; set; }
	
		/// <summary>
		/// Creates a new invoice Resource.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>Invoice</returns>
		public Invoice Create(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Create(apiContext);
		}
		
		/// <summary>
		/// Creates a new invoice Resource.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>Invoice</returns>
		public Invoice Create(APIContext apiContext)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
			string resourcePath = "v1/invoicing/invoices";
			string payLoad = this.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<Invoice>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Search for invoice resources.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="search">Search</param>
		/// <returns>Invoices</returns>
		public Invoices Search(string accessToken, Search search)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Search(apiContext, search);
		}
		
		/// <summary>
		/// Search for invoice resources.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="search">Search</param>
		/// <returns>Invoices</returns>
		public Invoices Search(APIContext apiContext, Search search)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(search, "search");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/search";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = search.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<Invoices>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Sends a legitimate invoice to the payer.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns></returns>
		public void Send(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			Send(apiContext);
			return;
		}
		
		/// <summary>
		/// Sends a legitimate invoice to the payer.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns></returns>
		public void Send(APIContext apiContext)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}/send";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Reminds the payer to pay the invoice.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="notification">Notification</param>
		/// <returns></returns>
		public void Remind(string accessToken, Notification notification)
		{
			APIContext apiContext = new APIContext(accessToken);
			Remind(apiContext, notification);
			return;
		}
		
		/// <summary>
		/// Reminds the payer to pay the invoice.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="notification">Notification</param>
		/// <returns></returns>
		public void Remind(APIContext apiContext, Notification notification)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(notification, "notification");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}/remind";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = notification.ConvertToJson();
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Cancels an invoice.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="cancelNotification">CancelNotification</param>
		/// <returns></returns>
		public void Cancel(string accessToken, CancelNotification cancelNotification)
		{
			APIContext apiContext = new APIContext(accessToken);
			Cancel(apiContext, cancelNotification);
			return;
		}
		
		/// <summary>
		/// Cancels an invoice.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="cancelNotification">CancelNotification</param>
		/// <returns></returns>
		public void Cancel(APIContext apiContext, CancelNotification cancelNotification)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(cancelNotification, "cancelNotification");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}/cancel";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = cancelNotification.ConvertToJson();
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Mark the status of the invoice as paid.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="paymentDetail">PaymentDetail</param>
		/// <returns></returns>
		public void RecordPayment(string accessToken, PaymentDetail paymentDetail)
		{
			APIContext apiContext = new APIContext(accessToken);
			RecordPayment(apiContext, paymentDetail);
			return;
		}
		
		/// <summary>
		/// Mark the status of the invoice as paid.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="paymentDetail">PaymentDetail</param>
		/// <returns></returns>
		public void RecordPayment(APIContext apiContext, PaymentDetail paymentDetail)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(paymentDetail, "paymentDetail");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}/record-payment";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = paymentDetail.ConvertToJson();
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Mark the status of the invoice as refunded.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="refundDetail">RefundDetail</param>
		/// <returns></returns>
		public void RecordRefund(string accessToken, RefundDetail refundDetail)
		{
			APIContext apiContext = new APIContext(accessToken);
			RecordRefund(apiContext, refundDetail);
			return;
		}
		
		/// <summary>
		/// Mark the status of the invoice as refunded.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="refundDetail">RefundDetail</param>
		/// <returns></returns>
		public void RecordRefund(APIContext apiContext, RefundDetail refundDetail)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(refundDetail, "refundDetail");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}/record-refund";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = refundDetail.ConvertToJson();
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Get the invoice resource for the given identifier.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="invoiceId">string</param>
		/// <returns>Invoice</returns>
		public static Invoice Get(string accessToken, string invoiceId)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Get(apiContext, invoiceId);
		}
		
		/// <summary>
		/// Get the invoice resource for the given identifier.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="invoiceId">string</param>
		/// <returns>Invoice</returns>
		public static Invoice Get(APIContext apiContext, string invoiceId)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(invoiceId, "invoiceId");

            // Configure and send the request
			object[] parameters = new object[] {invoiceId};
			string pattern = "v1/invoicing/invoices/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			return PayPalResource.ConfigureAndExecute<Invoice>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Get all invoices of a merchant.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>Invoices</returns>
		public static Invoices GetAll(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return GetAll(apiContext);
		}
		
		/// <summary>
		/// Get all invoices of a merchant.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>Invoices</returns>
		public static Invoices GetAll(APIContext apiContext)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
			string pattern = "v1/invoicing/invoices";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			return PayPalResource.ConfigureAndExecute<Invoices>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Full update of the invoice resource for the given identifier.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>Invoice</returns>
		public Invoice Update(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Update(apiContext);
		}
		
		/// <summary>
		/// Full update of the invoice resource for the given identifier.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>Invoice</returns>
		public Invoice Update(APIContext apiContext)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = this.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<Invoice>(apiContext, HttpMethod.PUT, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Delete invoice resource for the given identifier.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns></returns>
		public void Delete(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			Delete(apiContext);
			return;
		}
		
		/// <summary>
		/// Delete invoice resource for the given identifier.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns></returns>
		public void Delete(APIContext apiContext)
		{
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
			apiContext.MaskRequestId = true;
			object[] parameters = new object[] {this.id};
			string pattern = "v1/invoicing/invoices/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.DELETE, resourcePath, payLoad);
			return;
		}
	
		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public virtual string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
	}
}


