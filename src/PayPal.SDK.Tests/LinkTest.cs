
using PayPal.Api;
using System.Collections.Generic;
using Xunit;


namespace PayPal.Testing
{
    
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

        [Fact, Trait("Category", "Unit")]
        public void LinksObjectTest()
        {
            var link = GetLinks();
            Assert.Equal("http://paypal.com/", link.href);
            Assert.Equal("POST", link.method);
            Assert.Equal("authorize", link.rel);

            link = GetLinks(true);
            Assert.Equal("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C", link.href);
            Assert.Equal("REDIRECT", link.method);
            Assert.Equal("approval_url", link.rel);
        }

        [Fact, Trait("Category", "Unit")]
        public void LinksConvertToJsonTest()
        {
            Assert.False(GetLinks().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void LinksToStringTest()
        {
            Assert.False(GetLinks().ToString().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void LinksApprovalUrlTest()
        {
            var resource = new PayPalRelationalObject { links = GetLinksList() };
            var approvalUrl = resource.GetApprovalUrl();
            Assert.Equal("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C", approvalUrl);
        }

        [Fact, Trait("Category", "Unit")]
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
            Assert.True(string.IsNullOrEmpty(approvalUrl));
        }

        [Fact, Trait("Category", "Unit")]
        public void LinksApprovalUrlPayNowTest()
        {
            var resource = new PayPalRelationalObject { links = GetLinksList() };
            var approvalUrl = resource.GetApprovalUrl(true);
            Assert.Equal("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-0JP008296V451950C&useraction=commit", approvalUrl);
        }

        [Fact, Trait("Category", "Unit")]
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
            Assert.True(string.IsNullOrEmpty(approvalUrl));
        }

        [Fact, Trait("Category", "Unit")]
        public void LinksApprovalUrlTokenTest()
        {
            var resource = new PayPalRelationalObject { links = GetLinksList() };
            var token = resource.GetTokenFromApprovalUrl();
            Assert.Equal("EC-0JP008296V451950C", token);
        }

        [Fact, Trait("Category", "Unit")]
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
            Assert.True(string.IsNullOrEmpty(token));
        }
    }
}
