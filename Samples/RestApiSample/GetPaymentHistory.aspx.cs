// #GetPaymentList Sample
// This sample code demonstrate how you can
// retrieve a list of all Payment resources
// you've created using the Payments API.
// Note various query parameters that you can
// use to filter, and paginate through the
// payments list.
// API used: GET /v1/payments/payments
using System;
using System.Web;
using PayPal;
using PayPal.Api.Payments;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PayPal.Util;

namespace RestApiSample
{
    public partial class GetPaymentHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;
            try
            {
                // ###AccessToken
                // Retrieve the access token from
                // OAuthTokenCredential by passing in
                // ClientID and ClientSecret
                // It is not mandatory to generate Access Token on a per call basis.
                // Typically the access token can be generated once and
                // reused within the expiry window                
                string accessToken = new OAuthTokenCredential(Configuration.GetClientDetailsAndConfig()["Client ID"], Configuration.GetClientDetailsAndConfig()["Secret"], Configuration.GetConfig()).GetAccessToken();
                
                // ### Api Context
                // Pass in a `ApiContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                APIContext context = new APIContext(accessToken);
                context.Config = Configuration.GetConfig();

                var parameters = new QueryParameters();
                parameters.SetCount("10");
                parameters.SetStartIndex("5");

                // ###Retrieve
                // Retrieve the PaymentHistory object by calling the
                // static `Get` method
                // on the Payment class, and pass the
                // AccessToken and a QueryParameters object that contains
                // query parameters for paginations and filtering.
                // Refer the API documentation
                // for valid values for keys
                PaymentHistory payHistory = Payment.List(context, Configuration.GetConfig());
                CurrContext.Items.Add("ResponseJson", JObject.Parse(payHistory.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            Server.Transfer("~/Response.aspx");
        }
    }
}
