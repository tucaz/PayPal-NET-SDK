using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class APIContextTest
    {
        [Fact, Trait("Category", "Unit")]
        public void APIContextValidConstructorTest()
        {
            var apiContext = new APIContext();
            Assert.False(string.IsNullOrEmpty(apiContext.RequestId));
            Assert.False(apiContext.MaskRequestId);
            Assert.True(string.IsNullOrEmpty(apiContext.AccessToken));
            Assert.Null(apiContext.Config);
            Assert.Null(apiContext.HTTPHeaders);
            Assert.NotNull(apiContext.SdkVersion);
        }

        [Fact, Trait("Category", "Unit")]
        public void APIContextValidConstructorWithAccessTokenTest()
        {
            var apiContext = new APIContext("abc");
            Assert.False(string.IsNullOrEmpty(apiContext.RequestId));
            Assert.False(apiContext.MaskRequestId);
            Assert.Equal("abc", apiContext.AccessToken);
            Assert.Null(apiContext.Config);
            Assert.Null(apiContext.HTTPHeaders);
            Assert.NotNull(apiContext.SdkVersion);
        }

        [Fact, Trait("Category", "Unit")]
        public void APIContextValidConstructorWithAccessTokenAndRequestIdTest()
        {
            var apiContext = new APIContext("abc", "xyz");
            Assert.Equal("xyz", apiContext.RequestId);
            Assert.False(apiContext.MaskRequestId);
            Assert.Equal("abc", apiContext.AccessToken);
            Assert.Null(apiContext.Config);
            Assert.Null(apiContext.HTTPHeaders);
            Assert.NotNull(apiContext.SdkVersion);
        }

        [Fact, Trait("Category", "Unit")]
        public void APIContextInvalidAccessTokenConstructorTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => new APIContext(""));
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => new APIContext("", "xyz"));
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => new APIContext(null));
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => new APIContext(null, "xyz"));
        }

        [Fact, Trait("Category", "Unit")]
        public void APIContextInvalidRequestIdConstructorTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => new APIContext("abc", ""));
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => new APIContext("abc", null));
        }

        [Fact, Trait("Category", "Unit")]
        public void APIContextResetRequestIdTest()
        {
            var apiContext = new APIContext();
            var originalRequestId = apiContext.RequestId;
            apiContext.ResetRequestId();
            Assert.NotEqual(originalRequestId, apiContext.RequestId);
        }
    }
}
