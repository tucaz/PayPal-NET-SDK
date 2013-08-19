using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for TransactionTest and is intended
    ///to contain all TransactionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TransactionTest
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

        [TestMethod()]
        public void TestTransactions()
        {
            Transactions transactions = CreateTransactions();
            Assert.AreEqual(transactions.amount.total, "100");
        }

        [TestMethod()]
        public void TestConvertToJson()
        {
            Transactions transactions = CreateTransactions();
            Assert.IsFalse(transactions.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TestToString()
        {
            Transactions transactions = CreateTransactions();
            Assert.IsFalse(transactions.ToString().Length == 0);
        }
    }
}
