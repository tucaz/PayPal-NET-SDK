// #CreateCreditCard Sample
// Using the 'vault' API, you can store a 
// Credit Card securely on PayPal. You can
// use a saved Credit Card to process
// a payment in the future.
// The following code demonstrates how 
// can save a Credit Card on PayPal using 
// the Vault API.
// API used: POST /v1/vault/credit-card
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class CreateCreditCard : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ###CreditCard
            // A resource representing a credit card that can be
            // used to fund a payment.
            var card = new CreditCard()
            {
                expire_month = 11,
                expire_year = 2018,
                number = "4877274905927862",
                type = "visa"
            };

            // ###Save
            // Creates the credit card as a resource
            // in the PayPal vault. The response contains
            // an 'id' that you can use to refer to it
            // in the future payments.
            this.flow.AddNewRequest("Create credit card", card);
            this.flow.RecordResponse(card.Create(this.apiContext));
        }
    }
}
