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
        public static void WriteConnectionExceptionDetails(ConnectionException ex)
        {
            System.Diagnostics.Trace.WriteLine("[WebExceptionStatus]: " + ex.WebExceptionStatus);
            System.Diagnostics.Trace.WriteLine("[Response]: " + ex.Response);
        }
    }
}
