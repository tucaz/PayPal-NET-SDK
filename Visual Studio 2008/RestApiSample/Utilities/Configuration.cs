using System.Collections.Generic;

namespace RestApiSample
{
    /// <summary>
    /// For a full list of configuration parameters refer at [https://github.com/paypal/adaptivepayments-sdk-java/wiki/SDK-Configuration-Parameters] 
    /// </summary>
    public static class Configuration
    {
        // Creates a configuration map containing credentials and other required configuration parameters
        public static Dictionary<string, string> GetAcctAndConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();
            configMap = GetConfig();

            // Account Credential
            configMap.Add("account1.apiUsername", "jb-us-seller_api1.paypal.com");
            configMap.Add("account1.apiPassword", "WX4WTU3S8MY44S7F");
            configMap.Add("account1.apiSignature", "AFcWxV21C7fd0v3bYYYRCpSSRl31A7yDhhsPUU2XhtMoZXsWHFxu-RWy");
            configMap.Add("account1.applicationId", "APP-80W284485P519543T");

            // Sample Certificate credential
            //configMap.Add("account2.UserName", "certuser_biz_api1.paypal.com");
            //configMap.Add("account2.Password", "D6JNKKULHN3G5B8A");
            //configMap.Add("account2.CertKey", "password");
            //configMap.Add("account2.CertPath", "resource/sdk-cert.p12");
            //configMap.Add("account2.AppId", "APP-80W284485P519543T");
            return configMap;
        }

        public static Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();

            // Endpoints are varied depending on whether sandbox OR live is chosen for mode
            configMap.Add("mode", "sandbox");

            // These values are defaulted in SDK. If you want to override default values, uncomment it and add your value
            configMap.Add("connectionTimeout", "360000");
            configMap.Add("requestRetries", "1");
            return configMap;
        }
    }
}
 