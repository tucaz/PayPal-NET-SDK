using PayPal.Sample.Utilities;
using System;
using System.Web;

namespace PayPal.Sample
{
    public partial class Response : System.Web.UI.Page
    {
        public RequestFlow Flow { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Flow = this.GetFromContext<RequestFlow>("Flow");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isRequest"></param>
        /// <returns></returns>
        protected string FormatPayloadText(string text, bool isRequest)
        {
            if(string.IsNullOrEmpty(text))
            {
                return string.Format("No payload for this {0}.", (isRequest ? "request" : "response"));
            }
            return text;
        }

        /// <summary>
        /// Gets the CSS class for the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected string GetMessageClass(RequestFlowItemMessage message)
        {
            switch(message.Type)
            {
                case RequestFlowItemMessageType.Error:
                    return "error";
                case RequestFlowItemMessageType.Success:
                    return "success";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Formats the message to include an accompanying icon from Font Awesome (http://fortawesome.github.io/Font-Awesome/).
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected string GetMessageWithMarkup(RequestFlowItemMessage message)
        {
            var iconText = "";
            switch(message.Type)
            {
                case RequestFlowItemMessageType.Error:
                    iconText = "<i class=\"fa fa-times-circle\"></i>";
                    break;

                case RequestFlowItemMessageType.Success:
                    iconText = "<i class=\"fa fa-check-circle\"></i>";
                    break;

                case RequestFlowItemMessageType.General:
                    iconText = "<i class=\"fa fa-info-circle\"></i>";
                    break;
            }
            return string.Format("{0} {1}", iconText, message.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetStringFromContext(string key)
        {
            return this.GetFromContext<string>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private T GetFromContext<T>(string key)
        {
            if(HttpContext.Current.Items.Contains(key))
            {
                return (T)HttpContext.Current.Items[key];
            }
            return default(T);
        }
    }
}
