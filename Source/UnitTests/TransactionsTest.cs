using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class TransactionsTest
    {
        public static Transactions GetTransactions()
        {
            Transactions transaction = new Transactions();
            transaction.amount = AmountTest.GetAmount();
            return transaction;
        }

        [TestMethod()]
        public void TransactionsObjectTest()
        {
            var transaction = GetTransactions();
            Assert.AreEqual(transaction.amount.currency, "USD");
            Assert.AreEqual(transaction.amount.details.tax, "15");
            Assert.AreEqual(transaction.amount.details.fee, "0");
            Assert.AreEqual(transaction.amount.details.shipping, "10");
            Assert.AreEqual(transaction.amount.details.subtotal, "75");
            Assert.AreEqual(transaction.amount.total, "100");
        }

        [TestMethod()]
        public void TransactionsConvertToJsonTest()
        {
            Assert.IsFalse(GetTransactions().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TransactionsToStringTest()
        {
            Assert.IsFalse(GetTransactions().ToString().Length == 0);
        }
    }
}
