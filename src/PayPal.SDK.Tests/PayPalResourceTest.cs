using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Testing
{
    [TestClass]
    public class PayPalResourceTest
    {
        [TestMethod, TestCategory("Unit")]
        public void PayPalResourceEndpointOverrideNoTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { {"endpoint", "http://test"} };
            Assert.AreEqual("http://test/", PayPalResource.GetEndpoint(config));
        }

        [TestMethod, TestCategory("Unit")]
        public void PayPalResourceEndpointOverrideWithTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { { "endpoint", "http://test/" } };
            Assert.AreEqual("http://test/", PayPalResource.GetEndpoint(config));
        }
        
        [TestMethod, TestCategory("Unit")]
        public void PayPalResourceEndpointDefaultTest()
        {
            var config = new Dictionary<string, string>();
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }

        [TestMethod, TestCategory("Unit")]
        public void PayPalResourceEndpointSandboxModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "sandbox" } };
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }

        [TestMethod, TestCategory("Unit")]
        public void PayPalResourceEndpointLiveModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "live" } };
            Assert.AreEqual(BaseConstants.RESTLiveEndpoint, PayPalResource.GetEndpoint(config));
        }

        [TestMethod, TestCategory("Unit")]
        public void PayPalResourceEndpointInvalidModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "test" } };
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }
    }
}
