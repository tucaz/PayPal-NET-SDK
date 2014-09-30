using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass]
    public class TransactionTest
    {
        public static Transaction GetTransaction()
        {
            var transaction = new Transaction();
            transaction.description = "Test Description";
            transaction.note_to_payee = "Test note to payee";
            transaction.amount = AmountTest.GetAmount();
            transaction.payee = PayeeTest.GetPayee();
            transaction.item_list = ItemListTest.GetItemList();
            transaction.related_resources = new List<RelatedResources>();
            transaction.related_resources.Add(RelatedResourcesTest.GetRelatedResources());
            return transaction;
        }

        [TestMethod()]
        public void TransactionObjectTest()
        {
            var transaction = GetTransaction();
            Assert.AreEqual("Test Description", transaction.description);
            Assert.AreEqual("Test note to payee", transaction.note_to_payee);
            Assert.IsNotNull(transaction.amount);
            Assert.IsNotNull(transaction.payee);
            Assert.IsNotNull(transaction.item_list);
            Assert.IsNotNull(transaction.related_resources);
        }

        [TestMethod()]
        public void TransactionConvertToJsonTest()
        {
            Assert.IsFalse(GetTransaction().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TransactionToStringTest()
        {
            Assert.IsFalse(GetTransaction().ToString().Length == 0);
        }
    }
}
