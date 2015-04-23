using System;
using System.Collections.Generic;

namespace PayPal.Api
{
    /// <summary>
    /// APIContext is used when making HTTP calls to the PayPal REST API.
    /// </summary>
    public class APIContext
    {
        private string reqId;

        /// <summary>
        /// Explicit default constructor
        /// </summary>
        public APIContext() { }

        /// <summary>
        /// Access Token required for the call
        /// </summary>
        /// <param name="token"></param>
        public APIContext(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("AccessToken cannot be null");
            }
            this.AccessToken = token;
        }

        /// <summary>
        /// Access Token and Request Id required for the call
        /// </summary>
        /// <param name="token"></param>
        /// <param name="requestId"></param>
        public APIContext(string token, string requestId) : this(token)
        {
            if (string.IsNullOrEmpty(requestId))
            {
                throw new ArgumentNullException("RequestId cannot be null");
            }
            this.reqId = requestId;
        }

        /// <summary>
        /// Gets the Access Token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets or sets the Mask Request Id
        /// </summary>
        public bool MaskRequestId { get; set; }
        
        /// <summary>
        /// Gets the Request Id
        /// </summary>
        public string RequestId
        {
            get
            {
                string returnId = null;
                if (!this.MaskRequestId)
                {
                    if (string.IsNullOrEmpty(reqId))
                    {
                        reqId = Convert.ToString(Guid.NewGuid());
                    }
                    returnId = reqId;
                }
                return returnId;
            }
            set
            {
                this.reqId = value;
            }
        }

        /// <summary>
        /// Gets or sets the PayPal configuration settings to be used when making API requests.
        /// </summary>
        public Dictionary<string, string> Config { get; set; }

        /// <summary>
        /// Gets or sets the HTTP headers to include when making HTTP requests to the API.
        /// </summary>
        public Dictionary<string, string> HTTPHeaders { get; set; }

        /// <summary>
        /// Gets or sets the SDK version to include in the User-Agent header.
        /// </summary>
        public SDKVersion SdkVersion { get; set; }
    }
}
