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
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

            // Retrieve the CreditCard object by calling the
            // static 'Get' method on the CreditCard resource
            // by passing a valid APIContext and CreditCard ID
            var cardId = "CARD-00N04036H5458422MKRIAWHY";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Retrieve credit card details", description: "ID: " + cardId);
            //--------------------
            #endregion

            var card = CreditCard.Get(apiContext, cardId);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(card);
            //--------------------
            #endregion
        }
    }
}
