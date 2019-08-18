using System;
using PayPal.Api;
using System.Collections.Generic;
using Xunit;


namespace PayPal.Testing
{
    
    public class OAuthTokenCredentialTest : BaseTest
    {
        #region Unit Tests
        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialCtorConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.Equal("xxx", oauthTokenCredential.ClientId);
            Assert.Equal("yyy", oauthTokenCredential.ClientSecret);
        }

        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialCtorClientInfoTest()
        {
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb");
            Assert.Equal("aaa", oauthTokenCredential.ClientId);
            Assert.Equal("bbb", oauthTokenCredential.ClientSecret);
        }

        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialCtorClientInfoConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb", config);
            Assert.Equal("aaa", oauthTokenCredential.ClientId);
            Assert.Equal("bbb", oauthTokenCredential.ClientSecret);
        }

        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialCtorEmptyConfigTest()
        {
            var config = new Dictionary<string, string>();
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.True(string.IsNullOrEmpty(oauthTokenCredential.ClientId));
            Assert.True(string.IsNullOrEmpty(oauthTokenCredential.ClientSecret));
        }

        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialCtorNullValuesTest()
        {
            // If null values are passed in, OAuthTokenCredential uses the values specified in the config.
            var oauthTokenCredential = new OAuthTokenCredential(null, null, null);
            Assert.True(!string.IsNullOrEmpty(oauthTokenCredential.ClientId));
            Assert.True(!string.IsNullOrEmpty(oauthTokenCredential.ClientSecret));
        }

        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialMissingClientIdTest()
        {
            var config = ConfigManager.Instance.GetProperties();
            config[BaseConstants.ClientId] = "";
            var oauthTokenCredential = new OAuthTokenCredential("", "abc", config);
            TestingUtil.AssertThrownException<MissingCredentialException>(() => oauthTokenCredential.GetAccessToken());
        }

        [Fact, Trait("Category", "Unit")]
        public void OAuthTokenCredentialMissingClientSecretTest()
        {
            var config = ConfigManager.Instance.GetProperties();
            config[BaseConstants.ClientSecret] = "";
            var oauthTokenCredential = new OAuthTokenCredential(config);
            TestingUtil.AssertThrownException<MissingCredentialException>(() => oauthTokenCredential.GetAccessToken());
        }
        #endregion

        #region Functional Tests
        [Fact, Trait("Category", "Functional")]
        public void OAuthTokenCredentialGetAccessTokenTest()
        {
            try
            {
                var oauthTokenCredential = new OAuthTokenCredential();
                var accessToken = oauthTokenCredential.GetAccessToken();
                this.RecordConnectionDetails();

                Assert.True(accessToken.StartsWith("Bearer "));
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void OAuthTokenCredentialInvalidClientIdTest()
        {
            try
            {
                var config = ConfigManager.Instance.GetProperties();
                config[BaseConstants.ClientId] = "abc";
                var oauthTokenCredential = new OAuthTokenCredential(config);
                TestingUtil.AssertThrownException<IdentityException>(() => oauthTokenCredential.GetAccessToken());
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void OAuthTokenCredentialInvalidClientSecretTest()
        {
            try
            {
                var config = ConfigManager.Instance.GetProperties();
                config[BaseConstants.ClientSecret] = "abc";
                var oauthTokenCredential = new OAuthTokenCredential(config);
                TestingUtil.AssertThrownException<IdentityException>(() => oauthTokenCredential.GetAccessToken());
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
        #endregion
    }
}
