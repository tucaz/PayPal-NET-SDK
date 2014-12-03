using PayPal.Api;
using PayPal.Sample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayPal.Sample
{
    public abstract class BaseSamplePage : System.Web.UI.Page
    {
        protected RequestFlow flow;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Call this so the request/response flow is recorded and displayed properly.
            this.RegisterSampleRequestFlow();
            try
            {
                this.RunSample();
            }
            catch (Exception ex)
            {
                this.flow.RecordException(ex);
            }
            Server.Transfer("~/Response.aspx");
        }

        /// <summary>
        /// Primary method where each sample page should run their sample code.
        /// </summary>
        protected abstract void RunSample();

        protected void RegisterSampleRequestFlow()
        {
            if(this.flow == null)
            {
                this.flow = new RequestFlow();
            }
            HttpContext.Current.Items["Flow"] = this.flow;
        }
    }
}