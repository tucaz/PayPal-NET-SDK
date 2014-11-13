using System;
using System.Linq;
using System.Collections.Generic;
using PayPal.Sample.Utilities;

namespace PayPal.Sample
{
    public partial class Default : System.Web.UI.Page
    {
        protected List<SampleCategory> Categories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize the categories if this is the first time loading.
            if (this.Categories == null)
            {
                this.Categories = new List<SampleCategory>()
                {
                    new SampleCategory()
                    {
                        Title = "Payments",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Direct credit card payments", ExecutePage = "PaymentWithCreditCard.aspx" },
                            new SampleItem() { Title = "PayPal account payments", ExecutePage = "PaymentWithPayPal.aspx" },
                            new SampleItem() { Title = "Stored credit card payments", ExecutePage = "PaymentWithSavedCard.aspx" },
                            new SampleItem() { Title = "Get payment details", ExecutePage = "GetPayment.aspx" },
                            new SampleItem() { Title = "Get payment history", ExecutePage = "GetPaymentHistory.aspx" },
                            new SampleItem() { Title = "Run order sample", ExecutePage = "OrderSample.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Sale",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Get sale payment details", ExecutePage = "GetSale.aspx" },
                            new SampleItem() { Title = "Refund a sale payment", ExecutePage = "SaleRefund.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Refund",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Get refund details", ExecutePage = "GetRefund.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Vault",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Save a credit card", ExecutePage = "CreateCreditCard.aspx" },
                            new SampleItem() { Title = "Get credit card details", ExecutePage = "GetCreditCard.aspx" },
                            new SampleItem() { Title = "Delete a credit card", ExecutePage = "DeleteCreditCard.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Authorization",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Get authorized payment details", ExecutePage = "GetAuthorization.aspx" },
                            new SampleItem() { Title = "Capture an authorized payment", ExecutePage = "AuthorizationCapture.aspx" },
                            new SampleItem() { Title = "Void an authorized payment", ExecutePage = "AuthorizationVoid.aspx" },
                            new SampleItem() { Title = "Reauthorize an authorized payment", ExecutePage = "Reauthorization.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Capture",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Get captured payment details", ExecutePage = "GetCapture.aspx" },
                            new SampleItem() { Title = "Refund captured payment", ExecutePage = "RefundCapture.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Payment Experience (Web Profiles)",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Create a new web experience profile", ExecutePage = "PaymentExperienceCreate.aspx" },
                            new SampleItem() { Title = "Retrieve a web experience profile", ExecutePage = "PaymentExperienceGet.aspx" },
                            new SampleItem() { Title = "List web experience profiles", ExecutePage = "PaymentExperienceGetList.aspx" },
                            new SampleItem() { Title = "Update a web experience profile", ExecutePage = "PaymentExperienceUpdate.aspx" },
                            new SampleItem() { Title = "Partially update a web experience profile", ExecutePage = "PaymentExperiencePartialUpdate.aspx" },
                            new SampleItem() { Title = "Delete a web experience profile", ExecutePage = "PaymentExperienceDelete.aspx" }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Billing Plans &amp; Agreements",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Create a billing plan", ExecutePage = "BillingPlanCreate.aspx" },
                            new SampleItem() { Title = "Update a billing plan", ExecutePage = "BillingPlanUpdate.aspx" },
                            new SampleItem() { Title = "Retrieve a billing plan", ExecutePage = "BillingPlanGet.aspx" },
                            new SampleItem() { Title = "List billing plans", ExecutePage = "BillingPlanGetList.aspx" },
                            new SampleItem() { Title = "Create &amp; execute a billing agreement", ExecutePage = "BillingAgreementCreateAndExecute.aspx" }
                        }
                    }
                };



                // Billing Plans & Agreements

                // Sale

                // Vault

                // Authorization, Capture, Order

                // Payment Experience

                // Invoice

                // Identity (LIPP)
            }
        }
    }
}
