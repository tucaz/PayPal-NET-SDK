// #GetCapture Sample
// This sample code demonstrates how to 
// retrieve a Capture resource
// API used: GET /v1/payments/capture/{capture_id}
using System;
using System.Web;
using PayPal.Api;
using PayPal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class GetCapture : BaseSamplePage
    {
        protected override void RunSample()
        {
            // Retrieve a Authorization object by making a Payment with intent as `authorize`
            var authorization = Common.CreateAuthorization(this.flow, this.apiContext);

            // Create a Capture object by doing a capture on Authorization object and retrieve the Id
            var capture = Common.GetCapture(this.flow, this.apiContext, authorization);

            // Retrieve the Capture object by
            // doing a GET call to 
            // URI v1/payments/capture/{capture_id}
            this.flow.AddNewRequest("Retrieve capture details", description: "ID: " + capture.id);
            this.flow.RecordResponse(Capture.Get(this.apiContext, capture.id));
        }
    }
}
