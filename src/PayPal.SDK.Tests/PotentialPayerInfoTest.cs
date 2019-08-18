using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PotentialPayerInfoTest
    {
        public static readonly string PotentialPayerInfoJson =
            "{\"email\":\"test@example.com\"," +
            "\"external_remember_me_id\":\"1234\"," +
            "\"billing_address\":" + AddressTest.AddressJson + "}";

        public static PotentialPayerInfo GetPotentialPayerInfo()
        {
            return JsonFormatter.ConvertFromJson<PotentialPayerInfo>(PotentialPayerInfoJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PotentialPayerInfoObjectTest()
        {
            var testObject = GetPotentialPayerInfo();
            Assert.Equal("test@example.com", testObject.email);
			Assert.Equal("1234", testObject.external_remember_me_id);
			Assert.NotNull(testObject.billing_address);
        }

        [Fact, Trait("Category", "Unit")]
        public void PotentialPayerInfoConvertToJsonTest()
        {
            Assert.False(GetPotentialPayerInfo().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PotentialPayerInfoToStringTest()
        {
            Assert.False(GetPotentialPayerInfo().ToString().Length == 0);
        }
    }
}
