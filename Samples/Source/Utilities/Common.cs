using System.Collections.Generic;
using PayPal.Api;
using PayPal;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal.Sample.Utilities;
using System;

namespace PayPal.Sample
{
    public static class Common
    {
        public static string FormatJsonString(string json)
        {
            if(string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }

            if (json.StartsWith("["))
            {
                // Hack to get around issue with the older Newtonsoft library
                // not handling a JSON array that contains no outer element.
                json = "{\"list\":" + json + "}";
                var formattedText = JObject.Parse(json).ToString(Formatting.Indented);
                formattedText = formattedText.Substring(13, formattedText.Length - 14).Replace("\n  ", "\n");
                return formattedText;
            }
            return JObject.Parse(json).ToString(Formatting.Indented);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiContext"></param>
        /// <returns></returns>
        public static Authorization CreateAuthorization(RequestFlow flow, APIContext apiContext)
        {
            // Base Address object used as shipping or billing address in a payment.
            var billingAddress = new Address()
            {
                city = "Johnstown",
                country_code = "US",
                line1 = "52 N Main ST",
                postal_code = "43210",
                state = "OH"
            };

            // A resource representing a credit card that can be used to fund a payment.
            var crdtCard = new CreditCard()
            {
                billing_address = billingAddress,
                cvv2 = "874",
                expire_month = 11,
                expire_year = 2018,
                first_name = "Joe",
                last_name = "Shopper",
                number = "4877274905927862",
                type = "visa"
            };

            // Let's you specify details of a payment amount.
            var details = new Details()
            {
                shipping = "0.03",
                subtotal = "107.41",
                tax = "0.03"
            };

            // Let's you specify a payment amount.
            var amnt = new Amount()
            {
                currency = "USD",
                // Total must be equal to sum of shipping, tax and subtotal.
                total = "107.47",
                details = details
            };

            // A transaction defines the contract of a payment - what is the payment for and who is fulfilling it. Transaction is created with a `Payee` and `Amount` types
            var tran = new Transaction()
            {
                amount = amnt,
                description = "This is the payment transaction description."
            };

            // The Payment creation API requires a list of transactions; add the created `Transaction` to a List
            var transactions = new List<Transaction>() { tran };

            // A resource representing a Payeer's funding instrument.
            // Use a Payer ID (A unique identifier of the payer generated
            // and provided by the facilitator. This is required when
            // creating or using a tokenized funding instrument)
            // and the `CreditCardDetails`
            var fundInstrument = new FundingInstrument()
            {
                credit_card = crdtCard
            };

            // The Payment creation API requires a list of
            // FundingInstrument; add the created `FundingInstrument`
            // to a List
            var fundingInstrumentList = new List<FundingInstrument>() { fundInstrument };

            // A resource representing a Payer that funds a payment. Use the List of `FundingInstrument` and the Payment Method as 'credit_card'
            var payr = new Payer()
            {
                funding_instruments = fundingInstrumentList,
                payment_method = "credit_card"
            };

            // ###Payment
            // A Payment Resource; create one using
            // the above types and intent as `sale`
            var pymnt = new Payment()
            {
                intent = "authorize",
                payer = payr,
                transactions = transactions
            };

            // Create a payment by posting to the APIService
            // using a valid APIContext
            flow.AddNewRequest(title: "Create authorization for credit card payment", requestObject: pymnt);
            Payment createdPayment = pymnt.Create(apiContext);
            flow.RecordResponse(createdPayment);

            return createdPayment.transactions[0].related_resources[0].authorization;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        public static Payment CreatePaymentOrder(RequestFlow flow, APIContext apiContext, string redirectUrl)
        {
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

            flow.AddNewRequest("Create payment order", payment);
            var createdPayment = payment.Create(apiContext);
            flow.RecordResponse(createdPayment);
            return createdPayment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="payerId"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public static Payment ExecutePayment(RequestFlow flow, APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            var payment = new Payment() { id = paymentId };

            flow.AddNewRequest("Execute payment", payment);
            var executedPayment = payment.Execute(apiContext, paymentExecution);
            flow.RecordResponse(executedPayment);
            return executedPayment;
        }

        public static Capture GetCapture(RequestFlow flow, APIContext apiContext, Authorization authorization)
        {
            var capture = new Capture()
            {
                is_final_capture = true,
                amount = new Amount()
                {
                    currency = "USD",
                    total = "1.00"
                }
            };

            // Capture by POSTing to
            // URI v1/payments/authorization/{authorization_id}/capture
            flow.AddNewRequest("Capture authorized payment", capture, string.Format("URI: v1/payments/authorization/{0}/capture", authorization.id));
            var responseCapture = authorization.Capture(apiContext, capture);
            flow.RecordResponse(responseCapture);
            return responseCapture;
        }

        public static CreditCard SaveCreditCard(RequestFlow flow, APIContext apiContext)
        {
            var credtCard = new CreditCard()
            {
                expire_month = 11,
                expire_year = 2018,
                number = "4877274905927862",
                type = "visa"
            };

            // Creates the credit card as a resource in the PayPal vault. The response contains an 'id' that you can use to refer to it in future payments.
            flow.AddNewRequest("Create credit card", credtCard);
            var createdCreditCard = credtCard.Create(apiContext);
            flow.RecordResponse(createdCreditCard);
            return createdCreditCard;
        }

        /// <summary>
        /// Gets a random invoice number to be used with a sample request that requires an invoice number.
        /// </summary>
        /// <returns>A random invoice number in the range of 0 to 999999</returns>
        public static string GetRandomInvoiceNumber()
        {
            return new Random().Next(999999).ToString();
        }
    }
}