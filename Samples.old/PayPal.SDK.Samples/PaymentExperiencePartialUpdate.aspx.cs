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
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

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

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Create profile", profile);
            //--------------------
            #endregion

            // Create the profile
            var response = profile.Create(apiContext);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(response);
            //--------------------
            #endregion

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

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Retrieve profile details", description: "ID: " + response.id);
            //--------------------
            #endregion

            // Get the profile object and partially update the profile.
            var retrievedProfile = WebProfile.Get(apiContext, response.id);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(retrievedProfile);
            this.flow.AddNewRequest("Partially update profile", patchRequest);
            //--------------------
            #endregion
            
            retrievedProfile.PartialUpdate(apiContext, patchRequest);

            #region Track Workflow
            //--------------------
            this.flow.RecordActionSuccess("Profile updated successfully");
            //--------------------
            #endregion

            #region Cleanup
            // Cleanup by deleting the newly-created profile
            retrievedProfile.Delete(apiContext);
            #endregion
        }
    }
}
