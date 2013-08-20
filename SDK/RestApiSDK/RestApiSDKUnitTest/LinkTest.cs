using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class LinksTest
    {
        private Links CreateLinks()
        {
            Links link = new Links();
            link.href = "http://paypal.com/";
            link.method = "GET";
            link.rel = "authorize";
            return link;
        }

        [TestMethod()]
        public void LinksObjectTest()
        {
            Links link = CreateLinks();
            Assert.AreEqual(link.href, "http://paypal.com/");
            Assert.AreEqual(link.method, "GET");
            Assert.AreEqual(link.rel, "authorize");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Links link = CreateLinks();
            Assert.IsFalse(link.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Links link = CreateLinks();
            Assert.IsFalse(link.ToString().Length == 0);
        } 
    }
}
