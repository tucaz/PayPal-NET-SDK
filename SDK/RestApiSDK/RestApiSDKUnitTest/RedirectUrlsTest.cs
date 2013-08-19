using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for RedirectUrlsTest and is intended
    ///to contain all RedirectUrlsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RedirectUrlsTest
    {
        public RedirectUrls CreateRedirectUrls()
        {
            RedirectUrls urls = new RedirectUrls();
            urls.cancel_url = "http://microsoft.com/";
            urls.return_url = "http://live.com/";
            return urls;
        }

        [TestMethod()]
        public void TestRedirectUrls()
        {
            RedirectUrls urls = CreateRedirectUrls();
            Assert.AreEqual(urls.cancel_url, "http://microsoft.com/");
            Assert.AreEqual(urls.return_url, "http://live.com/");
        }

        [TestMethod()]
        public void TestConvertToJson()
        {
            RedirectUrls urls = CreateRedirectUrls();
            Assert.IsFalse(urls.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TestToString()
        {
            RedirectUrls urls = CreateRedirectUrls();
            Assert.IsFalse(urls.ToString().Length == 0);
        }
    }
}
