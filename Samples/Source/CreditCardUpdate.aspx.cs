using PayPal.Api;

namespace PayPal.Sample
{
    public partial class CreditCardUpdate : BaseSamplePage
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
                type = "visa"
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
            //--------------------
            #endregion

            // Create a `PatchRequest` that will define the fields to be updated in the credit card resource.
            var patchRequest = new PatchRequest
            {
                new Patch
                {
                    op = "replace",
                    path = "/expire_month",
                    value = 12
                }
            };

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Update credit card", patchRequest);
            //--------------------
            #endregion

            // Update the credit card.
            var updatedCard = createdCard.Update(apiContext, patchRequest);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(updatedCard);
            //--------------------
            #endregion
        }
    }
}