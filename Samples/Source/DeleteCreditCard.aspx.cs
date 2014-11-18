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
            var createdCardId = Common.SaveCreditCard(this.flow, this.apiContext).id;
            this.flow.AddNewRequest("Get stored credit card details", description: "ID: " + createdCardId);
            var card = CreditCard.Get(this.apiContext, createdCardId);
            this.flow.RecordResponse(card);

            // Delete the credit card
            this.flow.AddNewRequest("Delete credit card", description: "ID: " + card.id);
            card.Delete(this.apiContext);
            this.flow.RecordActionSuccess("Credit card deleted successfully");

        }
    }
}
