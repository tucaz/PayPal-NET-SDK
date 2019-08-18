using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class CreateProfileResponseTest
    {
        public static readonly string CreateProfileResponseJson = "{\"id\": \"XP-VKRN-ZPNE-AXGJ-YFZM\"}";

        public static CreateProfileResponse GetCreateProfileResponse()
        {
            return JsonFormatter.ConvertFromJson<CreateProfileResponse>(CreateProfileResponseJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void CreateProfileResponseObjectTest()
        {
            var response = GetCreateProfileResponse();
            Assert.Equal("XP-VKRN-ZPNE-AXGJ-YFZM", response.id);
        }

        [Fact, Trait("Category", "Unit")]
        public void CreateProfileResponseConvertToJsonTest()
        {
            Assert.False(GetCreateProfileResponse().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void CreateProfileResponseToStringTest()
        {
            Assert.False(GetCreateProfileResponse().ToString().Length == 0);
        }
    }
}
