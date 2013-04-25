// # Get Details of a Sale Transaction Sample
// This sample code demonstrates how you can retrieve 
// details of completed Sale Transaction.
// API used: /v1/payments/sale/{sale-id}
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
    public partial class GetSale : System.Web.UI.Page
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
                string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperties()["ClientID"], ConfigManager.Instance.GetProperties()["ClientSecret"]).GetAccessToken();

                // ### Sale
                // Pass an AccessToken and the ID of the sale
                // transaction from your payment resource.
                Sale s = Sale.Get(accessToken, "4V7971043K262623A");
                CurrContext.Items.Add("ResponseJson",
                    JObject.Parse(s.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            Server.Transfer("~/Response.aspx");
        }
    }
}
