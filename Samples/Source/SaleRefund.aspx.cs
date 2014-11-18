// #SaleRefund Sample
// This sample code demonstrate how you can 
// process a refund on a sale transaction created 
// using the Payments API.
// API used: /v1/payments/sale/{sale-id}/refund
using System;
using System.Web;
using PayPal;
using PayPal.Api;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PayPal.Sample
{
    public partial class SaleRefund : BaseSamplePage
    {
        protected override void RunSample()
        {
            // A refund transaction. Use the amount to create a refund object
            var refund = new Refund()
            {
                amount = new Amount()
                {
                    currency = "USD",
                    total = "0.01"
                }
            };

            // Create a Sale object with the given sale transaction id.
            Sale sale = new Sale();
            sale.id = "1L304068UD1406339";
            
            // Refund by posting Refund object using a valid APIContext
            this.flow.AddNewRequest("Refund sale", refund, string.Format("URI: /v1/payments/sale/{0}/refund", sale.id));
            this.flow.RecordResponse(sale.Refund(this.apiContext, refund));
        }
    }
}
