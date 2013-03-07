// #SaleRefund Sample
// This sample code demonstrate how you can 
// process a refund on a sale transaction created 
// using the Payments API.
// API used: /v1/payments/sale/{sale-id}/refund
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
    public partial class SaleRefund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;

            // ###Amount
            // Create an Amount object to
            // represent the amount to be
            // refunded. Create the refund object, if the refund is partial
            Amount amount = new Amount();
            amount.currency = "USD";
            amount.total = "0.01";

            // ###Refund
            // A refund transaction.
            // Use the amount to create
            // a refund object
            Refund refund = new Refund();
            refund.amount = amount;
            // ###Sale
            // A sale transaction.
            // Create a Sale object with the
            // given sale transaction id.
            Sale sale = new Sale();
            sale.id = "4V7971043K262623A";
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

                // Refund by posting to the APIService
                // using a valid AccessToken
                Refund refundedSale = sale.Refund(apiContext, refund);
                CurrContext.Items.Add("ResponseJson",JObject.Parse(refundedSale.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            CurrContext.Items.Add("RequestJson",
                  JObject.Parse(sale.ConvertToJson()).ToString(Formatting.Indented));
            Server.Transfer("~/Response.aspx");
        }
    }
}
