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
		
		/// <summary>
		/// SDK Version used in User-Agent HTTP header
		/// </summary>
		private static readonly string SdkVersion = typeof(PayPal.SDKVersionImpl).Assembly.GetName().Version.ToString(3);
		
		public string GetSDKId()
		{
			return SdkId;
		}
		
		public string GetSDKVersion()
		{
			return SdkVersion;
		}
	}

}


