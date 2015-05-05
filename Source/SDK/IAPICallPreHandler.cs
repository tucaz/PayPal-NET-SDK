using System.Collections.Generic;
using PayPal.Authentication;

namespace PayPal
{
    /// <summary>
    /// Interface for API calls.
    /// NOTE: This will be deprecated in a future release of this SDK.
    /// </summary>
    public interface IAPICallPreHandler
    {
        /// <summary>
        /// Returns headers for the HTTP call
        /// with name and value
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetHeaderMap();
        
        /// <summary>
        /// Returns the payload for the API call. 
        /// The implementation should take care 
        /// in formatting the payload appropriately
        /// </summary>
        /// <returns></returns>
	    string GetPayload();

	    /// <summary>
        /// Returns the endpoint for the API call
	    /// </summary>
	    /// <returns></returns>
	    string GetEndpoint();

	    /// <summary>
        /// Returns the ICredential configured for the API call
	    /// </summary>
	    /// <returns></returns>
	    ICredential GetCredential();
    }
}
