using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
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

        [TestMethod()]
        public void RedirectUrlsObjectTest()
        {
            var urls = GetRedirectUrls();
            Assert.AreEqual(urls.cancel_url, "http://ebay.com/");
            Assert.AreEqual(urls.return_url, "http://paypal.com/");
        }

        [TestMethod()]
        public void RedirectUrlsConvertToJsonTest()
        {
            Assert.IsFalse(GetRedirectUrls().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void RedirectUrlsToStringTest()
        {
            Assert.IsFalse(GetRedirectUrls().ToString().Length == 0);
        }
    }
}
