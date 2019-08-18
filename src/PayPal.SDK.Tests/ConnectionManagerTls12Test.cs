
using System;
using PayPal.Api;
using System.Net;
using Xunit;


namespace PayPal.Testing
{
    
    public class ConnectionManagerTls12Test : IDisposable
    {

        
        private SecurityProtocolType DefaultSecurityProtocol { get; set; }

        public ConnectionManagerTls12Test()
        {
            DefaultSecurityProtocol = ServicePointManager.SecurityProtocol;
        }
        
        void IDisposable.Dispose()
        {
            ServicePointManager.SecurityProtocol = DefaultSecurityProtocol;
        }

        private static SecurityProtocolType Ssl3 => SecurityProtocolType.Ssl3;

        private static SecurityProtocolType Tls => SecurityProtocolType.Tls;

#if NET_4_5 || NET_4_5_1
        private static SecurityProtocolType Tls11 => SecurityProtocolType.Tls11
        private static SecurityProtocolType Tls12 => SecurityProtocolType.Tls12
#else
        private static SecurityProtocolType Tls11 => (SecurityProtocolType)0x300;
        private static SecurityProtocolType Tls12 => (SecurityProtocolType)0xC00;
#endif

        [Fact, Trait("Category", "Unit")]
        public void Tls12SupportShouldBeAddedWithoutAffectingExistingProtocols()
        {
            Assert.Throws<NotSupportedException>(() => { ServicePointManager.SecurityProtocol = Ssl3; });
            
            ServicePointManager.SecurityProtocol = Tls | Tls11 | Tls12;

            var connectionManager = ConnectionManager.Instance;

            SecurityProtocolType actual = ServicePointManager.SecurityProtocol;
            Assert.True(actual.HasFlag(Tls), "TLSv1.0 support got removed.");
            Assert.True(actual.HasFlag(Tls11), "TLSv1.1 support got removed.");
            Assert.True(actual.HasFlag(Tls12), "TLSv1.2 support not added.");
        }
        
    }
}
