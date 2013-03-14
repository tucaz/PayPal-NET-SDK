using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal
{
    public class RESTConfiguration
    {
        public string authorizationToken
        {
            get;
            set;
        }

        private string requestIdentity;
        public string requestId
        {
            private get
            {
                return requestIdentity;
            }
            set
            {
                requestIdentity = value;
            }
        }

        public RESTConfiguration() {}

        public Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", authorizationToken);
            headers.Add("User-Agent", FormUserAgentHeader());
            headers.Add("PayPal-Request-Id", requestId);
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
                osHeader += "bit=" + 64 + ";";
            }
            else if (JCS.OSVersionInfo.OSBits.Equals(JCS.OSVersionInfo.SoftwareArchitecture.Bit32))
            {
                osHeader += "bit=" + 32 + ";";
            }
            else
            {
                osHeader += "bit=" + "Unknown" + ";";
            }

            osHeader += "os=" + JCS.OSVersionInfo.Name + " " + JCS.OSVersionInfo.Version + ";";
            return osHeader;
        }

        private string GetDotNetVersionHeader()
        {
            string DotNetVersionHeader = "lang=" + "DOTNET;" + "v=" + Environment.Version.ToString().Trim();
            return DotNetVersionHeader;
        }          
    }
}
