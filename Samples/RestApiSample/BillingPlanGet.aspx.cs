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
using PayPal.Api.Payments;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RestApiSample
{
    /// <summary>
    /// Sample for retrieving a PayPal Billing Plan
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#retrieve-a-plan
    /// </summary>
    public partial class BillingPlanGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var plan = Plan.Get(Configuration.GetAPIContext(), "P-5FY40070P6526045UHFWUVEI");
                HttpContext.Current.Items.Add("ResponseJson", Common.FormatJsonString(plan.ConvertToJson()));
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
