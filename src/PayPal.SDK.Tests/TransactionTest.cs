using System.Collections.Generic;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
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

        public static List<Transaction> GetTransactionList()
        {
            var transactionList = new List<Transaction>();
            transactionList.Add(GetTransaction());
            return transactionList;
        }

        [Fact, Trait("Category", "Unit")]
        public void TransactionObjectTest()
        {
            var transaction = GetTransaction();
            Assert.Equal("Test Description", transaction.description);
            Assert.Equal("Test note to payee", transaction.note_to_payee);
            Assert.NotNull(transaction.amount);
            Assert.NotNull(transaction.payee);
            Assert.NotNull(transaction.item_list);
            Assert.NotNull(transaction.related_resources);
        }

        [Fact, Trait("Category", "Unit")]
        public void TransactionConvertToJsonTest()
        {
            Assert.False(GetTransaction().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void TransactionToStringTest()
        {
            Assert.False(GetTransaction().ToString().Length == 0);
        }
    }
}
