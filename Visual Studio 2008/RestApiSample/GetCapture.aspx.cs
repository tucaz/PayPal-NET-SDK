// #GetCapture Sample
// This sample code demonstrates how to 
// retrieve a Capture resource
// API used: GET /v1/payments/capture/{capture_id}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PayPal.Api.Payments;
using PayPal;
using PayPal.Manager;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestApiSample
{
    public partial class GetCapture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;
            try
            {

                // ###AccessToken
                // Retrieve the access token from
                // OAuthTokenCredential by passing in
                // ClientID and ClientSecret
                // It is not mandatory to generate Access Token on a per call basis.
                // Typically the access token can be generated once and
                // reused within the expiry window
                string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperties()["ClientID"], ConfigManager.Instance.GetProperties()["ClientSecret"]).GetAccessToken();

                // ###Authorization
                // Retrieve a Authorization object
                // by making a Payment with intent
                // as 'authorize'
                Authorization authorization = GetAuthorization(accessToken);

                /// ###Capture
                // Create a Capture object
                // by doing a capture on
                // Authorization object
                // and retrieve the Id
                string captureId = GetCaptureId(accessToken, authorization);

                // Retrieve the Capture object by
                // doing a GET call to 
                // URI v1/payments/capture/{capture_id}
                Capture capture = Capture.Get(accessToken, captureId);
                CurrContext.Items.Add("ResponseJson", JObject.Parse(capture.ConvertToJson()).ToString(Formatting.Indented));

            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }

            Server.Transfer("~/Response.aspx");
        }

        private string GetCaptureId(string accessToken, Authorization authorization)
        {
            // ###Amount
            // Let's you specify a capture amount.
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.total = "4.54";

            Capture capture = new Capture();
            capture.amount = amnt;

            // ##IsFinalCapture
            // If set to true, all remaining 
            // funds held by the authorization 
            // will be released in the funding 
            // instrument. Default is ‘false’.
            capture.is_final_capture = true;

            // Capture by POSTing to
            // URI v1/payments/authorization/{authorization_id}/capture
            Capture responseCapture = authorization.Capture(accessToken, capture);

            return responseCapture.id;
        }

        private Authorization GetAuthorization(string accessToken)
        {
            // ###Address
            // Base Address object used as shipping or billing
            // address in a payment.
            Address billingAddress = new Address();
            billingAddress.city = "Johnstown";
            billingAddress.country_code = "US";
            billingAddress.line1 = "52 N Main ST";
            billingAddress.postal_code = "43210";
            billingAddress.state = "OH";

            // ###CreditCard
            // A resource representing a credit card that can be
            // used to fund a payment.
            CreditCard crdtCard = new CreditCard();
            crdtCard.billing_address = billingAddress;
            crdtCard.cvv2 = "874";
            crdtCard.expire_month = 11;
            crdtCard.expire_year = 2018;
            crdtCard.first_name = "Joe";
            crdtCard.last_name = "Shopper";
            crdtCard.number = "4417119669820331";
            crdtCard.type = "visa";

            // ###Details
            // Let's you specify details of a payment amount.
            Details details = new Details();
            details.shipping = "0.03";
            details.subtotal = "107.41";
            details.tax = "0.03";

            // ###Amount
            // Let's you specify a payment amount.
            Amount amnt = new Amount();
            amnt.currency = "USD";
            // Total must be equal to sum of shipping, tax and subtotal.
            amnt.total = "107.47";
            amnt.details = details;

            // ###Transaction
            // A transaction defines the contract of a
            // payment - what is the payment for and who
            // is fulfilling it. Transaction is created with
            // a `Payee` and `Amount` types
            Transaction tran = new Transaction();
            tran.amount = amnt;
            tran.description = "This is the payment transaction description.";

            // The Payment creation API requires a list of
            // Transaction; add the created `Transaction`
            // to a List
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(tran);

            // ###FundingInstrument
            // A resource representing a Payeer's funding instrument.
            // Use a Payer ID (A unique identifier of the payer generated
            // and provided by the facilitator. This is required when
            // creating or using a tokenized funding instrument)
            // and the `CreditCardDetails`
            FundingInstrument fundInstrument = new FundingInstrument();
            fundInstrument.credit_card = crdtCard;

            // The Payment creation API requires a list of
            // FundingInstrument; add the created `FundingInstrument`
            // to a List
            List<FundingInstrument> fundingInstrumentList = new List<FundingInstrument>();
            fundingInstrumentList.Add(fundInstrument);

            // ###Payer
            // A resource representing a Payer that funds a payment
            // Use the List of `FundingInstrument` and the Payment Method
            // as 'credit_card'
            Payer payr = new Payer();
            payr.funding_instruments = fundingInstrumentList;
            payr.payment_method = "credit_card";

            // ###Payment
            // A Payment Resource; create one using
            // the above types and intent as `sale`
            Payment pymnt = new Payment();
            pymnt.intent = "authorize";
            pymnt.payer = payr;
            pymnt.transactions = transactions;

            // Create a payment by posting to the APIService
            // using a valid AccessToken
            // The return object contains the status;
            Payment createdPayment = pymnt.Create(accessToken);

            return createdPayment.transactions[0].related_resources[0].authorization;
        }
    }
}
