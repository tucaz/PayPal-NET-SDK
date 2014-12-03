// #CreatePayment Using Saved Card Sample
// This sample code demonstrates how you can process a 
// Payment using a previously saved credit card.
// API used: /v1/payments/payment
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class PaymentWithSavedCard : BaseSamplePage
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

            // Items within a transaction.
            var item = new Item()
            {
                name = "Item Name",
                currency = "USD",
                price = "1",
                quantity = "5",
                sku = "sku"
            };

            // A resource representing a credit card that can be used to fund a payment.
            var credCardToken = new CreditCardToken()
            {
                credit_card_id = "CARD-0F049886A57009534KRVL4LQ"
            };

            var amnt = new Amount()
            {
                currency = "USD",
                total = "7",
                details = new Details()
                {
                    shipping = "1",
                    subtotal = "5",
                    tax = "1"
                }
            };

            // A transaction defines the contract of a
            // payment - what is the payment for and who
            // is fulfilling it. 
            var tran = new Transaction()
            {
                amount = amnt,
                description = "This is the payment transaction description.",
                item_list = new ItemList() { items = new List<Item>() { item } }
            };

            // A resource representing a Payer's funding instrument. For stored credit card payments, set the CreditCardToken field on this object.
            var fundInstrument = new FundingInstrument()
            {
                credit_card_token = credCardToken
            };

            // A Payment Resource; create one using the above types and intent as 'sale'
            var pymnt = new Payment()
            {
                intent = "sale",
                payer = new Payer()
                {
                    funding_instruments = new List<FundingInstrument>() { fundInstrument },
                    payment_method = "credit_card"
                },
                transactions = new List<Transaction>() { tran }
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Create credit card payment", pymnt);
            #endregion

            // Create a payment using a valid APIContext
            var createdPayment = pymnt.Create(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdPayment);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
