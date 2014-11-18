// #GetPaymentList Sample
// This sample code demonstrate how you can
// retrieve a list of all Payment resources
// you've created using the Payments API.
// Note: Various query parameters that you can
// use to filter, and paginate through the
// payments list.
// API used: GET /v1/payments/payments
using System;
using System.Web;
using System.Collections.Generic;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PayPal.Util;

namespace PayPal.Sample
{
    public partial class GetPaymentHistory : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ###Retrieve
            // Retrieve the PaymentHistory by calling the
            // static `List` method
            // on the Payment resource, and pass the
            // APIContext and the map containing the query parameters 
            // for paginations and filtering.
            // Refer the API documentation
            // for valid values for keys
            this.flow.AddNewRequest("Retrieve payment history");
            this.flow.RecordResponse(Payment.List(this.apiContext, count: 10, startIndex: 5));
        }
    }
}
