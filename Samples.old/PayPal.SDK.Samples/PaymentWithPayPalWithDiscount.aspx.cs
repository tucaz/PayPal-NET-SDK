using PayPal.Api;
using PayPal.Sample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayPal.Sample
{
    public partial class PaymentWithPayPalWithDiscount : BaseSamplePage
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

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPayPalWithDiscount.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;

                // ###Payment
                // A Payment Resource; create one using
                // the above types and intent as `sale` or `authorize`
                var payment = new Payment
                {
                    intent = "sale",
                    // ###Payer
                    // A resource representing a Payer that funds a payment
                    // Payment Method as `paypal`
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                    {
                        // ###Transaction
                        // A transaction defines the contract of a
                        // payment - what is the payment for and who
                        // is fulfilling it. 
                        new Transaction
                        {
                            description = "Transaction description.",
                            invoice_number = Common.GetRandomInvoiceNumber(),
                            // ###Amount
                            // Let's you specify a payment amount.
                            amount = new Amount
                            {
                                currency = "USD",
                                // Total must be equal to sum of shipping, tax and subtotal.
                                total = "92.50",
                                // ###Details
                                // Let's you specify details of a payment amount.
                                details = new Details
                                {
                                    tax = "15",
                                    shipping = "10",
                                    subtotal = "67.50"
                                }
                            },
                            // ###Items
                            // Items within a transaction.
                            item_list = new ItemList
                            {
                                items = new List<Item>
                                {
                                    new Item
                                    {
                                        name = "Item Name",
                                        currency = "USD",
                                        price = "15.00",
                                        quantity = "5",
                                        sku = "sku"
                                    },
                                    new Item
                                    {
                                        name = "Special 10% Discount",
                                        currency = "USD",
                                        price = "-7.50",
                                        quantity = "1",
                                        sku = "sku_discount"
                                    }
                                }
                            }
                        }
                    },
                    // ###Redirect URLS
                    // These URLs will determine how the user is redirected from PayPal once they have either approved or canceled the payment.
                    redirect_urls = new RedirectUrls
                    {
                        cancel_url = redirectUrl + "&cancel=true",
                        return_url = redirectUrl
                    }
                };

                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.AddNewRequest("Create PayPal payment", payment);
                #endregion

                // Create a payment using a valid APIContext
                var createdPayment = payment.Create(apiContext);

                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.RecordResponse(createdPayment);
                #endregion

                // Using the `links` provided by the `createdPayment` object, we can give the user the option to redirect to PayPal to approve the payment.
                var links = createdPayment.links.GetEnumerator();
                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        this.flow.RecordRedirectUrl("Redirect to PayPal to approve the payment...", link.href);
                    }
                }
                Session.Add(guid, createdPayment.id);
                Session.Add("flow-" + guid, this.flow);
            }
            else
            {
                var guid = Request.Params["guid"];

                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow = Session["flow-" + guid] as RequestFlow;
                this.RegisterSampleRequestFlow();
                this.flow.RecordApproval("PayPal payment approved successfully.");
                #endregion

                // Using the information from the redirect, setup the payment to execute.
                var paymentId = Session[guid] as string;
                var paymentExecution = new PaymentExecution { payer_id = payerId };
                var payment = new Payment { id = paymentId };

                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.AddNewRequest("Execute PayPal payment", payment);
                #endregion

                // Execute the payment.
                var executedPayment = payment.Execute(apiContext, paymentExecution);
                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.RecordResponse(executedPayment);
                #endregion

                // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
            }
        }
    }
}