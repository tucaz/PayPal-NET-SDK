using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for LinkTest and is intended
    ///to contain all LinkTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LinksTest
    {
        public Links CreateLinks()
        {
            Links link = new Links();
            link.href = "http://microsoft.com/";
            link.method = "GET";
            link.rel = "authorize";
            return link;
        }

        [TestMethod()]
        public void TestLinks()
        {
            Links link = CreateLinks();
            Assert.AreEqual(link.href, "http://microsoft.com/");
            Assert.AreEqual(link.method, "GET");
            Assert.AreEqual(link.rel, "authorize");
        }

        [TestMethod()]
        public void TestConvertToJson()
        {
            Links link = CreateLinks();
            Assert.IsFalse(link.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void TestToString()
        {
            Links link = CreateLinks();
            Assert.IsFalse(link.ToString().Length == 0);
        }
 
    }
}
