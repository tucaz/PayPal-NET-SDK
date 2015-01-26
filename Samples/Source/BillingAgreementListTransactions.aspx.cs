using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;

namespace PayPal.Sample
{
    public partial class BillingAgreementListTransactions : BaseSamplePage
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

            // ### Retrieve the Billing Agreement
            // The billing agreement being retrieved is one that was previously created and executed using a PayPal account as the funding source.
            var agreementId = "I-6STR72E7JNP8";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest(title: "Get list of recent billing agreement transactions", description: "ID: " + agreementId);
            //--------------------
            #endregion

            // Use `Agreement.Get()` to retrieve the billing agreement details.
            var agreementTransactions = Agreement.ListTransactions(apiContext, agreementId, "2014-09-01", "2015-01-01");

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(agreementTransactions);
            //--------------------
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}