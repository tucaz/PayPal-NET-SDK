using System.Collections.Generic;

namespace RestApiSample
{ 
    public static class Configuration
    {
        // Creates a configuration map containing Client ID and Secret
        public static Dictionary<string, string> GetClientDetailsAndConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();
            configMap = GetConfig();
            configMap.Add("Client ID", "EBWKjlELKMYqRNQ6sYvFo64FtaRLRR5BdHEESmha49TM");
            configMap.Add("Secret", "EO422dn3gQLgDbuwqTjzrFgFtaRLRR5BdHEESmha49TM");            
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
 