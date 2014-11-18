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
    public partial class PaymentExperiencePartialUpdate : BaseSamplePage
    {
        protected override void RunSample()
        {
            // Setup the profile we want to create
            var profile = new WebProfile()
            {
                name = Guid.NewGuid().ToString(),
                presentation = new Presentation()
                {
                    brand_name = "Sample brand",
                    locale_code = "US",
                    logo_image = "https://www.paypal.com/"
                },
                input_fields = new InputFields()
                {
                    address_override = 1,
                    allow_note = true,
                    no_shipping = 0
                },
                flow_config = new FlowConfig()
                {
                    bank_txn_pending_url = "https://www.paypal.com/",
                    landing_page_type = "billing"
                }
            };

            // Create the profile
            this.flow.AddNewRequest("Create profile", profile);
            var response = profile.Create(this.apiContext);
            this.flow.RecordResponse(response);

            // Create a patch and add it to the PatchRequest object used to
            // perform the partial update on the profile.
            var patchRequest = new PatchRequest()
            {
                new Patch()
                {
                    op = "add",
                    path = "/presentation/brand_name",
                    value = "New brand name"
                },
                new Patch()
                {
                    op = "remove",
                    path = "/flow_config/landing_page_type"
                }
            };

            // Get the profile object and partially update the profile.
            this.flow.AddNewRequest("Retrieve profile details", description: "ID: " + response.id);
            var retrievedProfile = WebProfile.Get(this.apiContext, response.id);
            this.flow.RecordResponse(retrievedProfile);

            this.flow.AddNewRequest("Partially update profile", patchRequest);
            retrievedProfile.PartialUpdate(this.apiContext, patchRequest);
            this.flow.RecordActionSuccess("Profile updated successfully");

            // Cleanup by deleting the newly-created profile
            retrievedProfile.Delete(this.apiContext);
        }
    }
}
