// # Get Details of a Sale Transaction Sample
// This sample code demonstrates how you can retrieve 
// details of completed Sale Transaction.
// API used: /v1/payments/sale/{sale-id}
using System;
using System.Web;
using PayPal;
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
                string accessToken = new OAuthTokenCredential(Configuration.GetClientDetailsAndConfig()["Client ID"], Configuration.GetClientDetailsAndConfig()["Secret"], Configuration.GetConfig()).GetAccessToken();

                // ### Api Context
                // Pass in a `ApiContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                APIContext context = new APIContext(accessToken);
                context.Config = Configuration.GetClientDetailsAndConfig();
                
                // ### Sale
                // Pass an AccessToken and the ID of the sale
                // transaction from your payment resource.
                Sale selling = Sale.Get(context, "4V7971043K262623A");
                CurrContext.Items.Add("ResponseJson", JObject.Parse(selling.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            Server.Transfer("~/Response.aspx");
        }
    }
}
