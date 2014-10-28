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
    public partial class PaymentExperienceGetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var CurrContext = HttpContext.Current;

            try
            {
                var apiContext = Configuration.GetAPIContext();
                var profileList = WebProfile.GetList(apiContext);
                CurrContext.Items.Add("ResponseJson", Common.FormatJsonString(profileList.ConvertToJson()));
            }
            catch (Exception ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }
    }
}
