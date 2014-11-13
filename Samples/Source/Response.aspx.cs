using System;
using System.Web;

namespace PayPal.Sample
{
    public partial class Response : System.Web.UI.Page
    {
        protected String RedirectURL { get; set; }
        public string RedirectURLText { get; set; }
        protected string ErrorMessage { get; set; }
        public string RequestMessage { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseTitle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ErrorMessage = this.GetFromContext("Error");
                this.RedirectURL = this.GetFromContext("RedirectURL");
                this.RequestMessage = this.GetFromContext("RequestJson");
                this.ResponseMessage = this.GetFromContext("ResponseJson");
                this.ResponseTitle = this.GetFromContext("ResponseTitle");
                this.RedirectURLText = this.GetFromContext("RedirectURLText");
            }
        }

        private string GetFromContext(string key)
        {
            if (HttpContext.Current.Items.Contains(key))
            {
                return HttpContext.Current.Items[key] as string;
            }
            return null;
        }
    }
}
