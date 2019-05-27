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
using PayPal.Api;

namespace PayPal.Sample
{
    /// <summary>
    /// Sample for getting a list of PayPal Billing Plans associated with the account configured in web.config.
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#list-plans
    /// </summary>
    public partial class BillingPlanGetList : BaseSamplePage
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

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Retrieve list of billing plans");
            //--------------------
            #endregion
            
            var planList = Plan.List(apiContext);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(planList);
            //--------------------
            #endregion
        }
    }
}
