// #DeleteCreditCard Sample
// This sample code demonstrates how you 
// delete a previously saved 
// Credit Card using the 'vault' API.
// API used: DELETE /v1/vault/credit-card/{id}
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class DeleteCreditCard : BaseSamplePage
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

            // Create a new credit card resource that will be deleted for demonstration purposes.
            var credtCard = new CreditCard()
            {
                expire_month = 11,
                expire_year = 2018,
                number = "4877274905927862",
                type = "visa"
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            flow.AddNewRequest("Create credit card", credtCard);
            #endregion

            // Creates the credit card as a resource in the PayPal vault. The response contains an 'id' that you can use to refer to it in future payments.
            var createdCreditCard = credtCard.Create(apiContext);
            var createdCardId = createdCreditCard.id;

            // ^ Ignore workflow code segment
            #region Track Workflow
            flow.RecordResponse(createdCreditCard);
            this.flow.AddNewRequest("Get stored credit card details", description: "ID: " + createdCardId);
            #endregion

            // Retrieve the credit card information for the new created resource.
            var card = CreditCard.Get(apiContext, createdCardId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(card);
            this.flow.AddNewRequest("Delete credit card", description: "ID: " + card.id);
            #endregion

            // Delete the credit card
            card.Delete(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordActionSuccess("Credit card deleted successfully");
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}
