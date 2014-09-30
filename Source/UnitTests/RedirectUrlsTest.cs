using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class RedirectUrlsTest
    {
        [TestMethod()]
        public void TestRedirectUrls()
        {
            var urls = UnitTestUtil.GetRedirectUrls();
            Assert.AreEqual(urls.cancel_url, "http://ebay.com/");
            Assert.AreEqual(urls.return_url, "http://paypal.com/");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var urls = UnitTestUtil.GetRedirectUrls();
            Assert.IsFalse(urls.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var urls = UnitTestUtil.GetRedirectUrls();
            Assert.IsFalse(urls.ToString().Length == 0);
        }
    }
}
