// #GetCreditCard Sample
// This sample code demonstrates how you 
// retrieve a previously saved 
// Credit Card using the 'vault' API.
// API used: GET /v1/vault/credit-card/{id}
using System;
using System.Web;
using PayPal;
using PayPal.Api.Payments;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RestApiSample
{
    public partial class GetCreditCard : System.Web.UI.Page
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

                // Retrieve the CreditCard object by calling the
                // static 'Get' method on the CreditCard class
                // by passing a valid AccessToken and CreditCard ID
                CreditCard card = CreditCard.Get(context, "CARD-5MY32504F4899612AKIHAQHY");
                CurrContext.Items.Add("ResponseJson", JObject.Parse(card.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
