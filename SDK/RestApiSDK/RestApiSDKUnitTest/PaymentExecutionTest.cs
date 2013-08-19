using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for PaymentExecutionTest and is intended
    ///to contain all PaymentExecutionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PaymentExecutionTest
    {
        private Details GetDetails()
        {
            Details amntDetails = new Details();
            amntDetails.tax = "15";
            amntDetails.fee = "2";
            amntDetails.shipping = "10";
            amntDetails.subtotal = "75";
            return amntDetails;
        }

        private Amount GetAmount()
        {
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.details = GetDetails();
            amnt.total = "100";
            return amnt;
        }

        public Transactions CreateTransactions()
        {
            Transactions transactions = new Transactions();
            transactions.amount = GetAmount();
            return transactions;
        }

        public ShippingAddress CreateShippingAddress()
        {
            ShippingAddress shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

        public PayerInfo CreatePayerInfo()
        {
            PayerInfo payerInfo = new PayerInfo();
            payerInfo.first_name = "Joe";
            payerInfo.last_name = "Shopper";
            payerInfo.email = "Joe.Shopper@email.com";
            payerInfo.payer_id = "100";
            payerInfo.phone = "12345";
            payerInfo.shipping_address = CreateShippingAddress();
            return payerInfo;
        }

        public PaymentExecution CreatePaymentExecution()
        {
            List<Transactions> transactions = new List<Transactions>();
            transactions.Add(CreateTransactions());
            PaymentExecution execution = new PaymentExecution();
            execution.payer_id = CreatePayerInfo().payer_id;
            execution.transactions = transactions;
            return execution;
        }

        [TestMethod()]
        public void TestPaymentExecution()
        {
            PaymentExecution execution = CreatePaymentExecution();
            Assert.AreEqual(execution.payer_id, "100");
        }

        [TestMethod()]
        public void TestConvertToJson()
        {
            PaymentExecution execution = CreatePaymentExecution();
            Assert.IsFalse(execution.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TestToString()
        {
            PaymentExecution execution = CreatePaymentExecution();
            Assert.IsFalse(execution.ToString().Length == 0);
        }
    }
}
