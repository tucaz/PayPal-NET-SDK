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

            var payoutBatchId = "6L3FZTTJE2NR8";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Retrieve payout details", description: "ID: " + payoutBatchId);
            //--------------------
            #endregion

            var payout = Payout.Get(apiContext, payoutBatchId);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(payout);
            //--------------------
            #endregion
        }
    }
}