using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PresentationTest
    {
        public static readonly string PresentationJson = "{\"brand_name\": \"Test brand name\",\"logo_image\": \"http://www.paypal.com\",\"locale_code\": \"US\",\"return_url_label\":\"return\",\"note_to_seller_label\":\"thanks!\"}";

        public static Presentation GetPresentation()
        {
            return JsonFormatter.ConvertFromJson<Presentation>(PresentationJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PresentationObjectTest()
        {
            var presentation = GetPresentation();
            Assert.Equal("Test brand name", presentation.brand_name);
            Assert.Equal("http://www.paypal.com", presentation.logo_image);
            Assert.Equal("US", presentation.locale_code);
            Assert.Equal("return", presentation.return_url_label);
            Assert.Equal("thanks!", presentation.note_to_seller_label);
        }

        [Fact, Trait("Category", "Unit")]
        public void PresentationConvertToJsonTest()
        {
            Assert.False(GetPresentation().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PresentationToStringTest()
        {
            Assert.False(GetPresentation().ToString().Length == 0);
        }
    }
}
