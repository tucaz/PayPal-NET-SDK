using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class RedirectUrlsTest
    {
        public static RedirectUrls GetRedirectUrls()
        {
            RedirectUrls urls = new RedirectUrls();
            urls.cancel_url = "http://ebay.com/";
            urls.return_url = "http://paypal.com/";
            return urls;
        }

        [TestMethod, TestCategory("Unit")]
        public void RedirectUrlsObjectTest()
        {
            var urls = GetRedirectUrls();
            Assert.AreEqual(urls.cancel_url, "http://ebay.com/");
            Assert.AreEqual(urls.return_url, "http://paypal.com/");
        }

        [TestMethod, TestCategory("Unit")]
        public void RedirectUrlsConvertToJsonTest()
        {
            Assert.IsFalse(GetRedirectUrls().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void RedirectUrlsToStringTest()
        {
            Assert.IsFalse(GetRedirectUrls().ToString().Length == 0);
        }
    }
}
