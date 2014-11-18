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
            // ### Refund
            // Pass an APIContext and the ID of the refunded
            // transaction 
            var refundId = "7B165985YD577493B";
            this.flow.AddNewRequest("Get refund details", description: "ID: " + refundId);
            this.flow.RecordResponse(Refund.Get(this.apiContext, refundId));
        }
    }
}
