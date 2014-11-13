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
    public partial class PaymentExperienceDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var CurrContext = HttpContext.Current;
            var profile = new WebProfile();

            try
            {
                var apiContext = Configuration.GetAPIContext();

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
                var response = profile.Create(apiContext);

                // Delete the newly-created profile
                var retrievedProfile = WebProfile.Get(apiContext, response.id);
                retrievedProfile.Delete(apiContext);
                CurrContext.Items.Add("ResponseJson", "Experience profile deleted successfully");
            }
            catch (Exception ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
