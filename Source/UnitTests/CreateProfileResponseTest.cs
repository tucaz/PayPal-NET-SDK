using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass]
    public class CreateProfileResponseTest
    {
        public static readonly string CreateProfileResponseJson = "{\"id\": \"XP-VKRN-ZPNE-AXGJ-YFZM\"}";

        public static CreateProfileResponse GetCreateProfileResponse()
        {
            return JsonFormatter.ConvertFromJson<CreateProfileResponse>(CreateProfileResponseJson);
        }

        [TestMethod()]
        public void CreateProfileResponseObjectTest()
        {
            var response = GetCreateProfileResponse();
            Assert.AreEqual("XP-VKRN-ZPNE-AXGJ-YFZM", response.id);
        }

        [TestMethod()]
        public void CreateProfileResponseConvertToJsonTest()
        {
            Assert.IsFalse(GetCreateProfileResponse().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void CreateProfileResponseToStringTest()
        {
            Assert.IsFalse(GetCreateProfileResponse().ToString().Length == 0);
        }
    }
}
