
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class ShippingAddressTest
    {
        public static string ShippingAddressJson =
            "{\"recipient_name\":\"PayPalUser\"," +
            "\"line1\":\"2211\"," +
            "\"line2\":\"N 1st St\"," + 
            "\"city\":\"San Jose\"," +
            "\"phone\":\"5032141716\"," +
            "\"postal_code\":\"95131\"," +
            "\"state\":\"California\"," +
            "\"country_code\":\"US\"}";

        public static ShippingAddress GetShippingAddress()
        {
            return JsonFormatter.ConvertFromJson<ShippingAddress>(ShippingAddressJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void ShippingAddressObjectTest()
        {
            var shipping = GetShippingAddress();
            Assert.Equal("PayPalUser", shipping.recipient_name);
            Assert.Equal("2211", shipping.line1);
            Assert.Equal("N 1st St", shipping.line2);
            Assert.Equal("San Jose", shipping.city);
            Assert.Equal("95131", shipping.postal_code);
            Assert.Equal("California", shipping.state);
            Assert.Equal("US", shipping.country_code);
            Assert.Equal("5032141716", shipping.phone);
        }

        [Fact, Trait("Category", "Unit")]
        public void ShippingAddressConvertToJsonTest()
        {
            Assert.False(GetShippingAddress().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void ShippingAddressToStringTest()
        {
            Assert.False(GetShippingAddress().ToString().Length == 0);
        }
    }
}
