using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class ItemListTest
    {
        public static ItemList GetItemList()
        {
            List<Item> items = new List<Item>();
            items.Add(ItemTest.GetItem());
            items.Add(ItemTest.GetItem());
            ItemList itemList = new ItemList();
            itemList.items = items;
            itemList.shipping_address = ShippingAddressTest.GetShippingAddress();
            return itemList;
        }

        [TestMethod()]
        public void ItemListObjectTest()
        {
            var list = GetItemList();
            Assert.AreEqual(ShippingAddressTest.GetShippingAddress().recipient_name, list.shipping_address.recipient_name);
            Assert.AreEqual(list.items.Count, 2);
        }

        [TestMethod()]
        public void ItemListConvertToJsonTest()
        {
            Assert.IsFalse(GetItemList().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ItemListToStringTest()
        {
            Assert.IsFalse(GetItemList().ToString().Length == 0);
        }
    }
}
