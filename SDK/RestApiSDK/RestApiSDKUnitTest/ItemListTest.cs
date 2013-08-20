using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ItemListTest
    {
        private ShippingAddress CreateShippingAddress()
        {
            ShippingAddress shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

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

        private ItemList CreateItemList() 
        {
	        List<Item> items = new List<Item>();
	        items.Add(CreateItem());
	        items.Add(CreateItem());
	        ItemList itemList = new ItemList();
            itemList.items = items;
            itemList.shipping_address = CreateShippingAddress();
	        return itemList;
	    }

	    [TestMethod()]
        public void TestItemList() 
        {
            ItemList list = CreateItemList();
		    Assert.AreEqual(CreateItemList().shipping_address.recipient_name, CreateShippingAddress().recipient_name);
            Assert.AreEqual(list.items.Count, 2);
	    }

	    [TestMethod()]
        public void ConvertToJsonTest() 
        {
            ItemList list = CreateItemList();
            Assert.IsFalse(list.ConvertToJson().Length == 0);
	    }

        [TestMethod()]
        public void ToStringTest() 
        {
            ItemList list = CreateItemList();
            Assert.IsFalse(list.ToString().Length == 0);
	    }        
    }
}
