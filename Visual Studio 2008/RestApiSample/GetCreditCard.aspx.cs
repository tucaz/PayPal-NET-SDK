// #GetCreditCard Sample
// This sample code demonstrates how you 
// retrieve a previously saved 
// Credit Card using the 'vault' API.
// API used: GET /v1/vault/credit-card/{id}
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
                string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperties()["ClientID"], ConfigManager.Instance.GetProperties()["ClientSecret"]).GetAccessToken();

                // Retrieve the CreditCard object by calling the
                // static 'Get' method on the CreditCard class
                // by passing a valid AccessToken and CreditCard ID
                CreditCard credtCard = CreditCard.Get(accessToken, "CARD-5BT058015C739554AKE2GCEI");
                CurrContext.Items.Add("ResponseJson", JObject.Parse(credtCard.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
