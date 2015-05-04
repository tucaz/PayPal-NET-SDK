using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Testing
{
    [TestClass]
    public class PreHandlerTest
    {
        [TestMethod, TestCategory("Unit")]
        public void PreHandlerEndpointOverrideNoTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { {"endpoint", "http://test"} };
            var handler = new RESTAPICallPreHandler(config);
            Assert.AreEqual("http://test/", handler.GetEndpoint());
        }

        [TestMethod, TestCategory("Unit")]
        public void PreHandlerEndpointOverrideWithTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { { "endpoint", "http://test/" } };
            var handler = new RESTAPICallPreHandler(config);
            Assert.AreEqual("http://test/", handler.GetEndpoint());
        }
        
        [TestMethod, TestCategory("Unit")]
        public void PreHandlerEndpointDefaultTest()
        {
            var config = new Dictionary<string, string>();
            var handler = new RESTAPICallPreHandler(config);
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, handler.GetEndpoint());
        }

        [TestMethod, TestCategory("Unit")]
        public void PreHandlerEndpointSandboxModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "sandbox" } };
            var handler = new RESTAPICallPreHandler(config);
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, handler.GetEndpoint());
        }

        [TestMethod, TestCategory("Unit")]
        public void PreHandlerEndpointLiveModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "live" } };
            var handler = new RESTAPICallPreHandler(config);
            Assert.AreEqual(BaseConstants.RESTLiveEndpoint, handler.GetEndpoint());
        }

        [TestMethod, TestCategory("Unit")]
        public void PreHandlerEndpointInvalidModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "test" } };
            var handler = new RESTAPICallPreHandler(config);
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, handler.GetEndpoint());
        }
    }
}
