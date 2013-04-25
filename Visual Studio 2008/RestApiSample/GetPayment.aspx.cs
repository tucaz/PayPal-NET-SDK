// #GetPayment Sample
// This sample code demonstrates how you can retrieve
// the details of a payment resource.
// API used: /v1/payments/payment/{payment-i
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

namespace RestApiSample
{
    public partial class GetPayment : System.Web.UI.Page
    {
        // ##GetPaymentByPaymentId
        // Call the method with a valid Payment ID
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
                string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperties()["ClientID"], ConfigManager.Instance.GetProperties()["ClientSecret"]).GetAccessToken();

                // Retrieve the payment object by calling the
                // static `Get` method
                // on the Payment class by passing a valid
                // AccessToken and Payment ID
                Payment pymnt = Payment.Get(accessToken, "PAY-0XL713371A312273YKE2GCNI");

                CurrContext.Items.Add("ResponseJson", JObject.Parse(pymnt.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            Server.Transfer("~/Response.aspx");
        }
    }
}
