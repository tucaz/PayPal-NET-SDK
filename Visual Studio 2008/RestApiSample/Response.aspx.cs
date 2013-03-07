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
using System.Collections.Generic;

namespace RESTAPISample
{
    public partial class Response : System.Web.UI.Page
    {
        protected String RedirectURL
        {
            get;
            set;
        }

        protected string ErrorMessage
        {
            get;
            set;
        }

        public string RequestMessage
        {
            get;
            set;
        }


        public string ResponseMessage
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpContext CurrContext = HttpContext.Current;
                if (CurrContext.Items["Error"] != null)
                {
                    ErrorMessage = (String)CurrContext.Items["Error"];
                }

                if (CurrContext.Items["RedirectURL"] != null)
                {
                    RedirectURL = (String)CurrContext.Items["RedirectURL"];
                }
                if (CurrContext.Items["RequestJson"] != null)
                {
                    RequestMessage = (String)CurrContext.Items["RequestJson"];
                }
                if (CurrContext.Items["ResponseJson"] != null)
                {
                    ResponseMessage = (String)CurrContext.Items["ResponseJson"];
                }
            }
        }
    }
}
