// #AuthorizationVoid Sample
// The sample code demonstrates
// how to void an
// authorized payment.
// API used: POST /v1/payments/authorization/{authorization_id}/void 
using System;
using System.Web;
using PayPal.Api;
using PayPal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPal.Sample
{
    public partial class AuthorizationVoid : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ###Authorization
            // Create an Authorization 
            // by making a Payment with intent
            // as 'authorize'
            var authorization = Common.CreateAuthorization(this.flow, this.apiContext);

            // Void the authorization
            this.flow.AddNewRequest("Void authorization", description: string.Format("URI: v1/payments/authorization/{0}/void", authorization.id));
            this.flow.RecordResponse(authorization.Void(this.apiContext));
        }
    }
}
