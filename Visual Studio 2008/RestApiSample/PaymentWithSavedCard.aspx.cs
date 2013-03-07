// #CreatePayment Using Saved Card Sample
// This sample code demonstrates how you can process a 
// Payment using a previously saved credit card.
// API used: /v1/payments/payment
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
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestApiSample
{
    public partial class PaymentWithSavedCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;

            // ###CreditCard
            // A resource representing a credit card that can be
            // used to fund a payment.
            CreditCardToken credCardToken = new CreditCardToken();
            credCardToken.credit_card_id = "CARD-5BT058015C739554AKE2GCEI";

            // ###AmountDetails
            // Let's you specify details of a payment amount.
            AmountDetails amntDetails = new AmountDetails();
            amntDetails.shipping = "1";
            amntDetails.subtotal = "5";
            amntDetails.tax = "1";

            // ###Amount
            // Let's you specify a payment amount.
            Amount amnt = new Amount();
            amnt.currency = "USD";
            // Total must be equal to the sum of shipping, tax and subtotal.
            amnt.total = "7";
            amnt.details = amntDetails;

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
            fundInstrument.credit_card_token = credCardToken;

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
            // the above types and intent as 'sale'
            Payment pymnt = new Payment();
            pymnt.intent = "sale";
            pymnt.payer = payr;
            pymnt.transactions = transactions;

            try
            {
                // ###AccessToken
                // Retrieve the access token from
                // OAuthTokenCredential by passing in
                // ClientID and ClientSecret
                // It is not mandatory to generate Access Token on a per call basis.
                // Typically the access token can be generated once and
                // reused within the expiry window
                string accessToken = new OAuthTokenCredential(ConfigManager.Instance.GetProperty("ClientID"), ConfigManager.Instance.GetProperty("ClientSecret")).GetAccessToken();

                // ### Api Context
                // Pass in a `ApiContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                APIContext apiContext = new APIContext(accessToken);
                // Use this variant if you want to pass in a request id  
                // that is meaningful in your application, ideally 
                // a order id.
                // String requestId = Long.toString(System.nanoTime();
                // APIContext apiContext = new APIContext(accessToken, requestId ));
                // Create a payment by posting to the APIService
                // using a valid AccessToken
                // The return object contains the status;

                // Create a payment by posting to the APIService
                // using a valid AccessToken
                // The return object contains the status;
                Payment createdPayment = pymnt.Create(apiContext);
                CurrContext.Items.Add("ResponseJson", JObject.Parse(createdPayment.ConvertToJson()).ToString(Formatting.Indented));
            }
            catch (PayPal.Exception.PayPalException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
            }
            CurrContext.Items.Add("RequestJson", JObject.Parse(pymnt.ConvertToJson()).ToString(Formatting.Indented));
            Server.Transfer("~/Response.aspx");
        }
    }
}
