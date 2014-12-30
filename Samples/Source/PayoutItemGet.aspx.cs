using System;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class PayoutItemGet : BaseSamplePage
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

            var payoutItemId = "Q7DWNN5Y733CQ";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Retrieve payout item details", description: "ID: " + payoutItemId);
            //--------------------
            #endregion

            var payoutItemDetails = PayoutItemDetails.Get(apiContext, payoutItemId);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(payoutItemDetails);
            //--------------------
            #endregion
        }
    }
}