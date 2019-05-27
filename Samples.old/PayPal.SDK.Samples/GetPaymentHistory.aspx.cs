// #GetPaymentList Sample
// This sample code demonstrate how you can
// retrieve a list of all Payment resources
// you've created using the Payments API.
// Note: Various query parameters that you can
// use to filter, and paginate through the
// payments list.
// API used: GET /v1/payments/payments
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class GetPaymentHistory : BaseSamplePage
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

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Retrieve payment history");
            #endregion

            // ###Retrieve
            // Retrieve the PaymentHistory by calling the
            // static `List` method
            // on the Payment resource, and pass the
            // APIContext and the map containing the query parameters 
            // for paginations and filtering.
            // Refer the API documentation
            // for valid values for keys
            var paymentList = Payment.List(apiContext, count: 10, startIndex: 5);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(paymentList);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
