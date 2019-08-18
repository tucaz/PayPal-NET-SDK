using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class AddressTest
    {
        public static readonly string AddressJson =
            "{\"line1\":\"2211\"," +
            "\"line2\":\"N 1st St\"," +
            "\"city\":\"San Jose\"," +
            "\"phone\":\"5032141716\"," +
            "\"postal_code\":\"95131\"," +
            "\"state\":\"California\"," +
            "\"country_code\":\"US\"}";

        public static Address GetAddress()
        {
            return JsonFormatter.ConvertFromJson<Address>(AddressJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AddressObjectTest()
        {
            var add = GetAddress();
            Assert.Equal("2211", add.line1);
            Assert.Equal("N 1st St", add.line2);
            Assert.Equal("San Jose", add.city);
            Assert.Equal("California", add.state);
            Assert.Equal("95131", add.postal_code);
            Assert.Equal("US", add.country_code);
            Assert.Equal("5032141716", add.phone);
        }

        [Fact, Trait("Category", "Unit")]
        public void AddressConvertToJsonTest()
        {
            Assert.False(GetAddress().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void AddressToStringTest()
        {
            Assert.False(GetAddress().ToString().Length == 0);
        }
    }
}
