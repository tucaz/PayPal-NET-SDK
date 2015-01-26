// # Cacnel Payout Item
// This sample code demonstrates how you can cancel a payout item.
// More Information: https://developer.paypal.com/docs/integration/direct/payouts-overview/
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class PayoutItemCancel : BaseSamplePage
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

            // ### Initialize `Payout` Object
            // Initialize a new `Payout` object with details of the batch payout to be created.
            var payout = new Payout
            {
                // #### sender_batch_header
                // Describes how the payments defined in the `items` array are to be handled.
                sender_batch_header = new PayoutSenderBatchHeader
                {
                    sender_batch_id = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8),
                    email_subject = "You have a payment"
                },
                // #### items
                // The `items` array contains the list of payout items to be included in this payout.
                // If `syncMode` is set to `true` when calling `Payout.Create()`, then the `items` array must only
                // contain **one** item.  If `syncMode` is set to `false` when calling `Payout.Create()`, then the `items`
                // array can contain more than one item.
                items = new List<PayoutItem>
                {
                    new PayoutItem
                    {
                        recipient_type = PayoutRecipientType.EMAIL,
                        amount = new Currency
                        {
                            value = "0.99",
                            currency = "USD"
                        },
                        receiver = "shirt-supplier-one@mail.com",
                        note = "Thank you.",
                        sender_item_id = "item_1"
                    }
                }
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Create single, synchronous payout", payout);
            #endregion

            // ### Payout.Create()
            // Creates the batch payout resource.
            // `syncMode = false` indicates that this call will be performed **asynchronously**,
            // and will return a `payout_batch_id` that can be used to check the status of the payouts in the batch.
            // `syncMode = true` indicates that this call will be performed **synchronously** and will return once the payout has been processed.
            // > **NOTE**: The `items` array can only have **one** item if `syncMode` is set to `true`.
            var createdPayout = payout.Create(apiContext, true);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdPayout);
            #endregion

            var payoutItem = createdPayout.items[0];

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Cancel the payout item", description: "ID: " + payoutItem.payout_item_id);
            #endregion

            // ### Payout.Cancel()
            // Call Payout.Cancel() to cancel the payout item.
            var cancelledPayoutItem = PayoutItem.Cancel(apiContext, payoutItem.payout_item_id);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(cancelledPayoutItem);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}