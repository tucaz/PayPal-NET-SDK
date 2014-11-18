using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class PaymentExperienceUpdate : BaseSamplePage
    {
        protected override void RunSample()
        {
            var profile = new WebProfile();
            var patchRequest = new PatchRequest();

            // Setup the profile we want to create
            profile.name = Guid.NewGuid().ToString();
            profile.presentation = new Presentation();
            profile.presentation.brand_name = "Sample brand";
            profile.presentation.locale_code = "US";
            profile.presentation.logo_image = "https://www.paypal.com/";
            profile.input_fields = new InputFields();
            profile.input_fields.address_override = 1;
            profile.input_fields.allow_note = true;
            profile.input_fields.no_shipping = 0;
            profile.flow_config = new FlowConfig();
            profile.flow_config.bank_txn_pending_url = "https://www.paypal.com/";
            profile.flow_config.landing_page_type = "billing";

            // Create the profile
            this.flow.AddNewRequest("Create profile", profile);
            var response = profile.Create(this.apiContext);
            this.flow.RecordResponse(response);

            // Get the profile object and update the profile.
            this.flow.AddNewRequest("Retrieve profile details", description: "ID: " + response.id);
            var retrievedProfile = WebProfile.Get(this.apiContext, response.id);
            this.flow.RecordResponse(retrievedProfile);
            retrievedProfile.name = "A new name";

            this.flow.AddNewRequest("Update profile", retrievedProfile);
            retrievedProfile.Update(this.apiContext);
            this.flow.RecordActionSuccess("Profile updated successfully");

            // Cleanup by deleting the newly-created profile
            retrievedProfile.Delete(this.apiContext);
        }
    }
}
