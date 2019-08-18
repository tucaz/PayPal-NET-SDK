using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PhoneTest
    {
        public static readonly string PhoneJson = "{\"country_code\":\"001\",\"national_number\":\"5032141716\"}";

        public static Phone GetPhone()
        {
            return JsonFormatter.ConvertFromJson<Phone>(PhoneJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PhoneObjectTest()
        {
            var phone = GetPhone();
            Assert.Equal("5032141716", phone.national_number);
            Assert.Equal("001", phone.country_code);
        }

        [Fact, Trait("Category", "Unit")]
        public void PhoneConvertToJsonTest()
        {
            Assert.False(GetPhone().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PhoneToStringTest()
        {
            Assert.False(GetPhone().ToString().Length == 0);
        }
    }
}
