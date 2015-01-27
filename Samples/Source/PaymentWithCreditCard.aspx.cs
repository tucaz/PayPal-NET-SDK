// #CreatePayment using credit card Sample
// This sample code demonstrate how you can process
// a payment with a credit card.
// API used: /v1/payments/payment
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class PaymentWithCreditCard : BaseSamplePage
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

            // A transaction defines the contract of a payment - what is the payment for and who is fulfilling it. 
            var transaction = new Transaction()
            {
                amount = new Amount()
                {
                    currency = "USD",
                    total = "7",
                    details = new Details()
                    {
                        shipping = "1",
                        subtotal = "5",
                        tax = "1"
                    }
                },
                description = "This is the payment transaction description.",
                item_list = new ItemList()
                {
                    items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "1",
                            quantity = "5",
                            sku = "sku"
                        }
                    },
                    shipping_address = new ShippingAddress
                    {
                        city = "Johnstown",
                        country_code = "US",
                        line1 = "52 N Main ST",
                        postal_code = "43210",
                        state = "OH",
                        recipient_name = "Joe Buyer"
                    }
                },
                invoice_number = Common.GetRandomInvoiceNumber()
            };

            // A resource representing a Payer that funds a payment.
            var payer = new Payer()
            {
                payment_method = "credit_card",
                funding_instruments = new List<FundingInstrument>()
                {
                    new FundingInstrument()
                    {
                        credit_card = new CreditCard()
                        {
                            billing_address = new Address()
                            {
                                city = "Johnstown",
                                country_code = "US",
                                line1 = "52 N Main ST",
                                postal_code = "43210",
                                state = "OH"
                            },
                            cvv2 = "874",
                            expire_month = 11,
                            expire_year = 2018,
                            first_name = "Joe",
                            last_name = "Shopper",
                            number = "4877274905927862",
                            type = "visa"
                        }
                    }
                },
                payer_info = new PayerInfo
                {
                    email = "test@email.com"
                }
            };

            // A Payment resource; create one using the above types and intent as `sale` or `authorize`
            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = new List<Transaction>() { transaction }
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Create credit card payment", payment);
            #endregion

            // Create a payment using a valid APIContext
            var createdPayment = payment.Create(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdPayment);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
