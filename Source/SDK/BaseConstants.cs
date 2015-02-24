using System.Text;
using PayPal.Util;

namespace PayPal.Api
{
    public static class BaseConstants
    {
        // Request Method in HTTP Connection
        public const string RequestMethod = "POST";

        // Log file
        public const string PayPalLogFile = "PAYPALLOGFILE";

        //TODO: To be renamed as 'EncodingFormat' as per .NET Naming Conventions
        // Encoding Format
        public static readonly Encoding ENCODING_FORMAT = Encoding.UTF8;
        
        // Account Prefix
        public const string AccountPrefix = "acct";

        // Sandbox Default Email Address
        public const string PayPalSandboxEmailAddressDefault = "pp.devtools@gmail.com";
        
        // SOAP Format
        public const string SOAP = "SOAP";
        
        // NVP Format
        public const string NVP = "NV";
        
        // HTTP Header Constants
        // PayPal Security UserId Header
        public const string PayPalSecurityUserIdHeader = "X-PAYPAL-SECURITY-USERID";

        // PayPal Security Password Header
        public const string PayPalSecurityPasswordHeader = "X-PAYPAL-SECURITY-PASSWORD";

        // PayPal Security Signature Header
        public const string PayPalSecuritySignatureHeader = "X-PAYPAL-SECURITY-SIGNATURE";

        // PayPal Platform Authorization Header
        public const string PayPalAuthorizationPlatformHeader = "X-PAYPAL-AUTHORIZATION";

        // PayPal Merchant Authorization Header
        public const string PayPalAuthorizationMerchantHeader = "X-PP-AUTHORIZATION";

        // PayPal Application Id Header
        public const string PayPalApplicationIdHeader = "X-PAYPAL-APPLICATION-ID";

        // PayPal Request Data Header
        public const string PayPalRequestDataFormatHeader = "X-PAYPAL-REQUEST-DATA-FORMAT";

        // PayPal Request Data Header
        public const string PayPalResponseDataFormatHeader = "X-PAYPAL-RESPONSE-DATA-FORMAT";

        // PayPal Request Source Header
        public const string PayPalRequestSourceHeader = "X-PAYPAL-REQUEST-SOURCE";
        
        // PayPal Sandbox Email Address Header
        public const string PayPalSandboxDeviceIPAddress = "X-PAYPAL-DEVICE-IPADDRESS";

        // PayPal Sandbox Email Address Header
        public const string PayPalSandboxEmailAddressHeader = "X-PAYPAL-SANDBOX-EMAIL-ADDRESS";

        // Allowed application mode - Live
        public const string LiveMode = "live";

        // Allowe application mode - sandbox
        public const string SandboxMode = "sandbox";

        /// <summary>
        /// Sandbox REST API endpoint
        /// </summary>
        public const string RESTSandboxEndpoint = "https://api.sandbox.paypal.com/";

        /// <summary>
        /// Live REST API endpoint
        /// </summary>
        public const string RESTLiveEndpoint = "https://api.paypal.com/";

        // Configuration key for application mode
        public const string ApplicationModeConfig = "mode";

        // Configuration key for End point
        public const string EndpointConfig = "endpoint";

        // Configuration key for IPN endpoint 
        public const string IPNEndpointConfig = "IPNEndpoint";

        // Configuration key for IPAddress
        public const string ClientIPAddressConfig = "IPAddress";
       
        // Configuration key for Email Address
        public const string PayPalSandboxEmailAddressConfig = "sandboxEmailAddress";

        // Configuration key for HTTP Proxy Address
        public const string HttpProxyAddressConfig = "proxyAddress";

        // Configuration key for HTTP Proxy Credential
        public const string HttpProxyCredentialConfig = "proxyCredentials";

        // Configuration key for HTTP Connection Timeout
        public const string HttpConnectionTimeoutConfig = "connectionTimeout";

        // Configuration key for HTTP Connection Retry
        public const string HttpConnectionRetryConfig = "requestRetries";

        // Configuration key suffix for Credential Username
        public const string CredentialUserNameConfig = "apiUsername";

        // Configuration key suffix for Credential Password
        public const string CredentialPasswordConfig = "apiPassword";

        // Configuration key suffix for Credential Application Id
        public const string CredentialApplicationIdConfig = "applicationId";

        // Configuration key suffix for Credential Subject
        public const string CredentialSubjectConfig = "Subject";

        // Configuration key suffix for Credential Signature
        public const string CredentialSignatureConfig = "apiSignature";

        // Configuration key suffix for Credential Certificate Path
        public const string CredentialCertPathConfig = "apiCertificate";

        // Configuration key suffix for Credential Certificate Key
        public const string CredentialCertKeyConfig = "privateKeyPassword";

        // Configuration key suffix for Client Id
        public const string ClientId = "clientId";

        // Configuration key suffix for Client Secret
        public const string ClientSecret = "clientSecret";

        // OpenId Redirect URI config key
        public const string OpenIdRedirectUri = "openid.RedirectUri";

        // OpenId Redirect URI default value
        public const string OpenIdRedirectUriConstant = "https://www.paypal.com/webapps/auth/protocol/openidconnect";

        // OAuth endpoint config key
        public const string OAuthEndpoint = "oauth.EndPoint";

        // User Agent HTTP Header
        public const string UserAgentHeader = "User-Agent";

        // Content Type HTTP Header
        public const string ContentTypeHeader = "Content-Type";

        // Application - Json Content Type
        public const string ContentTypeHeaderJson = "application/json";

        // Application - Xml Content Type
        public const string ContentTypeXML = "text/xml";

        // Authorization HTTP Header
        public const string AuthorizationHeader = "Authorization";

        // PayPal Request Id HTTP Header
        public const string PayPalRequestIdHeader = "PayPal-Request-Id";

        // DotNet SdkVersion for paypal-core
        public static string SdkVersion { get { return SDKUtil.GetAssemblyVersionForType(typeof(BaseConstants)); } }
        
        public static class ErrorMessages
        {
            public const string ProfileNull = "APIProfile cannot be null.";
            public const string PayloadNull = "Payload cannot be null or empty.";
            public const string ErrorEndpoint = "Endpoint cannot be empty.";
            public const string ErrorUserName = "API Username cannot be empty";
            public const string ErrorPassword = "API Password cannot be empty.";
            public const string ErrorSignature = "API Signature cannot be empty.";
            public const string ErrorAppId = "Application Id cannot be empty.";
            public const string ErrorCertificate = "Certificate cannot be empty.";
            public const string ErrorPrivateKeyPassword = "Private Key Password cannot be null or empty.";
        }

        /// <summary>
        /// Defines string constants for HATEOAS link relations.
        /// </summary>
        public static class HateoasLinkRelations
        {
            /// <summary>
            /// HATEOAS link relation used to get the details of the current resource.
            /// </summary>
            public const string Self = "self";

            /// <summary>
            /// HATEOAS link relation used to get the details of the parent payment of a payment resource.
            /// </summary>
            public const string ParentPayment = "parent_payment";

            /// <summary>
            /// HATEOAS link relation used to update the current resource.
            /// </summary>
            public const string Update = "update";

            /// <summary>
            /// HATEOAS link relation used to delete the current resource.
            /// </summary>
            public const string Delete = "delete";

            /// <summary>
            /// HATEOAS link relation used to patch the current resource.
            /// </summary>
            public const string Patch = "patch";

            /// <summary>
            /// HATEOAS link relation used to redirect a buyer to PayPal to provide approval for the payment associated with the current resource.
            /// </summary>
            public const string ApprovalUrl = "approval_url";

            /// <summary>
            /// HATEOAS link relation used to execute the payment associated with the current resource.
            /// </summary>
            public const string Execute = "execute";

            /// <summary>
            /// HATEOAS link relation used to capture the payment associated with the current resource.
            /// </summary>
            public const string Capture = "capture";

            /// <summary>
            /// HATEOAS link relation used to provide authorization for the payment associated with the current resource.
            /// </summary>
            public const string Authorization = "authorization";

            /// <summary>
            /// HATEOAS link relation used to get the order resource associated with the current resource.
            /// </summary>
            public const string Order = "order";

            /// <summary>
            /// HATEOAS link relation used to issue a refund for the current resource.
            /// </summary>
            public const string Refund = "refund";

            /// <summary>
            /// HATEOAS link relation used to void the current resource.
            /// </summary>
            public const string Void = "void";

            /// <summary>
            /// HATEOAS link relation used to reauthorize a payment authorization resource.
            /// </summary>
            public const string ReAuthorize = "reauthorize";

            /// <summary>
            /// HATEOAS link relation used for searches and provides results for the next set of search results.
            /// </summary>
            public const string NextPage = "next_page";

            /// <summary>
            /// HATEOAS link relation used for searches and provides results for the previous set of search results.
            /// </summary>
            public const string PreviousPage = "previous_page";

            /// <summary>
            /// HATEOAS link relation used for searches and provides results for the first set of search results.
            /// </summary>
            public const string Start = "start";

            /// <summary>
            /// HATEOAS link relation used for searches and provides results for the last set of search results.
            /// </summary>
            public const string Last = "last";

            /// <summary>
            /// HATEOAS link relation used to suspend a billing agreement.
            /// </summary>
            public const string Suspend = "suspend";

            /// <summary>
            /// HATEOAS link relation used to reactivate a billing agreement.
            /// </summary>
            public const string ReActivate = "re_activate";

            /// <summary>
            /// HATEOAS link relation used to cancel a billing agreement.
            /// </summary>
            public const string Cancel = "cancel";

            /// <summary>
            /// HATEOAS link relation used to get the payout batch associated with the current payout item resource.
            /// </summary>
            public const string Batch = "batch";

            /// <summary>
            /// HATEOAS link relation used to get a specific payout item resource associated with current payout batch.
            /// </summary>
            public const string Item = "item";

            /// <summary>
            /// HATEOAS link relation used to resend a webhook event.
            /// </summary>
            public const string Resend = "resend";

            /// <summary>
            /// HATEOAS link relation used for webhook searches and provides results for the next set of search results.
            /// </summary>
            public const string Next = "next";

            /// <summary>
            /// HATEOAS link relation used for webhook searches and provides results for the previous set of search results.
            /// </summary>
            public const string Previous = "previous";
        }
    }
}
