// # Get Details of a Refund
// This sample code demonstrates how you can retrieve 
// details of refund.
// API used: /v1/refund/{id}
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class GetRefund : BaseSamplePage
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

            // ### Refund
            // Pass an APIContext and the ID of the refunded
            // transaction 
            var refundId = "7B165985YD577493B";

            #region Track Workflow
            //--------------------
            this.flow.AddNewRequest("Get refund details", description: "ID: " + refundId);
            //--------------------
            #endregion

            var refund = Refund.Get(apiContext, refundId);

            #region Track Workflow
            //--------------------
            this.flow.RecordResponse(refund);
            //--------------------
            #endregion
        }
    }
}
