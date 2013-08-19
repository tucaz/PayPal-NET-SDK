using System;
using System.Web;
using PayPal;
using PayPal.Api.Payments;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// ##Reauthorization Sample
// Sample showing how to do a reauthorization
namespace RestApiSample
{
    public partial class Reauthorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;
            Authorization authorization = null;
            try
            {
                // ###AccessToken dcv
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

                // ###Reauthorization
                // Retrieve a authorization id from authorization object
                // by making a `Payment Using PayPal` with intent
                // as `authorize`. You can reauthorize a payment only once 4 to 29
                // days after 3-day honor period for the original authorization
                // expires.
                authorization = Authorization.Get(context, "8HD57954KS1107638");
                Amount reauthorizeAmount = new Amount();
                reauthorizeAmount.currency = "USD";
                reauthorizeAmount.total = "1";
                authorization.amount = reauthorizeAmount;
                Authorization reauthorization = authorization.Reauthorize(context);
                CurrContext.Items.Add("ResponseJson", JObject.Parse(reauthorization.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            CurrContext.Items.Add("RequestJson", JObject.Parse(authorization.ConvertToJson()).ToString(Formatting.Indented));
            Server.Transfer("~/Response.aspx");
        }
    }
}
