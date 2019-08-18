using PayPal.Api;
using System.Collections.Generic;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayPalResourceTest
    {
        [Fact, Trait("Category", "Unit")]
        public void PayPalResourceEndpointOverrideNoTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { {"endpoint", "http://test"} };
            Assert.Equal("http://test/", PayPalResource.GetEndpoint(config));
        }

        [Fact, Trait("Category", "Unit")]
        public void PayPalResourceEndpointOverrideWithTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { { "endpoint", "http://test/" } };
            Assert.Equal("http://test/", PayPalResource.GetEndpoint(config));
        }
        
        [Fact, Trait("Category", "Unit")]
        public void PayPalResourceEndpointDefaultTest()
        {
            var config = new Dictionary<string, string>();
            Assert.Equal(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }

        [Fact, Trait("Category", "Unit")]
        public void PayPalResourceEndpointSandboxModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "sandbox" } };
            Assert.Equal(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }

        [Fact, Trait("Category", "Unit")]
        public void PayPalResourceEndpointLiveModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "live" } };
            Assert.Equal(BaseConstants.RESTLiveEndpoint, PayPalResource.GetEndpoint(config));
        }

        [Fact, Trait("Category", "Unit")]
        public void PayPalResourceEndpointInvalidModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "test" } };
            Assert.Equal(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }
    }
}
