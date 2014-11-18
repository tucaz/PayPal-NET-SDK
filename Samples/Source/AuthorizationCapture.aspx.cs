// #AuthorizationCapture Sample
// The sample code demonstrates
// how to capture a previously
// authorized payment. 
// API used: POST /v1/payments/authorization/{authorization_id}/capture
using System;
using System.Web;
using PayPal.Api;
using PayPal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using PayPal.Sample.Utilities;

namespace PayPal.Sample
{
    public partial class AuthorizationCapture : BaseSamplePage
    {
        protected override void RunSample()
        {
                // Retrieve a payment Authorization objectby making a Payment with intent as `authorize`.
                var authorization = Common.CreateAuthorization(this.flow, this.apiContext);

                // Specify an amount to capture.  By setting 'is_final_capture' to true, all remaining funds held by the authorization will be released from the funding instrument.
                var capture = new Capture()
                {
                    amount = new Amount()
                    {
                        currency = "USD",
                        total = "4.54"
                    },
                    is_final_capture = true
                };
                
                // Capture an authorized payment by POSTing to
                // URI v1/payments/authorization/{authorization_id}/capture
                this.flow.AddNewRequest("Capture authorized payment", capture, string.Format("URI: v1/payments/authorization/{0}/capture", authorization.id));
                var responseCapture = authorization.Capture(this.apiContext, capture);
                this.flow.RecordResponse(responseCapture);
        }
    }
}
