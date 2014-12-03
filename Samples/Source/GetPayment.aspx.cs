// #GetPayment Sample
// This sample code demonstrates how you can retrieve
// the details of a payment resource.
// API used: /v1/payments/payment/{payment-i
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class GetPayment : BaseSamplePage
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

            // Specify a Payment ID to retrieve.  For demonstration purposes, we'll be using a previously-executed payment that used a PayPal account.
            var paymentId = "PAY-77612305PF568741CKR4LELY";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Get payment details", description: "ID: " + paymentId);
            #endregion
            
            // Retrieve the details of the payment.
            var payment = Payment.Get(apiContext, paymentId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(payment);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
