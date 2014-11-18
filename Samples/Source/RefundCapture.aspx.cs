// #RefundCapture Sample
// This sample code demonstrates how to do a 
// Refund on a Capture resource
// API used: POST /v1/payments/capture/{capture_id}/refund
using System;
using System.Web;
using PayPal.Api;
using PayPal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class RefundCapture : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ###Authorization
            // Retrieve a Authorization object
            // by making a Payment with intent
            // as 'authorize'
            var authorization = Common.CreateAuthorization(this.flow, this.apiContext);

            /// ###Capture
            // Create a Capture object
            // by doing a capture on
            // Authorization object
            var capture = Common.GetCapture(this.flow, this.apiContext, authorization);

            /// ###Refund
            /// Create a Refund object
            var refund = new Refund()
            {
                amount = new Amount()
                {
                    currency = "USD",
                    total = "0.50"
                }
            };

            // Do a Refund by
            // POSTing to 
            // URI v1/payments/capture/{capture_id}/refund
            this.flow.AddNewRequest("Capture refund", refund, "ID: " + capture.id);
            this.flow.RecordResponse(capture.Refund(Configuration.GetAPIContext(), refund));
        }
    }
}
