// #AuthorizationCapture Sample
// The sample code demonstrates
// how to capture a previously
// authorized payment. 
// API used: POST /v1/payments/authorization/{authorization_id}/capture
using PayPal.Api;
using PayPal.Sample.Utilities;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class AuthorizationCapture : BaseSamplePage
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

            // ###Payment
            // A Payment Resource; create one with its intent set to `sale`, `authorize`, or `order`
            var payment = new Payment()
            {
                intent = "authorize",
                // A resource representing a Payer that funds a payment. Use the List of `FundingInstrument` and the Payment Method as 'credit_card'
                payer = new Payer()
                {
                    // The Payment creation API requires a list of
                    // FundingInstrument; add the created `FundingInstrument`
                    // to a List
                    funding_instruments = new List<FundingInstrument>() 
                    {
                        // A resource representing a Payeer's funding instrument.
                        // Use a Payer ID (A unique identifier of the payer generated
                        // and provided by the facilitator. This is required when
                        // creating or using a tokenized funding instrument)
                        // and the `CreditCardDetails`
                        new FundingInstrument()
                        {
                            // A resource representing a credit card that can be used to fund a payment.
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
                    payment_method = "credit_card"
                },
                // The Payment creation API requires a list of transactions; add the created `Transaction` to a List
                transactions = new List<Transaction>()
                {
                    // A transaction defines the contract of a payment - what is the payment for and who is fulfilling it. Transaction is created with a `Payee` and `Amount` types
                    new Transaction()
                    {
                        // Let's you specify a payment amount.
                        amount = new Amount()
                        {
                            currency = "USD",
                            // Total must be equal to sum of shipping, tax and subtotal.
                            total = "107.47",
                            details = new Details()
                            {
                                shipping = "0.03",
                                subtotal = "107.41",
                                tax = "0.03"
                            }
                        },
                        description = "This is the payment transaction description."
                    }
                }
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest(title: "Create authorization for credit card payment", requestObject: payment);
            #endregion

            // Create a payment by posting to the APIService
            // using a valid APIContext
            var createdPayment = payment.Create(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdPayment);
            #endregion

            // ###Authorization
            // Once the payment with intent set to `authorize` has been created, retrieve its authorization object.
            var authorization = createdPayment.transactions[0].related_resources[0].authorization;

            // Specify an amount to capture.  By setting 'is_final_capture' to true, all remaining funds held by the authorization will be released from the funding instrument.
            var capture = new Capture()
            {
                amount = new Amount()
                {
                    currency = "USD",
                    total = "4.54"
                },
                is_final_capture = true
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Capture authorized payment", capture, string.Format("URI: v1/payments/authorization/{0}/capture", authorization.id));
            #endregion

            // Capture an authorized payment by POSTing to
            // URI v1/payments/authorization/{authorization_id}/capture
            var responseCapture = authorization.Capture(apiContext, capture);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(responseCapture);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
