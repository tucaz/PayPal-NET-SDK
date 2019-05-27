using PayPal.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PayPal.Sample.Utilities
{
    public class RequestFlow
    {
        /// <summary>
        /// Gets the list of RequestFlowItems for this flow.
        /// </summary>
        public List<RequestFlowItem> Items { get; private set; }

        /// <summary>
        /// Gets or sets a general description of the flow.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Default construct that initializes the Items list.
        /// </summary>
        public RequestFlow()
        {
            this.Items = new List<RequestFlowItem>();
        }

        /// <summary>
        /// Adds a new RequestFlowItem to the list of Items.
        /// </summary>
        /// <param name="title">Title of this flow item.</param>
        /// <param name="requestObject">(Optional) The object used for the request.</param>
        /// <param name="description">(Optional) The description of the request.</param>
        public void AddNewRequest(string title, IPayPalSerializableObject requestObject = null, string description = "")
        {
            this.Items.Add(new RequestFlowItem()
            {
                Request = requestObject == null ? string.Empty : Common.FormatJsonString(requestObject.ConvertToJson()),
                Title = title,
                Description = description
            });
        }

        /// <summary>
        /// Records a response in the last RequestFlowItem stored in the Items list.
        /// </summary>
        /// <param name="responseObject"></param>
        public void RecordResponse(IPayPalSerializableObject responseObject)
        {
            if(responseObject != null && this.Items.Any())
            {
                this.Items.Last().Response = Common.FormatJsonString(responseObject.ConvertToJson());
            }
        }

        /// <summary>
        /// Records a success message that indicates the last request was successful.
        /// </summary>
        /// <param name="message"></param>
        public void RecordActionSuccess(string message)
        {
            if(this.Items.Any())
            {
                this.Items.Last().RecordSuccess(message);
            }
        }

        /// <summary>
        /// Records an image that was returned from a call (e.g. Invoice.QrCode)
        /// </summary>
        /// <param name="image"></param>
        public void RecordImage(Image image)
        {
            if(this.Items.Any())
            {
                var filename = "Images/sample.png";
                var serverRoot = HttpContext.Current.Server.MapPath(null);
                image.Save(Path.Combine(serverRoot, filename));
                this.Items.Last().ImagePath = filename;
            }
        }

        /// <summary>
        /// Records an exception that was encountered and ties it to the last RequestResponse object in the flow.
        /// </summary>
        /// <param name="ex"></param>
        public void RecordException(Exception ex)
        {
            if (ex != null)
            {
                if (!this.Items.Any())
                {
                    this.Items.Add(new RequestFlowItem());
                }
                this.Items.Last().RecordException(ex);
            }
        }

        /// <summary>
        /// Records a redirect URL that should be displayed with a flow item.
        /// </summary>
        /// <param name="text">The display text</param>
        /// <param name="redirectUrl">The URL for the redirect</param>
        public void RecordRedirectUrl(string text, string redirectUrl)
        {
            if(this.Items.Any())
            {
                this.Items.Last().RedirectUrlText = text;
                this.Items.Last().RedirectUrl = redirectUrl;
            }
        }

        /// <summary>
        /// Records that a resource has been approved for payment.
        /// </summary>
        /// <param name="message"></param>
        public void RecordApproval(string message)
        {
            if (this.Items.Any())
            {
                this.Items.Last().Title += " (Approved!)";
                this.Items.Last().RedirectUrlText = message;
                this.Items.Last().IsRedirectApproved = true;
            }
        }
    }
}