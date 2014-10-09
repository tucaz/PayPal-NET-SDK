using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    [TestClass]
    public class PresentationTest
    {
        public static readonly string PresentationJson = "{\"brand_name\": \"Test brand name\",\"logo_image\": \"http://www.paypal.com\",\"locale_code\": \"US\"}";

        public static Presentation GetPresentation()
        {
            return JsonFormatter.ConvertFromJson<Presentation>(PresentationJson);
        }

        [TestMethod()]
        public void PresentationObjectTest()
        {
            var presentation = GetPresentation();
            Assert.AreEqual("Test brand name", presentation.brand_name);
            Assert.AreEqual("http://www.paypal.com", presentation.logo_image);
            Assert.AreEqual("US", presentation.locale_code);
        }

        [TestMethod()]
        public void PresentationConvertToJsonTest()
        {
            Assert.IsFalse(GetPresentation().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PresentationToStringTest()
        {
            Assert.IsFalse(GetPresentation().ToString().Length == 0);
        }
    }
}
