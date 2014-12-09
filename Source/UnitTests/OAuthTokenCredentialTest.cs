using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.UnitTest
{
    [TestClass]
    public class OAuthTokenCredentialTest
    {
        [TestMethod]
        public void OAuthTokenCredentialCtorConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.AreEqual("xxx", oauthTokenCredential.ClientId);
            Assert.AreEqual("yyy", oauthTokenCredential.ClientSecret);
        }

        [TestMethod]
        public void OAuthTokenCredentialCtorClientInfoTest()
        {
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb");
            Assert.AreEqual("aaa", oauthTokenCredential.ClientId);
            Assert.AreEqual("bbb", oauthTokenCredential.ClientSecret);
        }

        [TestMethod]
        public void OAuthTokenCredentialCtorClientInfoConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb", config);
            Assert.AreEqual("aaa", oauthTokenCredential.ClientId);
            Assert.AreEqual("bbb", oauthTokenCredential.ClientSecret);
        }
    }
}
