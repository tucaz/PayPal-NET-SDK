using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class TransactionsTest
    {
        [TestMethod()]
        public void TestTransactions()
        {
            var transaction = UnitTestUtil.GetTransactions();
            Assert.AreEqual(transaction.amount.currency, "USD");
            Assert.AreEqual(transaction.amount.details.tax, "15");
            Assert.AreEqual(transaction.amount.details.fee, "2");
            Assert.AreEqual(transaction.amount.details.shipping, "10");
            Assert.AreEqual(transaction.amount.details.subtotal, "75");
            Assert.AreEqual(transaction.amount.total, "100");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var trans = UnitTestUtil.GetTransactions();
            Assert.IsFalse(trans.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var trans = UnitTestUtil.GetTransactions();
            Assert.IsFalse(trans.ToString().Length == 0);
        }
    }
}
