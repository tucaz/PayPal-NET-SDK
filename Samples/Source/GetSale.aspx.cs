// # Get Details of a Sale Transaction Sample
// This sample code demonstrates how you can retrieve 
// details of completed Sale Transaction.
// API used: /v1/payments/sale/{sale-id}
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class GetSale : BaseSamplePage
    {
        protected override void RunSample()
        {
            APIContext apiContext = Configuration.GetAPIContext();

            var saleId = "4V7971043K262623A";
            this.flow.AddNewRequest("Get sale", description: "ID: " + saleId);
            this.flow.RecordResponse(Sale.Get(this.apiContext, saleId));
        }
    }
}
