
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class ItemTest
    {
        public static readonly string ItemJson =
            "{\"name\":\"Item Name\"," +
            "\"currency\":\"USD\"," +
            "\"price\":\"10\"," +
            "\"quantity\":\"5\"," +
            "\"sku\":\"Sku\"}";

        public static Item GetItem()
        {
            return JsonFormatter.ConvertFromJson<Item>(ItemJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void ItemObjectTest()
        {
            var itm = GetItem();
            Assert.Equal(itm.name, "Item Name");
            Assert.Equal(itm.currency, "USD");
            Assert.Equal(itm.price, "10");
            Assert.Equal(itm.quantity, "5");
            Assert.Equal(itm.sku, "Sku");
        }

        [Fact, Trait("Category", "Unit")]
        public void ItemConvertToJsonTest()
        {
            Assert.False(GetItem().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void ItemToStringTest()
        {
            Assert.False(GetItem().ToString().Length == 0);
        }
    }
}
