using Xunit;

namespace PayPal.SDK.Tests
{
    public class CertificateManagerTest
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void GetTrustedCertificateFromFile()
        {
            var certificate = CertificateManager.Instance.GetTrustedCertificateFromFile(null);
            Assert.NotNull(certificate);
        }
    }
}