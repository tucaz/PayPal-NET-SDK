using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    public class TestingUtil
    {
        private static string GetAccessToken()
        {
            var oauth = new OAuthTokenCredential(ConfigManager.Instance.GetProperties());
            return oauth.GetAccessToken();
        }

        public static APIContext GetApiContext()
        {
            return new APIContext(GetAccessToken())
            {
                Config = ConfigManager.Instance.GetProperties()
            };
        }

        /// <summary>
        /// Invokes the specified action and checks whether or not the specified exception type is thrown. This allows for unit tests that more accurately
        /// capture when specific exceptions should be thrown.
        /// </summary>
        /// <typeparam name="T">The type of exception that is expected to be thrown from the given action.</typeparam>
        /// <param name="action">The action to be invoked.</param>
        public static void AssertThrownException<T>(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                if (typeof(T).Equals(ex.GetType()))
                {
                    return;
                }
                Assert.Fail("Expected " + typeof(T) + " to be thrown, but " + ex.GetType() + " was thrown instead.");
            }
            Assert.Fail("Expected " + typeof(T) + " to be thrown, but no exception was thrown.");
        }

        /// <summary>
        /// Helper method for functional tests where we want to record more details.
        /// </summary>
        /// <param name="ex">The exception containing the information to be recorded.</param>
        public static void RecordConnectionDetails()
        {
            // Record the request details.
            if (PayPalResource.LastRequestDetails != null && PayPalResource.LastRequestDetails.Value != null)
            {
                var request = PayPalResource.LastRequestDetails.Value;
                System.Diagnostics.Trace.WriteLine("[Request URL]: " + request.Url);
                System.Diagnostics.Trace.WriteLine("[Request Headers]: " + request.Headers.ToString().Trim());
                System.Diagnostics.Trace.WriteLine("[Request Body]: " + request.Body);
                System.Diagnostics.Trace.WriteLine("");
            }

            // Record the response details, starting with any exception-related information (if provided).
            if (PayPalResource.LastResponseDetails != null && PayPalResource.LastResponseDetails.Value != null)
            {
                var response = PayPalResource.LastResponseDetails.Value;
                if (response.Exception != null)
                {
                    System.Diagnostics.Trace.WriteLine("[WebExceptionStatus]: " + response.Exception.WebExceptionStatus);
                }

                if (response.StatusCode.HasValue)
                {
                    System.Diagnostics.Trace.WriteLine("[Response Status]: " + (int)response.StatusCode);
                }

                System.Diagnostics.Trace.WriteLine("[Response Headers]: " + response.Headers.ToString().Trim());
                System.Diagnostics.Trace.WriteLine("[Response]: " + response.Body);
            }
        }
    }
}
