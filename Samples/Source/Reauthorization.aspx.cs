using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// ##Reauthorization Sample
// Sample showing how to do a reauthorization
namespace PayPal.Sample
{
    public partial class Reauthorization : BaseSamplePage
    {
        protected override void RunSample()
        {
            // Make a authorized payment using `PayPal Account Payments` with intent
            // as `authorize`. You can reauthorize a payment only once 4 to 29
            // days after 3-day honor period for the original authorization
            // expires.
            var authorizationId = "8HD57954KS1107638";
            this.flow.AddNewRequest("Retrieve payment authorization information", description: "ID: " + authorizationId);
            var authorization = Authorization.Get(this.apiContext, authorizationId);
            this.flow.RecordResponse(authorization);

            authorization.amount = new Amount()
            {
                currency = "USD",
                total = "1"
            };
            this.flow.AddNewRequest("Reauthorize payment");
            this.flow.RecordResponse(authorization.Reauthorize(this.apiContext));
        }
    }
}
