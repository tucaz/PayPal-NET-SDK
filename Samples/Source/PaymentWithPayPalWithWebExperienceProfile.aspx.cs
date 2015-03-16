using PayPal.Api;
using PayPal.Sample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayPal.Sample
{
    public partial class PaymentWithPayPalWithWebExperienceProfile : BaseSamplePage
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

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                // Create the web experience profile
                var profile = new WebProfile
                {
                    name = Guid.NewGuid().ToString(),
                    presentation = new Presentation
                    {
                        brand_name = "PayPal .NET SDK",
                        locale_code = "US",
                        logo_image = "https://raw.githubusercontent.com/wiki/paypal/PayPal-NET-SDK/images/homepage.jpg"
                    },
                    input_fields = new InputFields
                    {
                        no_shipping = 1
                    }
                };


                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.AddNewRequest("Create new web experience profile (NOTE: This only needs to be done once)", profile);
                #endregion

                var createdProfile = profile.Create(apiContext);


                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.RecordResponse(createdProfile);
                #endregion

                // Setup the redirect URI to use. The guid value is used to keep the flow information.
                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPayPal.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                baseURI += "guid=" + guid + "&webProfileId=" + createdProfile.id;

                // Create the payment
                var payment = new Payment
                {
                    intent = "sale",
                    experience_profile_id = createdProfile.id,
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "Ticket information.",
                        item_list = new ItemList
                        {
                            items = new List<Item>
                            {
                                new Item
                                {
                                    name = "Concert ticket",
                                    currency = "USD",
                                    price = "20.00",
                                    quantity = "2",
                                    sku = "ticket_sku"
                                }
                            }
                        },
                        amount = new Amount
                        {
                            currency = "USD",
                            total = "45.00",
                            details = new Details
                            {
                                tax = "5.00",
                                subtotal = "40.00"
                            }
                        }
                    }
                },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = baseURI + "&return=true",
                        cancel_url = baseURI + "&cancel=true"
                    }
                };


                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.AddNewRequest("Create PayPal payment", payment);
                #endregion

                var createdPayment = payment.Create(apiContext);


                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow.RecordResponse(createdPayment);
                #endregion

                // Use the returned payment's approval URL to redirect the buyer to PayPal and approve the payment.
                var approvalUrl = createdPayment.GetApprovalUrl();

                this.flow.RecordRedirectUrl("Redirect to PayPal to approve the payment...", approvalUrl);
                Session.Add(guid, createdPayment.id);
                Session.Add("flow-" + guid, this.flow);
            }
            else
            {
                var guid = Request.Params["guid"];
                var webProfileId = Request.Params["webProfileId"];
                var isReturnSet = Request.Params["return"];

                // ^ Ignore workflow code segment
                #region Track Workflow
                this.flow = Session["flow-" + guid] as RequestFlow;
                this.RegisterSampleRequestFlow();
                this.flow.RecordApproval("PayPal payment approved successfully.");
                #endregion

                if (string.IsNullOrEmpty(isReturnSet))
                {
                    // ^ Ignore workflow code segment
                    #region Track Workflow
                    this.flow.RecordApproval("PayPal payment canceled by buyer.");
                    #endregion
                }
                else
                {
                    // ^ Ignore workflow code segment
                    #region Track Workflow
                    this.flow.RecordApproval("PayPal payment approved successfully.");
                    #endregion

                    // Using the information from the redirect, setup the payment to execute.
                    var paymentId = Session[guid] as string;
                    var paymentExecution = new PaymentExecution() { payer_id = payerId };
                    var payment = new Payment() { id = paymentId };

                    // ^ Ignore workflow code segment
                    #region Track Workflow
                    this.flow.AddNewRequest("Execute PayPal payment", payment);
                    #endregion

                    // Execute the payment.
                    var executedPayment = payment.Execute(apiContext, paymentExecution);
                    // ^ Ignore workflow code segment
                    #region Track Workflow
                    this.flow.RecordResponse(executedPayment);
                    #endregion
                }

                // Cleanup - Because there's a limit to the number of experience profile IDs you can create,
                // we'll delete the one that was created for this sample.
                WebProfile.Delete(apiContext, webProfileId);

                // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
            }
        }
    }
}