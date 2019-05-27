// # Get Batch Payout Details
// This sample code demonstrates how you can retrieve the details of a batch payout.
// More Information: https://developer.paypal.com/docs/integration/direct/payouts-overview/
using System;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class PayoutGet : BaseSamplePage
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

            // ### Batch Payout ID
            // The ID of the batch payout to lookup.
            var payoutBatchId = "6L3FZTTJE2NR8";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Retrieve payout details", description: "ID: " + payoutBatchId);
            #endregion

            // ### Payout.Get()
            // Retrieves the details of the specified batch payout.
            var payout = Payout.Get(apiContext, payoutBatchId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(payout);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}