using PayPal.Util;

namespace PayPal.Api
{
    public class FuturePayment : Payment
    {
        /// <summary>
        /// Creates a future payment using the specified API context and correlation ID.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="correlationId">(Optional) Application correlation ID</param>
        /// <returns>A new payment object setup to be used for a future payment.</returns>
        public Payment Create(APIContext apiContext, string correlationId = "")
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            if (!string.IsNullOrEmpty(correlationId))
            {
                apiContext.HTTPHeaders["PAYPAL-CLIENT-METADATA-ID"] = correlationId;
            }

            return this.Create(apiContext);
        }
    }
}
