using System;
using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class FuturePayment : Payment
    {
        /// <summary>
        /// Creates a future payment using an access token and correlation ID.
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <param name="correlationId">Application correlation ID</param>
        /// <returns>A new payment object setup to be used for a future payment.</returns>
        public Payment Create(string accessToken, string correlationId)
        {
            return this.Create(new APIContext(accessToken), correlationId);
        }

        /// <summary>
        /// Creates a future payment using the specified API context and correlation ID.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="correlationId">Application correlation ID</param>
        /// <returns>A new payment object setup to be used for a future payment.</returns>
        public Payment Create(APIContext apiContext, string correlationId)
        {
            if (apiContext == null)
            {
                throw new PayPal.Exception.MissingCredentialException("apiContext cannot be null.");
            }

            if (string.IsNullOrEmpty(correlationId))
            {
                throw new PayPal.Exception.MissingCredentialException("correlationId cannot be null or empty.");
            }

            if (apiContext.HTTPHeaders == null)
            {
                apiContext.HTTPHeaders = new Dictionary<string, string>();
            }

            apiContext.HTTPHeaders["Paypal-Application-Correlation-Id"] = correlationId;
            apiContext.HTTPHeaders["PAYPAL-CLIENT-METADATA-ID"] = correlationId;

            return this.Create(apiContext);
        }
    }
}
