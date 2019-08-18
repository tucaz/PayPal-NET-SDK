using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class InvoiceAddressTest
    {
        public static readonly string InvoiceAddressJson =
            "{\"line1\":\"2211\"," +
            "\"line2\":\"N 1st St\"," +
            "\"city\":\"San Jose\"," +
            "\"phone\":" + PhoneTest.PhoneJson + "," +
            "\"postal_code\":\"95131\"," +
            "\"state\":\"California\"," +
            "\"country_code\":\"US\"}";

        public static InvoiceAddress GetInvoiceAddress()
        {
            return JsonFormatter.ConvertFromJson<InvoiceAddress>(InvoiceAddressJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AddressObjectTest()
        {
            var add = GetInvoiceAddress();
            Assert.Equal("2211", add.line1);
            Assert.Equal("N 1st St", add.line2);
            Assert.Equal("San Jose", add.city);
            Assert.Equal("California", add.state);
            Assert.Equal("95131", add.postal_code);
            Assert.Equal("US", add.country_code);
            Assert.NotNull(add.phone);
        }

        [Fact, Trait("Category", "Unit")]
        public void AddressConvertToJsonTest()
        {
            Assert.False(GetInvoiceAddress().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void AddressToStringTest()
        {
            Assert.False(GetInvoiceAddress().ToString().Length == 0);
        }
    }
}
