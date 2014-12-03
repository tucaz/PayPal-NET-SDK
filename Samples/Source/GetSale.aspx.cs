// # Get Details of a Sale Transaction Sample
// This sample code demonstrates how you can retrieve 
// details of completed Sale Transaction.
// API used: /v1/payments/sale/{sale-id}
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class GetSale : BaseSamplePage
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

            var saleId = "4V7971043K262623A";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Get sale", description: "ID: " + saleId);
            #endregion

            var sale = Sale.Get(apiContext, saleId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(sale);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
