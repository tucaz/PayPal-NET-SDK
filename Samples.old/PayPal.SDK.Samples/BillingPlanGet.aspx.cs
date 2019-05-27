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
using PayPal.Sample.Utilities;

namespace PayPal.Sample
{
    /// <summary>
    /// Sample for retrieving a PayPal Billing Plan
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#retrieve-a-plan
    /// </summary>
    public partial class BillingPlanGet : BaseSamplePage
    {
        protected override void RunSample()
        {
            var planId = "P-5FY40070P6526045UHFWUVEI";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest(title: "Get billing plan", description: "ID: " + planId);
            //--------------------
            #endregion

            var plan = Plan.Get(Configuration.GetAPIContext(), planId);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(plan);
            //--------------------
            #endregion
        }
    }
}
