
using System.Collections.Generic;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
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

        [Fact, Trait("Category", "Unit")]
        public void ItemListObjectTest()
        {
            var list = GetItemList();
            Assert.Equal(ShippingAddressTest.GetShippingAddress().recipient_name, list.shipping_address.recipient_name);
            Assert.Equal(list.items.Count, 2);
        }

        [Fact, Trait("Category", "Unit")]
        public void ItemListConvertToJsonTest()
        {
            Assert.False(GetItemList().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void ItemListToStringTest()
        {
            Assert.False(GetItemList().ToString().Length == 0);
        }
    }
}
