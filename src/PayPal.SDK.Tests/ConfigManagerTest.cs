using System.Collections.Generic;
using PayPal.Api;
using PayPal;
using Xunit;


namespace PayPal.Testing
{
    
    public class ConfigManagerTest
    {
        [Fact, Trait("Category", "Unit")]
        public void LoadConfigDefaults()
        {
            var config = ConfigManager.GetConfigWithDefaults(null);
            Assert.NotNull(config);
            Assert.Equal("30000", config[BaseConstants.HttpConnectionTimeoutConfig]);
            Assert.Equal("3", config[BaseConstants.HttpConnectionRetryConfig]);
            Assert.Equal("sandbox", config[BaseConstants.ApplicationModeConfig]);
        }

        [Fact, Trait("Category", "Unit")]
        public void LoadConfigFromAppConfig()
        {
            var config = ConfigManager.Instance.GetProperties();
            Assert.NotNull(config);
            Assert.Equal("sandbox", config[BaseConstants.ApplicationModeConfig]);
            Assert.Equal("360000", config[BaseConstants.HttpConnectionTimeoutConfig]);
            Assert.Equal("3", config[BaseConstants.HttpConnectionRetryConfig]);
            Assert.NotNull(config[BaseConstants.ClientId]);
            Assert.NotNull(config[BaseConstants.ClientSecret]);
        }

        [Fact, Trait("Category", "Unit")]
        public void VerifyIsLiveModeEnabledWithDefaultConfig()
        {
            var config = ConfigManager.GetConfigWithDefaults(null);
            Assert.False(ConfigManager.IsLiveModeEnabled(config));
        }

        [Fact, Trait("Category", "Unit")]
        public void VerifyIsLiveModeEnabledWithSandboxModeSet()
        {
            var config = new Dictionary<string, string>
            {
                { BaseConstants.ApplicationModeConfig, BaseConstants.SandboxMode }
            };
            Assert.False(ConfigManager.IsLiveModeEnabled(config));
        }

        [Fact, Trait("Category", "Unit")]
        public void VerifyIsLiveModeEnabledWithLiveModeSet()
        {
            var config = new Dictionary<string, string>
            {
                { BaseConstants.ApplicationModeConfig, BaseConstants.LiveMode }
            };
            Assert.True(ConfigManager.IsLiveModeEnabled(config));
        }
    }
}
