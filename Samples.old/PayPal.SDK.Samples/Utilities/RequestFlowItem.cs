using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayPal.Sample.Utilities
{
    public enum RequestFlowItemMessageType
    {
        General,
        Success,
        Error
    }

    public class RequestFlowItemMessage
    {
        /// <summary>
        /// Gets or sets the message to accompany a flow item.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets what type of message this object contains.
        /// </summary>
        public RequestFlowItemMessageType Type { get; set; }
    }

    public class RequestFlowItem
    {
        /// <summary>
        /// Gets or sets the title of this portion of the flow.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets text describing this portion of the flow.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of messages to accompany this flow item.
        /// </summary>
        public List<RequestFlowItemMessage> Messages { get; set; }

        /// <summary>
        /// Gets or sets the request body.
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Gets or sets the response body.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets whether or not the response was an error response.
        /// </summary>
        public bool IsErrorResponse { get; set; }

        /// <summary>
        /// Gets or sets a redirect URL that should accompany this flow item.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets the text for the redirect URL.
        /// </summary>
        public string RedirectUrlText { get; set; }

        /// <summary>
        /// Gets or sets whether the redirect URL has been approved.
        /// </summary>
        public bool IsRedirectApproved { get; set; }

        /// <summary>
        /// Gets or sets an image associated with this flow item.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RequestFlowItem()
        {
            this.Messages = new List<RequestFlowItemMessage>();
        }

        /// <summary>
        /// Records an exception encountered during this portion of the flow.
        /// </summary>
        /// <param name="ex">The exception to be recorded.</param>
        public void RecordException(Exception ex)
        {
            this.IsErrorResponse = true;

            if (ex is ConnectionException)
            {
                this.Response = Common.FormatJsonString(((ConnectionException)ex).Response);
                if (string.IsNullOrEmpty(ex.Message))
                {
                    this.RecordError(string.Format("Error thrown from SDK as type {0}.", ex.GetType().ToString()));
                }
                else
                {
                    this.RecordError(ex.Message);
                }
            }
            else if (ex is PayPalException && ex.InnerException != null)
            {
                this.RecordError(ex.InnerException.Message);
            }
            else
            {
                this.RecordError(ex.Message);
            }
        }

        /// <summary>
        /// Records a message that will be displayed as an error.
        /// </summary>
        /// <param name="message">The error message</param>
        public void RecordError(string message)
        {
            this.RecordMessage(message, RequestFlowItemMessageType.Error);
        }

        /// <summary>
        /// Records a message that will be displayed as a success message.
        /// </summary>
        /// <param name="message">The success message</param>
        public void RecordSuccess(string message)
        {
            this.RecordMessage(message, RequestFlowItemMessageType.Success);
        }

        /// <summary>
        /// Records a message that will be displayed with this flow item.
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="type">The message type</param>
        public void RecordMessage(string message, RequestFlowItemMessageType type = RequestFlowItemMessageType.General)
        {
            this.Messages.Add(new RequestFlowItemMessage() { Message = message, Type = type });
        }
    }
}