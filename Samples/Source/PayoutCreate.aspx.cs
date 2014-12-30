using System;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class PayoutCreate : BaseSamplePage
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

            var payout = new Payout
            {
                sender_batch_header = new PayoutSenderBatchHeader
                {
                    sender_batch_id = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8),
                    email_subject = "You have a payment"
                },
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
                    },
                    new PayoutItem
                    {
                        recipient_type = PayoutRecipientType.EMAIL,
                        amount = new Currency
                        {
                            value = "0.90",
                            currency = "USD"
                        },
                        receiver = "shirt-supplier-two@mail.com",
                        note = "Thank you.",
                        sender_item_id = "item_2"
                    },
                    new PayoutItem
                    {
                        recipient_type = PayoutRecipientType.EMAIL,
                        amount = new Currency
                        {
                            value = "2.00",
                            currency = "USD"
                        },
                        receiver = "shirt-supplier-three@mail.com",
                        note = "Thank you.",
                        sender_item_id = "item_3"
                    }
                }
            };

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Create payout", payout);
            //--------------------
            #endregion

            var createdPayout = payout.Create(apiContext, false);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(createdPayout);
            //--------------------
            #endregion
        }
    }
}