
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class RedirectUrlsTest
    {
        public static RedirectUrls GetRedirectUrls()
        {
            RedirectUrls urls = new RedirectUrls();
            urls.cancel_url = "http://ebay.com/";
            urls.return_url = "http://paypal.com/";
            return urls;
        }

        [Fact, Trait("Category", "Unit")]
        public void RedirectUrlsObjectTest()
        {
            var urls = GetRedirectUrls();
            Assert.Equal(urls.cancel_url, "http://ebay.com/");
            Assert.Equal(urls.return_url, "http://paypal.com/");
        }

        [Fact, Trait("Category", "Unit")]
        public void RedirectUrlsConvertToJsonTest()
        {
            Assert.False(GetRedirectUrls().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void RedirectUrlsToStringTest()
        {
            Assert.False(GetRedirectUrls().ToString().Length == 0);
        }
    }
}
