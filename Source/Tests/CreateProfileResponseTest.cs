using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class CreateProfileResponseTest
    {
        public static readonly string CreateProfileResponseJson = "{\"id\": \"XP-VKRN-ZPNE-AXGJ-YFZM\"}";

        public static CreateProfileResponse GetCreateProfileResponse()
        {
            return JsonFormatter.ConvertFromJson<CreateProfileResponse>(CreateProfileResponseJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateProfileResponseObjectTest()
        {
            var response = GetCreateProfileResponse();
            Assert.AreEqual("XP-VKRN-ZPNE-AXGJ-YFZM", response.id);
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateProfileResponseConvertToJsonTest()
        {
            Assert.IsFalse(GetCreateProfileResponse().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateProfileResponseToStringTest()
        {
            Assert.IsFalse(GetCreateProfileResponse().ToString().Length == 0);
        }
    }
}
