// #GetAuthorization Sample
// This sample code demonstrates how to 
// retrieve an Authorization resource
// API used: GET /v1/payments/authorization/{id}
using System;
using System.Web;
using PayPal.Api;
using PayPal;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PayPal.Sample
{
    public partial class GetAuthorization : BaseSamplePage
    {
        protected override void RunSample()
        {
            // ###Authorization
            // Retrieve an Authorization Id
            // by making a Payment with intent
            // as 'authorize' and parsing through
            // the Payment object
            string authorizationId = Common.CreateAuthorization(this.flow, this.apiContext).id;

            // Get Authorization by sending
            // a GET request with authorization Id
            // to the
            // URI v1/payments/authorization/{id}
            this.flow.AddNewRequest("Get authorization details", description: "ID: " + authorizationId);
            this.flow.RecordResponse(Authorization.Get(this.apiContext, authorizationId));
        }

    }
}
