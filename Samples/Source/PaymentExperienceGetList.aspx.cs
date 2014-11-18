using PayPal.Api;

namespace PayPal.Sample
{
    public partial class PaymentExperienceGetList : BaseSamplePage
    {
        protected override void RunSample()
        {
            this.flow.AddNewRequest("Retrieve list of profiles");
            var profileList = WebProfile.GetList(this.apiContext);
            this.flow.RecordResponse(profileList);
        }
    }
}
