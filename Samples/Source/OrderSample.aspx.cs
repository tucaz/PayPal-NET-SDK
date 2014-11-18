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
    public partial class OrderSample : BaseSamplePage
    {
        private Order order;
        private Amount amount;

        protected override void RunSample()
        {
            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                // Creating a payment
                string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/OrderSample.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var createdPayment = Common.CreatePaymentOrder(this.flow, this.apiContext, baseURI + "guid=" + guid);

                var links = createdPayment.links.GetEnumerator();

                while (links.MoveNext())
                {
                    Links lnk = links.Current;
                    if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        HttpContext.Current.Items.Add("RedirectURL", lnk.href);
                    }
                }
                Session.Add(guid, createdPayment.id);
            }
            else
            {
                // Execute the order
                var executedPayment = Common.ExecutePayment(this.flow, this.apiContext, payerId, Request.Params["guid"]);

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
