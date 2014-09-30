using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ItemTest
    {
        public static Item GetItem()
        {
            Item itm = new Item();
            itm.name = "Item Name";
            itm.currency = "USD";
            itm.price = "10.50";
            itm.quantity = "5";
            itm.sku = "Sku";
            return itm;
        }

        [TestMethod()]
        public void ItemObjectTest()
        {
            var itm = GetItem();
            Assert.AreEqual(itm.name, "Item Name");
            Assert.AreEqual(itm.currency, "USD");
            Assert.AreEqual(itm.price, "10.50");
            Assert.AreEqual(itm.quantity, "5");
            Assert.AreEqual(itm.sku, "Sku");
        }

        [TestMethod()]
        public void ItemConvertToJsonTest()
        {
            Assert.IsFalse(GetItem().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ItemToStringTest()
        {
            Assert.IsFalse(GetItem().ToString().Length == 0);
        }
    }
}
