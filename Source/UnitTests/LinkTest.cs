using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class LinksTest
    {
        public static List<Links> GetLinksList()
        {
            var links = new List<Links>();
            links.Add(GetLinks());
            return links;
        }

        public static Links GetLinks()
        {
            Links link = new Links();
            link.href = "http://paypal.com/";
            link.method = "POST";
            link.rel = "authorize";
            return link;
        }

        [TestMethod()]
        public void LinksObjectTest()
        {
            var link = GetLinks();
            Assert.AreEqual(link.href, "http://paypal.com/");
            Assert.AreEqual(link.method, "POST");
            Assert.AreEqual(link.rel, "authorize");
        }

        [TestMethod()]
        public void LinksConvertToJsonTest()
        {
            Assert.IsFalse(GetLinks().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void LinksToStringTest()
        {
            Assert.IsFalse(GetLinks().ToString().Length == 0);
        } 
    }
}
