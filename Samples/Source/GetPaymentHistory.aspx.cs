// #GetPaymentList Sample
// This sample code demonstrate how you can
// retrieve a list of all Payment resources
// you've created using the Payments API.
// Note: Various query parameters that you can
// use to filter, and paginate through the
// payments list.
// API used: GET /v1/payments/payments
using System;
using System.Web;
using System.Collections.Generic;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PayPal.Util;

namespace PayPal.Sample
{
    public partial class GetPaymentHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;
            try
            {
                // ### Api Context
                // Pass in a `APIContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                 // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext..
                APIContext apiContext = Configuration.GetAPIContext();

                // ###Retrieve
                // Retrieve the PaymentHistory by calling the
                // static `List` method
                // on the Payment resource, and pass the
                // APIContext and the map containing the query parameters 
                // for paginations and filtering.
                // Refer the API documentation
                // for valid values for keys
                PaymentHistory payHistory = Payment.List(apiContext, count: 10, startIndex: 5);
                CurrContext.Items.Add("ResponseJson", Common.FormatJsonString(payHistory.ConvertToJson()));
            }
            catch (PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            Server.Transfer("~/Response.aspx");
        }
    }
}
