using PayPal.Api;

namespace PayPal.Sample
{
    public partial class CreditCardList : BaseSamplePage
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

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Search credit cards");
            //--------------------
            #endregion

            // ### Retrieve List of Credit Cards
            // Use `CreditCard.List()` to get a list of credit cards matching
            // the specified search critera. Use `pageSize` and `page` to page
            // through the results, or use the link marked `next` to get the
            // next list of results.
            var creditCardList = CreditCard.List(apiContext, startTime: "2014-11-01T00:00:00Z", endTime: "2014-12-01T00:00:00Z");

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(creditCardList);
            //--------------------
            #endregion
        }
    }
}