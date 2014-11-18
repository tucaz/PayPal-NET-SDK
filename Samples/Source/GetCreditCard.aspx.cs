// #GetCreditCard Sample
// This sample code demonstrates how you 
// retrieve a previously saved 
// Credit Card using the 'vault' API.
// API used: GET /v1/vault/credit-card/{id}
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class GetCreditCard : BaseSamplePage
    {
        protected override void RunSample()
        {
            // Retrieve the CreditCard object by calling the
            // static 'Get' method on the CreditCard resource
            // by passing a valid APIContext and CreditCard ID
            var cardId = "CARD-00N04036H5458422MKRIAWHY";
            this.flow.AddNewRequest("Retrieve credit card details", description: "ID: " + cardId);
            this.flow.RecordResponse(CreditCard.Get(this.apiContext, cardId));
        }
    }
}
