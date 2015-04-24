namespace PayPal
{
    /// <summary>
    /// List of supported HTTP methods when making HTTP requests to the PayPal REST API.
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// GET HTTP request. This is typically used in API operations to retrieve a static resource.
        /// </summary>
        GET,

        /// <summary>
        /// HEAD HTTP request. This is typically used to retrieve only the header information for a static resource.
        /// </summary>
        HEAD,

        /// <summary>
        /// POST HTTP request. This is typically used in API operations that require data in the request body to complete.
        /// </summary>
        POST,

        /// <summary>
        /// PUT HTTP request. This is used in some API operations that update a given resource.
        /// </summary>
        PUT,

        /// <summary>
        /// DELETE HTTP request. This is typcially used in API oeprations that delete a given resource.
        /// </summary>
        DELETE,

        /// <summary>
        /// PATCH HTTP request. This is typcially used in API operations that update a given resource.
        /// </summary>
        PATCH
    }
}
