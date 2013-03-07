using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using PayPal;
using PayPal.Manager;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for RESTConfigurationTest and is intended
    ///to contain all RESTConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RESTConfigurationTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private string accessToken
        {
            get
            {
                string clientID = ConfigManager.Instance.GetProperty("ClientID");
                string clientName = ConfigManager.Instance.GetProperty("ClientName");
                return new OAuthTokenCredential(clientID, clientName).GetAccessToken();
            }
        }

        private Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", accessToken);
            headers.Add("User-Agent", FormUserAgentHeader());
            return headers;
        }
       

        private string FormUserAgentHeader()
        {
            string header = null;
            StringBuilder stringBuilder = new StringBuilder("PayPalSDK/"
                    + PayPalResource.SdkID + " " + PayPalResource.SdkVersion
                    + " ");
            string dotNETVersion = GetDotNetVersionHeader();
            stringBuilder.Append(";").Append(dotNETVersion);
            string osVersion = GetOSHeader();
            if (osVersion.Length > 0)
            {
                stringBuilder.Append(";").Append(osVersion);
            }
            header = stringBuilder.ToString();
            return header;
        }

        private string GetOSHeader()
        {
            string osHeader = string.Empty;
            if (JCS.OSVersionInfo.OSBits.Equals(JCS.OSVersionInfo.SoftwareArchitecture.Bit64))
            {
                osHeader += "b=" + 64 + ";";
            }
            else if (JCS.OSVersionInfo.OSBits.Equals(JCS.OSVersionInfo.SoftwareArchitecture.Bit32))
            {
                osHeader += "b=" + 32 + ";";
            }
            else
            {
                osHeader += "b=" + "Unknown" + ";";
            }

            osHeader += "OS=" + JCS.OSVersionInfo.Name + " " + JCS.OSVersionInfo.Version + ";";
            return osHeader;
        }

        private string GetDotNetVersionHeader()
        {
            string DotNetVersionHeader = "lang=" + ".NET;" + "V=" + Environment.Version.ToString().Trim();
            return DotNetVersionHeader;
        }

        /// <summary>
        ///A test for RESTConfiguration Constructor
        ///</summary>
        [TestMethod()]
        public void RESTConfigurationConstructorTest()
        {
            RESTConfiguration target = new RESTConfiguration();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for FormUserAgentHeader
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RestApiSDK.dll")]
        public void FormUserAgentHeaderTest()
        {
            RESTConfiguration_Accessor target = new RESTConfiguration_Accessor(); // TODO: Initialize to an appropriate value
            string expected = FormUserAgentHeader();
            string actual = target.FormUserAgentHeader();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDotNetVersionHeader
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RestApiSDK.dll")]
        public void GetDotNetVersionHeaderTest()
        {
            RESTConfiguration_Accessor target = new RESTConfiguration_Accessor();
            string expected = "lang=.NET;V=2.0.50727.5466";
            string actual;
            actual = target.GetDotNetVersionHeader();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetOSHeader
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RestApiSDK.dll")]
        public void GetOSHeaderTest()
        {
            RESTConfiguration_Accessor target = new RESTConfiguration_Accessor();
            string expected = GetOSHeader();
            string actual = target.GetOSHeader();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for authorizationToken
        ///</summary>
        [TestMethod()]
        public void authorizationTokenTest()
        {
            RESTConfiguration target = new RESTConfiguration();
            target.authorizationToken = accessToken;
            string expected = target.authorizationToken;
            Assert.IsTrue(expected.ToLower().Contains("bearer"));
        }
    }
}
