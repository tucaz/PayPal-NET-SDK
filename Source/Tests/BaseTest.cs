using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    public abstract class BaseTest
    {
        private bool hasPreviousRecordings;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void Setup()
        {
            this.hasPreviousRecordings = false;
        }

        [TestCleanup]
        public virtual void TearDown()
        {
            if(this.hasPreviousRecordings)
            {
                Trace.WriteLine("]");
            }
        }

        /// <summary>
        /// Helper method for functional tests where we want to record more details.
        /// </summary>
        /// <param name="success">True if the connection behaved correctly; false otherwise.</param>
        /// <param name="ex">The exception containing the information to be recorded.</param>
        protected void RecordConnectionDetails(bool success = true)
        {
            Trace.WriteLine(hasPreviousRecordings ? ",{" : "[{");

            bool hasRequestDetails = PayPalResource.LastRequestDetails != null && PayPalResource.LastRequestDetails.Value != null;
            bool hasResponseDetails = PayPalResource.LastResponseDetails != null && PayPalResource.LastResponseDetails.Value != null;

            Trace.WriteLine("  \"test\": \"" + this.TestContext.TestName + "\",");
            Trace.WriteLine("  \"success\": " + success.ToString().ToLower() + (hasRequestDetails || hasResponseDetails ? "," : ""));

            // Record the request details.
            if (hasRequestDetails)
            {
                Trace.WriteLine("  \"request\": {");
                var request = PayPalResource.LastRequestDetails.Value;
                Trace.WriteLine("    \"url\": \"" + request.Url + "\",");
                Trace.WriteLine("    \"headers\": \"" + request.Headers.ToString().Trim() + "\",");

                if (request.Headers[System.Net.HttpRequestHeader.ContentType] == BaseConstants.ContentTypeHeaderJson)
                {
                    Trace.WriteLine("    \"body\": " + request.Body);
                }
                else
                {
                    Trace.WriteLine("    \"body\": \"" + request.Body + "\"");
                }

                Trace.WriteLine("  }" + (hasResponseDetails ? "," : ""));
            }

            // Record the response details, starting with any exception-related information (if provided).
            if (hasResponseDetails)
            {
                Trace.WriteLine("  \"response\": {");
                var response = PayPalResource.LastResponseDetails.Value;
                if (response.Exception != null)
                {
                    Trace.WriteLine("    \"webExceptionStatus\": \"" + response.Exception.WebExceptionStatus + "\",");
                }

                if (response.StatusCode.HasValue)
                {
                    Trace.WriteLine("    \"status\": \"" + (int)response.StatusCode + "\",");
                }

                Trace.WriteLine("    \"headers\": \"" + response.Headers.ToString().Trim() + "\",");

                if (response.Headers[System.Net.HttpResponseHeader.ContentType] == BaseConstants.ContentTypeHeaderJson)
                {
                    Trace.WriteLine("    \"body\": " + response.Body);
                }
                else
                {
                    Trace.WriteLine("    \"body\": \"" + response.Body + "\"");
                }
                Trace.WriteLine("  }");
            }
            Trace.WriteLine("}");

            this.hasPreviousRecordings = true;
        }
    }
}
