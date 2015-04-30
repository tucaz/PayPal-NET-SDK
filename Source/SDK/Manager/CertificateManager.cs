using PayPal.Log;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace PayPal
{
    /// <summary>
    /// Manager class for storing X509 certificates.
    /// </summary>
    public sealed class CertificateManager
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static Logger logger = Logger.GetLogger(typeof(CertificateManager));

        /// <summary>
        /// Cache of X509 certificates.
        /// </summary>
        private static ConcurrentDictionary<string, X509Certificate2> certificates;

        /// <summary>
        /// Private constructor prevent direct instantiation
        /// </summary>
        private CertificateManager() 
        {
            certificates = new ConcurrentDictionary<string, X509Certificate2>();
        }

        /// <summary>
        /// Private static member for storing the single instance.
        /// </summary>
        private static volatile CertificateManager instance;

        /// <summary>
        /// Private static member for locking the singleton object while it's being instantiated.
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Gets the singleton instance for this class.
        /// </summary>
        public static CertificateManager Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CertificateManager();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the certificate corresponding to the specified URL from the cache of certificates.  If the cache doesn't contain the certificate, it is downloaded and verified.
        /// </summary>
        /// <param name="certUrl">The URL pointing to the certificate.</param>
        /// <returns>An <see cref="System.Security.Cryptography.X509Certificates.X509Certificate2"/> object containing the details of the certificate.</returns>
        /// <exception cref="PayPal.PayPalException">Thrown if the downloaded certificate cannot be verified.</exception>
        public X509Certificate2 GetCertificate(string certUrl)
        {
            // If we haven't already cached this URL, then download, verify, and cache it.
            if(!certificates.ContainsKey(certUrl))
            {
                // Download the certificate.
                byte[] cert;
                using (var webClient = new WebClient())
                {
                    cert = webClient.DownloadData(certUrl);
                }

                // Verify the downloaded certificate.
                var certificate = new X509Certificate2(cert);
                if (certificate.Verify())
                {
                    certificates[certUrl] = certificate;
                }
                else
                {
                    throw new PayPalException("Unable to verify the following certificate: " + certUrl);
                }
            }

            return certificates[certUrl];
        }
    }
}
