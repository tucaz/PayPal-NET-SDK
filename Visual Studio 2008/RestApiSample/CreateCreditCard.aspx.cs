// #CreateCreditCard Sample
// Using the 'vault' API, you can store a 
// Credit Card securely on PayPal. You can
// use a saved Credit Card to process
// a payment in the future.
// The following code demonstrates how 
// can save a Credit Card on PayPal using 
// the Vault API.
// API used: POST /v1/vault/credit-card
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
    public partial class CreateCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;

            // ###CreditCard
            // A resource representing a credit card that can be
            // used to fund a payment.
            CreditCard credtCard = new CreditCard();
            credtCard.expire_month = "11";
            credtCard.expire_year = "2018";
            credtCard.number = "4417119669820331";
            credtCard.type = "visa";

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

                // ### Api Context
                // Pass in a `ApiContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                APIContext apiContext = new APIContext(accessToken);
                // Use this variant if you want to pass in a request id  
                // that is meaningful in your application, ideally 
                // a order id.
                // String requestId = Long.toString(System.nanoTime();
                // APIContext apiContext = new APIContext(accessToken, requestId ));

                // ###Save
                // Creates the credit card as a resource
                // in the PayPal vault. The response contains
                // an 'id' that you can use to refer to it
                // in the future payments.
                CreditCard createdCreditCard = credtCard.Create(apiContext);
                CurrContext.Items.Add("ResponseJson", JObject.Parse(createdCreditCard.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            CurrContext.Items.Add("RequestJson", JObject.Parse(credtCard.ConvertToJson()).ToString(Formatting.Indented));

            Server.Transfer("~/Response.aspx");
        }
    }
}
