using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.Api
{
    public class SDKVersion
    {
        /// <summary>
        /// SDK ID used in User-Agent HTTP header
        /// </summary>
        /// <returns>SDK ID</returns>
        public static string GetSDKId() { return "PayPalSDK"; }

        /// <summary>
        /// SDK Version used in User-Agent HTTP header
        /// </summary>
        /// <returns>SDK Version</returns>
        public static string GetSDKVersion() { return BaseConstants.SdkVersion; }
    }
}
