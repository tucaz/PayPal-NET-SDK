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

            // A resource representing a credit card that can be used to fund a payment.
            var card = new CreditCard()
            {
                expire_month = 11,
                expire_year = 2018,
                number = "4877274905927862",
                type = "visa",
                cvv2 = "874"
            };

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Create credit card", card);
            //--------------------
            #endregion

            // Creates the credit card as a resource in the PayPal vault. The response contains an 'id' that you can use to refer to it in the future payments.
            var createdCard = card.Create(apiContext);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(createdCard);
            this.flow.AddNewRequest("Retrieve credit card details", description: "ID: " + createdCard.id);
            //--------------------
            #endregion

            // Get the credit card.
            var retrievedCard = CreditCard.Get(apiContext, createdCard.id);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(retrievedCard);
            //--------------------
            #endregion
        }
    }
}
