// #Create Payment Using PayPal Sample
// This sample code demonstrates how you can process a 
// PayPal Account based Payment.
// API used: /v1/payments/payment
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class PaymentWithPayPal : BaseSamplePage
    {
        private Payment payment;
        private FuturePayment futurePayment;

        protected override void RunSample()
        {
            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                // Creating a payment
                string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPayPal.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var createdPayment = this.CreatePayment(this.apiContext, baseURI + "guid=" + guid);

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
                // Executing a payment
                var guid = Request.Params["guid"];
                var executedPayment = this.ExecutePayment(this.apiContext, payerId, Session[guid] as string);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="payerId"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };

            this.flow.AddNewRequest("Execute PayPal payment", this.payment);
            var executedPayment = this.payment.Execute(this.apiContext, paymentExecution);
            this.flow.RecordResponse(executedPayment);
            return executedPayment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            // ###Items
            // Items within a transaction.
            var itemList = new ItemList() { items = new List<Item>() };
            itemList.items.Add(new Item()
            {
                name = "Item Name",
                currency = "USD",
                price = "15",
                quantity = "5",
                sku = "sku"
            });

            // ###Payer
            // A resource representing a Payer that funds a payment
            // Payment Method
            // as `paypal`
            var payer = new Payer() { payment_method = "paypal" };
            
            // # Redirect URLS
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            // ###Details
            // Let's you specify details of a payment amount.
            var details = new Details()
            {
                tax = "15",
                shipping = "10",
                subtotal = "75"
            };

            // ###Amount
            // Let's you specify a payment amount.
            var amount = new Amount()
            {
                currency = "USD",
                total = "100", // Total must be equal to sum of shipping, tax and subtotal.
                details = details
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
                invoice_number = Common.GetRandomInvoiceNumber(),
                amount = amount,
                item_list = itemList
            });

            // ###Payment
            // A Payment Resource; create one using
            // the above types and intent as `sale` or `authorize`
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a valid APIContext
            this.flow.AddNewRequest("Create PayPal payment", payment);
            var createdPayment = this.payment.Create(this.apiContext);
            this.flow.RecordResponse(createdPayment);
            return createdPayment;
        }

        /// <summary>
        /// Code example for creating a future payment object.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="authorizationCode"></param>
        private Payment CreateFuturePayment(string correlationId, string authorizationCode, string redirectUrl)
        {
            // ###Payer
            // A resource representing a Payer that funds a payment
            // Payment Method
            // as `paypal`
            Payer payer = new Payer()
            {
                payment_method = "paypal"
            };

            // ###Details
            // Let's you specify details of a payment amount.
            Details details = new Details()
            {
                tax = "15",
                shipping = "10",
                subtotal = "75"
            };

            // ###Amount
            // Let's you specify a payment amount.
            var amount = new Amount()
            {
                currency = "USD",
                total = "100", // Total must be equal to sum of shipping, tax and subtotal.
                details = details
            };

            // # Redirect URLS
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            // ###Items
            // Items within a transaction.
            var itemList = new ItemList() { items = new List<Item>() };
            itemList.items.Add(new Item()
            {
                name = "Item Name",
                currency = "USD",
                price = "15",
                quantity = "5",
                sku = "sku"
            });

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
                amount = amount,
                item_list = itemList
            });

            var authorizationCodeParameters = new CreateFromAuthorizationCodeParameters();
		    authorizationCodeParameters.setClientId(Configuration.ClientId);
		    authorizationCodeParameters.setClientSecret(Configuration.ClientSecret);
		    authorizationCodeParameters.SetCode(authorizationCode);

		    var apiContext = new APIContext();
            apiContext.Config = Configuration.GetConfig();

            var tokenInfo = Tokeninfo.CreateFromAuthorizationCodeForFuturePayments(this.apiContext, authorizationCodeParameters);
            var accessToken = string.Format("{0} {1}", tokenInfo.token_type, tokenInfo.access_token);

            // ###Payment
            // A FuturePayment Resource
            this.futurePayment = new FuturePayment()
            {
                intent = "authorize",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return this.futurePayment.Create(accessToken, correlationId);
        }
    }
}
