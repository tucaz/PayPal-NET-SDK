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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PayPal.Api.Payments;

namespace RestApiSample
{
    /// <summary>
    /// Sample for getting a list of PayPal Billing Plans associated with the account configured in web.config.
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#list-plans
    /// </summary>
    public partial class BillingPlanGetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var planList = Plan.List(Configuration.GetAPIContext());
                HttpContext.Current.Items.Add("ResponseJson", Common.FormatJsonString(planList.ConvertToJson()));
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
