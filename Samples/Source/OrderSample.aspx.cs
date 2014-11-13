// Order Sample
// This sample code demonstrates how to create a new payment order.
// API used: POST /v1/payments/payment
using System;
using System.Web;
using PayPal.Api;
using PayPal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class OrderSample : System.Web.UI.Page
    {
        private APIContext apiContext;
        private Order order;
        private Amount amount;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;

            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext..
            this.apiContext = Configuration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    // Creating a payment
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/OrderSample.aspx?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = Common.CreatePaymentOrder(HttpContext.Current, apiContext, baseURI + "guid=" + guid);

                    CurrContext.Items.Add("ResponseJson", Common.FormatJsonString(createdPayment.ConvertToJson()));

                    var links = createdPayment.links.GetEnumerator();

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            CurrContext.Items.Add("RedirectURL", lnk.href);
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                }
                else
                {
                    // Execute the order
                    var executedPayment = Common.ExecutePayment(apiContext, payerId, Request.Params["guid"]);
                    CurrContext.Items.Add("ResponseJson", Common.FormatJsonString(executedPayment.ConvertToJson()));

                    this.order = executedPayment.transactions[0].related_resources[0].order;
                    this.amount = executedPayment.transactions[0].amount;

                    // Once the order has been executed, an order ID is returned that can be used
                    // to do one of the following:
                    // this.AuthorizeOrder();
                    // this.CaptureOrder();
                    // this.VoidOrder();
                    // this.RefundOrder();
                }
            }
            catch (Exception ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }

        /// <summary>
        /// Authorizes an order. This begins the process of confirming that
        /// funds are available until it is time to complete the payment
        /// transaction.
        /// 
        /// More Information:
        /// https://developer.paypal.com/webapps/developer/docs/integration/direct/create-process-order/#authorize-an-order
        /// </summary>
        private void AuthorizeOrder()
        {
            this.order.Authorize(this.apiContext);
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
        private void CaptureOrder()
        {
            var capture = new Capture();
            capture.amount = this.amount;
            capture.is_final_capture = true;
            this.order.Capture(this.apiContext, capture);
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
        private void VoidOrder()
        {
            this.order.Void(this.apiContext);
        }
    }
}
