// #SaleRefund Sample
// This sample code demonstrate how you can 
// process a refund on a sale transaction created 
// using the Payments API.
// API used: /v1/payments/sale/{sale-id}/refund
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class SaleRefund : BaseSamplePage
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

            // A refund transaction. Use the amount to create a refund object
            var refund = new Refund()
            {
                amount = new Amount()
                {
                    currency = "USD",
                    total = "0.01"
                }
            };

            // Create a Sale object with the given sale transaction id.
            var sale = new Sale()
            {
                id = "1L304068UD1406339"
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Refund sale", refund, string.Format("URI: /v1/payments/sale/{0}/refund", sale.id));
            #endregion
            
            // Refund by posting Refund object using a valid APIContext
            var response = sale.Refund(apiContext, refund);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(response);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
