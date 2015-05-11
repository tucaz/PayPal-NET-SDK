using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Testing
{
    [TestClass()]
    public class LinksTest
    {
        public static readonly string LinksJson =
            "{\"href\":\"http://paypal.com/\"," +
            "\"method\":\"POST\"," +
            "\"rel\":\"authorize\"}";

        public static readonly string LinksApprovalUrlJson =
            "{\"href\":\"https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C\"," +
            "\"method\":\"REDIRECT\"," +
            "\"rel\":\"approval_url\"}";

        public static List<Links> GetLinksList()
        {
            var links = new List<Links>();
            links.Add(GetLinks(false));
            links.Add(GetLinks(true));
            return links;
        }

        public static Links GetLinks(bool useApprovalUrl = false)
        {
            if(useApprovalUrl)
            {
                return JsonFormatter.ConvertFromJson<Links>(LinksApprovalUrlJson);
            }
            return JsonFormatter.ConvertFromJson<Links>(LinksJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksObjectTest()
        {
            var link = GetLinks();
            Assert.AreEqual("http://paypal.com/", link.href);
            Assert.AreEqual("POST", link.method);
            Assert.AreEqual("authorize", link.rel);

            link = GetLinks(true);
            Assert.AreEqual("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C", link.href);
            Assert.AreEqual("REDIRECT", link.method);
            Assert.AreEqual("approval_url", link.rel);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksConvertToJsonTest()
        {
            Assert.IsFalse(GetLinks().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksToStringTest()
        {
            Assert.IsFalse(GetLinks().ToString().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksApprovalUrlTest()
        {
            var resource = new PayPalRelationalObject { links = GetLinksList() };
            var approvalUrl = resource.GetApprovalUrl();
            Assert.AreEqual("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C", approvalUrl);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksNoApprovalUrlTest()
        {
            var resource = new PayPalRelationalObject
            {
                links = new List<Links>
                {
                    GetLinks(false)
                }
            };
            var approvalUrl = resource.GetApprovalUrl();
            Assert.IsTrue(string.IsNullOrEmpty(approvalUrl));
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksApprovalUrlPayNowTest()
        {
            var resource = new PayPalRelationalObject { links = GetLinksList() };
            var approvalUrl = resource.GetApprovalUrl(true);
            Assert.AreEqual("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C&useraction=commit", approvalUrl);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksNoApprovalUrlPayNowTest()
        {
            var resource = new PayPalRelationalObject
            {
                links = new List<Links>
                {
                    GetLinks(false)
                }
            };
            var approvalUrl = resource.GetApprovalUrl(true);
            Assert.IsTrue(string.IsNullOrEmpty(approvalUrl));
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksApprovalUrlTokenTest()
        {
            var resource = new PayPalRelationalObject { links = GetLinksList() };
            var token = resource.GetTokenFromApprovalUrl();
            Assert.AreEqual("EC-0JP008296V451950C", token);
        }

        [TestMethod, TestCategory("Unit")]
        public void LinksNoApprovalUrlEmptyTokenTest()
        {
            var resource = new PayPalRelationalObject
            {
                links = new List<Links>
                {
                    GetLinks(false)
                }
            };
            var token = resource.GetTokenFromApprovalUrl();
            Assert.IsTrue(string.IsNullOrEmpty(token));
        }
    }
}
