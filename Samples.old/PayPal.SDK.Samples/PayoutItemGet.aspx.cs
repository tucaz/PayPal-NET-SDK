// # Get Batch Payout Item Details
// This sample code demonstrates how you can retrieve the details of a specific batch payout item.
// More Information: https://developer.paypal.com/docs/integration/direct/payouts-overview/
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

            // ### Batch Payout Item ID
            // The ID of the batch payout item to lookup.
            var payoutItemId = "Q7DWNN5Y733CQ";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Retrieve payout item details", description: "ID: " + payoutItemId);
            #endregion

            // ### PayoutItemDetails.Get()
            // Retrieves the details of the specified batch payout item.
            var payoutItemDetails = PayoutItem.Get(apiContext, payoutItemId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(payoutItemDetails);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}