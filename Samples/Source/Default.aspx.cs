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
                            new SampleItem() { Title = "Make a payment with a PayPal account", ExecutePage = "PaymentWithPayPal.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Make a payment with a credit card", ExecutePage = "PaymentWithCreditCard.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Make a payment with a stored credit card", ExecutePage = "PaymentWithSavedCard.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of a payment", ExecutePage = "GetPayment.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve a history of payments", ExecutePage = "GetPaymentHistory.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of a sale transaction (completed payment)", ExecutePage = "GetSale.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Refund a sale", ExecutePage = "SaleRefund.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of a refund", ExecutePage = "GetRefund.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Create and process an order", ExecutePage = "OrderSample.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of an authorized payment", ExecutePage = "GetAuthorization.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Capture an authorized payment", ExecutePage = "AuthorizationCapture.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Void an authorized payment", ExecutePage = "AuthorizationVoid.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Reauthorize a payment", ExecutePage = "Reauthorization.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of a captured payment", ExecutePage = "GetCapture.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Refund a captured payment", ExecutePage = "RefundCapture.aspx", HasSourcePage = true }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Vault",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Create and store a credit card", ExecutePage = "CreateCreditCard.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of a credit card", ExecutePage = "GetCreditCard.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Delete a credit card", ExecutePage = "DeleteCreditCard.aspx", HasSourcePage = true }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Web Experience Profiles for Payments",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Create a new web experience profile", ExecutePage = "PaymentExperienceCreate.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve a web experience profile", ExecutePage = "PaymentExperienceGet.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "List web experience profiles", ExecutePage = "PaymentExperienceGetList.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Update a web experience profile", ExecutePage = "PaymentExperienceUpdate.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Partially update a web experience profile", ExecutePage = "PaymentExperiencePartialUpdate.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Delete a web experience profile", ExecutePage = "PaymentExperienceDelete.aspx", HasSourcePage = true }
                        }
                    },
                    new SampleCategory()
                    {
                        Title = "Billing Plans &amp; Agreements",
                        Items = new List<SampleItem>()
                        {
                            new SampleItem() { Title = "Create a billing plan", ExecutePage = "BillingPlanCreate.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Update a billing plan", ExecutePage = "BillingPlanUpdate.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve the details of a billing plan", ExecutePage = "BillingPlanGet.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Retrieve a list of billing plans", ExecutePage = "BillingPlanGetList.aspx", HasSourcePage = true },
                            new SampleItem() { Title = "Create &amp; execute a billing agreement", ExecutePage = "BillingAgreementCreateAndExecute.aspx", HasSourcePage = true }
                        }
                    }
                };
            }
        }

        private string GetSourceLink(string page)
        {
            return string.Format("{0}?viewSource=true", page);
        }
    }
}
