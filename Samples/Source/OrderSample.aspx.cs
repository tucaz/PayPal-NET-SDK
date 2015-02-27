// Order Sample
// This sample code demonstrates how to create a new payment order.
// API used: POST /v1/payments/payment
using System;
using PayPal.Api;
using PayPal.Sample.Utilities;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class OrderSample : BaseSamplePage
    {
        private Order order;
        private Amount amount;

        protected override void RunSample()
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                // ###Payer
                // A resource representing a Payer that funds a payment
                // Payment Method
                // as `paypal`
                var payer = new Payer() { payment_method = "paypal" };

                // # Redirect URLS
                string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/OrderSample.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = redirectUrl + "&cancel=true",
                    return_url = redirectUrl
                };

                // ###Amount
                // Lets you specify a payment amount.
                var amount = new Amount()
                {
                    currency = "USD",
                    total = "5.00"
                };

                // ###Transaction
                // A transaction defines the contract of a
                // payment - what is the payment for and who
                // is fulfilling it. 
                var transactionList = new List<Transaction>();

                // The Payment creation API requires a list of
                // Transaction; add the created `Transaction`
                // to a List
                transactionList.Add(new Transaction()
                {
                    description = "Transaction description.",
                    amount = amount
                });

                // ###Payment
                // Create a payment with the intent set to 'order'
                var payment = new Payment()
                {
                    intent = "order",
                    payer = payer,
                    transactions = transactionList,
                    redirect_urls = redirUrls
                };

                // ^ Ignore workflow code segment
                #region Track Workflow
                flow.AddNewRequest("Create payment order", payment);
                #endregion

                // Create the payment resource.
                var createdPayment = payment.Create(apiContext);

                // ^ Ignore workflow code segment
                #region Track Workflow
                flow.RecordResponse(createdPayment);
                #endregion

                // Use the `approval_url` link provided by the returned object to approve the order payment.
                var links = createdPayment.links.GetEnumerator();
                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        this.flow.RecordRedirectUrl("Redirect to PayPal to approve the order...", link.href);
                    }
                }
                Session.Add("flow-" + guid, this.flow);
                Session.Add(guid, createdPayment.id);
            }
            else
            {
                var guid = Request.Params["guid"];
                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow = Session["flow-" + guid] as RequestFlow;
                this.RegisterSampleRequestFlow();
                this.flow.RecordApproval("Order payment approved successfully.");
                #endregion

                // Execute the order
                var paymentId = Session[guid] as string;
                var paymentExecution = new PaymentExecution() { payer_id = payerId };
                var payment = new Payment() { id = paymentId };

                // ^ Ignore workflow code segment
                #region Track Workflow
                flow.AddNewRequest("Execute payment", payment);
                #endregion

                // Execute the order payment.
                var executedPayment = payment.Execute(apiContext, paymentExecution);

                // ^ Ignore workflow code segment
                #region Track Workflow
                flow.RecordResponse(executedPayment);
                #endregion

                // Get the information about the executed order from the returned payment object.
                this.order = executedPayment.transactions[0].related_resources[0].order;
                this.amount = executedPayment.transactions[0].amount;

                // Once the order has been executed, an order ID is returned that can be used
                // to do one of the following:
                // this.AuthorizeOrder();
                // this.CaptureOrder();
                // this.VoidOrder();
                // this.RefundOrder();

                // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
            }
        }

        /// <summary>
        /// Authorizes an order. This begins the process of confirming that
        /// funds are available until it is time to complete the payment
        /// transaction.
        /// 
        /// More Information:
        /// https://developer.paypal.com/webapps/developer/docs/integration/direct/create-process-order/#authorize-an-order
        /// </summary>
        private void AuthorizeOrder(APIContext apiContext)
        {
            this.order.Authorize(apiContext);
        }

        /// <summary>
        /// Captures an order. For a partial capture, you can provide a lower
        /// amount than the total payment. Additionally, you can explicitly
        /// indicate a final capture (complete the transaction and prevent
        /// future captures) by setting the is_final_capture value to true.
        /// 
        /// More Information:
        /// https://developer.paypal.com/webapps/developer/docs/integration/direct/create-process-order/#capture-an-order
        /// </summary>
        private void CaptureOrder(APIContext apiContext)
        {
            var capture = new Capture();
            capture.amount = this.amount;
            capture.is_final_capture = true;
            this.order.Capture(apiContext, capture);
        }

        /// <summary>
        /// Voids an order.
        /// 
        /// NOTE: An order cannot be voided if payment has already been
        ///       partially or fully captured.
        /// 
        /// More Information:
        /// https://developer.paypal.com/webapps/developer/docs/api/#void-an-order
        /// </summary>
        private void VoidOrder(APIContext apiContext)
        {
            this.order.Void(apiContext);
        }
    }
}
