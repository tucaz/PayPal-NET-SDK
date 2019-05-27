using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayPal.Sample
{
    public partial class InvoiceGet : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
            var apiContext = Configuration.GetAPIContext();

            var invoiceId = "INV2-W6VG-MFK4-HQRT-RS6Z";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Retrieve the invoice", description: "ID: " + invoiceId);
            #endregion

            // Retrieve the invoice
            // ID: INV2-W6VG-MFK4-HQRT-RS6Z
            var invoice = Invoice.Get(apiContext, invoiceId);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(invoice);
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}