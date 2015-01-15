using System.Text;
using Newtonsoft.Json;
using PayPal.Api;

namespace PayPal
{
    public class PaymentsException : HttpException
    {
        /// <summary>
        /// Gets a <see cref="PayPal.PaymentsError"/> JSON object containing the parsed details of the Payments error.
        /// </summary>
        public Error Details { get; private set; }

        /// <summary>
        /// Copy constructor that attempts to deserialize the response from the specified <paramref name="PayPal.HttpException"/>.
        /// </summary>
        /// <param name="ex">Originating <see cref="PayPal.HttpException"/> object that contains the details of the exception.</param>
        public PaymentsException(HttpException ex) : base(ex)
        {
            if (!string.IsNullOrEmpty(this.Response))
            {
                this.Details = JsonFormatter.ConvertFromJson<Error>(this.Response);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("   Error:    " + this.Details.name);
                sb.AppendLine("   Message:  " + this.Details.message);
                sb.AppendLine("   URI:      " + this.Details.information_link);
                sb.AppendLine("   Debug ID: " + this.Details.debug_id);

                if (this.Details.details != null)
                {
                    foreach (ErrorDetails errorDetails in this.Details.details)
                    {
                        sb.AppendLine("   Details:  " + errorDetails.field + " -> " + errorDetails.issue);
                    }
                }
                this.LogMessage(sb.ToString());
            }
        }

        /// <summary>
        /// Gets the prefix to use when logging the exception information.
        /// </summary>
        protected override string ExceptionMessagePrefix { get { return "Payments Exception"; } }
    }
}
