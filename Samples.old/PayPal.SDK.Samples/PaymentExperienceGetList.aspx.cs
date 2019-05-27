using PayPal.Api;

namespace PayPal.Sample
{
    public partial class PaymentExperienceGetList : BaseSamplePage
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
            this.flow.AddNewRequest("Retrieve list of profiles");
            #endregion
            
            var profileList = WebProfile.GetList(apiContext);

            #region Track Workflow
            this.flow.RecordResponse(profileList);
            #endregion
        }
    }
}
