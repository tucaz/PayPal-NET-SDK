using PayPal.Api;
using System;
using System.Collections.Generic;
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
    }
}