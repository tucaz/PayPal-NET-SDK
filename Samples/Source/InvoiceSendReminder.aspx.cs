using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayPal.Sample
{
    public partial class InvoiceSendReminder : BaseSamplePage
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

            // ### Create an invoice
            // For demonstration purposes, we will create a new invoice for this sample.
            var invoice = new Invoice()
            {
                // #### Merchant Information
                // Information about the merchant who is sending the invoice.
                merchant_info = new MerchantInfo()
                {
                    email = "jziaja.test.merchant-facilitator@gmail.com",
                    first_name = "Dennis",
                    last_name = "Doctor",
                    business_name = "Medical Professionals, LLC",
                    phone = new Phone()
                    {
                        country_code = "001",
                        national_number = "4083741550"
                    },
                    address = new InvoiceAddress()
                    {
                        line1 = "1234 Main St.",
                        city = "Portland",
                        state = "OR",
                        postal_code = "97217",
                        country_code = "US"
                    }
                },
                // #### Billing Information
                // Email address of invoice recipient and optional billing information.
                // > Note: PayPal currently only allows one recipient.
                billing_info = new List<BillingInfo>()
                {
                    new BillingInfo()
                    {
                        // **(Required)** Email address of the invoice recipient.
                        email = "example@example.com"
                    }
                },
                // #### Invoice Items
                // List of items to be included in the invoice.
                // > Note: 100 max per invoice.
                items = new List<InvoiceItem>()
                {
                    new InvoiceItem()
                    {
                        name = "Sutures",
                        quantity = 100,
                        unit_price = new Currency()
                        {
                            currency = "USD",
                            value = "5"
                        }
                    }
                },
                // #### Invoice Note
                // Note to the payer. Maximum length is 4000 characters.
                note = "Medical Invoice 16 Jul, 2013 PST",
                // #### Payment Term
                // **(Optional)** Specifies the payment deadline for the invoice.
                // > Note: Either `term_type` or `due_date` can be sent, **but not both.**
                payment_term = new PaymentTerm()
                {
                    term_type = "NET_30"
                },
                // #### Shipping Information
                // Shipping information for entities to whom items are being shipped.
                shipping_info = new ShippingInfo()
                {
                    first_name = "Sally",
                    last_name = "Patient",
                    business_name = "Not applicable",
                    address = new InvoiceAddress()
                    {
                        line1 = "1234 Broad St.",
                        city = "Portland",
                        state = "OR",
                        postal_code = "97216",
                        country_code = "US"
                    }
                }
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Create the invoice", invoice);
            #endregion

            // Create the invoice
            var createdInvoice = invoice.Create(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(createdInvoice);
            #endregion

            // Temporary work around for Invoicing API - the API is populating
            // information in the invoice that it should not be since we didn't
            // specify it originally.
            createdInvoice.billing_info[0].address = null;
            createdInvoice.discount = null;
            createdInvoice.payment_term.due_date = null;

            // For demonstration purposes, update the status to indicate that this invoice was already sent.
            createdInvoice.status = "SENT";

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Update the invoice status to 'SENT'", createdInvoice);
            #endregion

            // Update the invoice
            var updatedInvoice = createdInvoice.Update(apiContext);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordResponse(updatedInvoice);
            #endregion

            // Setup the reminder notification to be sent
            var notification = new Notification
            {
                subject = "Payment Reminder",
                note = "This is a reminder that payment is due on " + updatedInvoice.payment_term.due_date,
                send_to_merchant = true
            };

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.AddNewRequest("Send the reminder", notification);
            #endregion

            // Send the reminder
            updatedInvoice.Remind(apiContext, notification);

            // ^ Ignore workflow code segment
            #region Track Workflow
            this.flow.RecordActionSuccess("Reminder sent successfully.");
            #endregion

            // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
        }
    }
}