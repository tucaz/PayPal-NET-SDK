using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for ReauthorizationTest
    /// </summary>
    [TestClass]
    public class ReauthorizationTest
    {  
        private string ClientID
        {
            get
            {
                string clntID = PayPal.Manager.ConfigManager.Instance.GetProperties()["ClientID"];
                return clntID;
            }
        }

        private string ClientSecret
        {
            get
            {
                string clntSecret = ConfigManager.Instance.GetProperties()["ClientSecret"];
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

        [TestMethod]
        [ExpectedException(typeof(PayPal.Exception.PayPalException), "Exception in HttpConnection Execute: Invalid HTTP response The remote server returned an error: (400) Bad Request.")]
        public void Reauthorization()
        {
            Authorization authorization = Authorization.Get(AccessToken, "7GH53639GA425732B");
            Amount reauthorizeAmount = new Amount();
            reauthorizeAmount.currency = "USD";
            reauthorizeAmount.total = "1";
            authorization.amount = reauthorizeAmount;
            Authorization reauthorization = authorization.Reauthorize(AccessToken);          
        }
    }
}
