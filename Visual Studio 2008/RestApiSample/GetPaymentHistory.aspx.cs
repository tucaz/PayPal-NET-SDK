// #GetPaymentList Sample
// This sample code demonstrate how you can
// retrieve a list of all Payment resources
// you've created using the Payments API.
// Note various query parameters that you can
// use to filter, and paginate through the
// payments list.
// API used: GET /v1/payments/payments
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PayPal;
using PayPal.Manager;
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
                string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperty("ClientID"), ConfigManager.Instance.GetProperty("ClientSecret")).GetAccessToken();
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
                PaymentHistory paymentHistory = Payment.Get(accessToken, parameters);
                CurrContext.Items.Add("ResponseJson", JObject.Parse(paymentHistory.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            Server.Transfer("~/Response.aspx");
        }
    }
}
