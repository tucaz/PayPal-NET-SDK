using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;
using System;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for PayPalResourceTest and is intended
    ///to contain all PayPalResourceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PayPalResourceTest
    {
        private string resource = "v1/payments/payment";

        private string Payload
        {
            get
            {
                string load = "{\"intent\":\"sale\",\"payer\":{\"payment_method\":\"credit_card\",\"funding_instruments\":[{\"credit_card\":{\"type\":\"visa\",\"number\":\"4825854086744369\",\"expire_month\":\"01\",\"expire_year\":\"2015\",\"cvv2\":\"962\",\"first_name\":\"John\",\"last_name\":\"Doe\",\"billing_address\":{\"line1\":\"3909 Witmer Road\",\"line2\":\"Niagara Falls\",\"city\":\"New York\",\"state\":\"NY\",\"postal_code\":\"14305\",\"country_code\":\"US\",\"type\":\"Business\",\"phone\":\"716-298-1822\"}}}]},\"transactions\":[{\"amount\":{\"total\":\"100\",\"currency\":\"USD\",\"details\":{\"subtotal\":\"75\",\"tax\":\"15\",\"shipping\":\"10\",\"fee\":\"5\"}},\"description\":\"This is the payment transaction description.\"}]}";
                return load;
            }
        }

        private string ClientId
        {
            get
            {
                string Id = ConfigManager.Instance.GetProperties()["ClientID"];
                return Id;
            }
        }

        private string ClientSecret
        {
            get
            {
                string secret = ConfigManager.Instance.GetProperties()["ClientSecret"];
                return secret;
            }
        }

        private string AccessToken
        {
            get
            {
                string token = new OAuthTokenCredential(ClientId, ClientSecret).GetAccessToken();
                return token;
            }
        }
                
        /// <summary>
        ///A test for ConfigureAndExecute
        ///</summary>
        [TestMethod]
        public void ConfigureAndExecuteTestHelper<T>()
        {
            string tokenAccess = AccessToken;
            HttpMethod httpMethod = HttpMethod.POST;           
            Payment actual = PayPalResource.ConfigureAndExecute<Payment>(tokenAccess, httpMethod, resource, Payload);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ConfigureAndExecute
        ///</summary>
        [TestMethod]
        public void ConfigureAndExecuteTest1Helper<T>()
        {
            APIContext apiContext = new APIContext(AccessToken);
            HttpMethod httpMethod = HttpMethod.POST;
            Payment actual = PayPalResource.ConfigureAndExecute<Payment>(apiContext, httpMethod, resource, Payload);
            Assert.IsNotNull(actual);
        }        
    }
}
