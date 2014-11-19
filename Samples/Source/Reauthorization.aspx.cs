// ##Reauthorization Sample
// Sample showing how to do a reauthorization
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class Reauthorization : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

            // Make a authorized payment using `PayPal Account Payments` with intent
            // as `authorize`. You can reauthorize a payment only once 4 to 29
            // days after 3-day honor period for the original authorization
            // expires.
            var authorizationId = "8HD57954KS1107638";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Retrieve payment authorization information", description: "ID: " + authorizationId);
            #endregion
            
            var authorization = Authorization.Get(apiContext, authorizationId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(authorization);
            #endregion

            authorization.amount = new Amount()
            {
                currency = "USD",
                total = "1"
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Reauthorize payment");
            #endregion
            
            var response = authorization.Reauthorize(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(response);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
