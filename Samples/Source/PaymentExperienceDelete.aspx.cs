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
    public partial class PaymentExperienceDelete : BaseSamplePage
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

            // Delete the newly-created profile
            this.flow.AddNewRequest("Retrieve profile", description: "ID: " + response.id);
            var retrievedProfile = WebProfile.Get(this.apiContext, response.id);
            this.flow.RecordResponse(retrievedProfile);

            this.flow.AddNewRequest("Delete profile", description: "ID: " + retrievedProfile.id);
            retrievedProfile.Delete(this.apiContext);
            this.flow.RecordActionSuccess("Profile deleted successfully");
        }
    }
}
