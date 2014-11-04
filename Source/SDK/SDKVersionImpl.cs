using PayPal;
using System.Reflection;

namespace PayPal
{
    public class SDKVersionImpl : SDKVersion
    {
        /// <summary>
        /// SDK ID used in User-Agent HTTP header
        /// </summary>
        private const string SdkId = "rest-sdk-dotnet";

        public string GetSDKId()
        {
            return SdkId;
        }

        public string GetSDKVersion()
        {
            return PayPal.Util.SDKUtil.GetAssemblyVersionForType(typeof(PayPal.SDKVersionImpl));
        }
    }
}
