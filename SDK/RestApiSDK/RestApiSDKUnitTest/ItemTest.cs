using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ItemTest
    { 
        private Item CreateItem()
        {
            Item item = new Item();
            item.name = "Item Name";
            item.currency = "USD";
            item.price = "10.50";
            item.quantity = "5";
            item.sku = "Sku";
            return item;
        }

        [TestMethod()]
        public void TestItem()
        {
            Item item = CreateItem();
            Assert.AreEqual(item.name, "Item Name");
            Assert.AreEqual(item.currency, "USD");
            Assert.AreEqual(item.price, "10.50");
            Assert.AreEqual(item.quantity, "5");
            Assert.AreEqual(item.sku, "Sku");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Item item = CreateItem();
            Assert.IsFalse(item.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Item item = CreateItem();
            Assert.IsFalse(item.ToString().Length == 0);
        }
    }
}
