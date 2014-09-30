using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class LinksTest
    {
        [TestMethod()]
        public void TestLinks()
        {
            var link = UnitTestUtil.GetLinks();
            Assert.AreEqual(link.href, "http://paypal.com/");
            Assert.AreEqual(link.method, "POST");
            Assert.AreEqual(link.rel, "authorize");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var link = UnitTestUtil.GetLinks();
            Assert.IsFalse(link.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var link = UnitTestUtil.GetLinks();
            Assert.IsFalse(link.ToString().Length == 0);
        } 
    }
}
