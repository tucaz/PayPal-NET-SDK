using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using PayPal;
using PayPal.Manager;

namespace RestApiSDKUnitTest
{ 
    /// <summary>
    ///This is a test class for HttpConnectionTest and is intended
    ///to contain all HttpConnectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HttpConnectionTest
    {
        private string payLoad
        {
            get
            {
                string loadPay = "{\"intent\":\"sale\",\"payer\":{\"payment_method\":\"credit_card\",\"funding_instruments\":[{\"credit_card\":{\"type\":\"visa\",\"number\":\"4825854086744369\",\"expire_month\":\"01\",\"expire_year\":\"2015\",\"cvv2\":\"962\",\"first_name\":\"John\",\"last_name\":\"Doe\",\"billing_address\":{\"line1\":\"3909 Witmer Road\",\"line2\":\"Niagara Falls\",\"city\":\"New York\",\"state\":\"NY\",\"postal_code\":\"14305\",\"country_code\":\"US\",\"type\":\"Business\",\"phone\":\"716-298-1822\"}}}]},\"transactions\":[{\"amount\":{\"total\":\"100\",\"currency\":\"USD\",\"details\":{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"5\"}},\"description\":\"This is the payment transaction description.\"}]}";
                return loadPay;
            }
        }
        private string ClientID
        {
            get
            {
                string clntID = ConfigManager.Instance.GetProperty("ClientID");
                return clntID;
            }
        }

        private string ClientSecret
        {
            get
            {
                string clntSecret = ConfigManager.Instance.GetProperty("ClientSecret");
                return clntSecret;
            }
        }

        private string AccessToken
        {
            get
            {
                string tokenAccess = new OAuthTokenCredential(ClientID, ClientSecret).GetAccessToken();
                return tokenAccess;
            }
        }

        private HttpWebRequest GetHttpWebRequest()
        {
            Dictionary<string, string> headers;
            Uri uniformResourceIdentifier = null;
            Uri baseUri = null;

            string resource = "v1/payments/payment";
            baseUri = new Uri(ConfigManager.Instance.GetProperty("endpoint"));
            bool success = Uri.TryCreate(baseUri, resource, out uniformResourceIdentifier);

            RESTConfiguration restConfiguration = new RESTConfiguration();

            restConfiguration.authorizationToken = AccessToken;
            headers = restConfiguration.GetHeaders();

            ConnectionManager connMngr = ConnectionManager.Instance;
            connMngr.GetConnection(uniformResourceIdentifier.ToString());
            HttpWebRequest httpRequest = connMngr.GetConnection(uniformResourceIdentifier.ToString());
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            httpRequest.ContentLength = payLoad.Length;

            foreach (KeyValuePair<string, string> header in headers)
            {
                if (header.Key.Trim().Equals("User-Agent"))
                {
                    httpRequest.UserAgent = header.Value;
                }
                else
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            return httpRequest;
        }

        [TestMethod()]
        public void HttpConnectionConstructorTest()
        {
            HttpConnection target = new HttpConnection();
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            HttpConnection target = new HttpConnection();
            HttpWebRequest httpRequest = GetHttpWebRequest();
            string actual = target.Execute(payLoad, httpRequest);
            Assert.IsNotNull(actual);
        }       
    }
}
