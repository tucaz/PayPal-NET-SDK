// #GetPayment Sample
// This sample code demonstrates how you can retrieve
// the details of a payment resource.
// API used: /v1/payments/payment/{payment-i
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class GetPayment : BaseSamplePage
    {
        protected override void RunSample()
        {
            APIContext apiContext = Configuration.GetAPIContext();

            var paymentId = "PAY-9NE62270P51995617KRH6XOY";
            this.flow.AddNewRequest("Get payment details", description: "ID: " + paymentId);
            this.flow.RecordResponse(Payment.Get(this.apiContext, paymentId));
        }
    }
}
