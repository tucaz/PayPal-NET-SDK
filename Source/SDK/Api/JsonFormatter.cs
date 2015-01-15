using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayPal.Log;

namespace PayPal.Api
{
    /// <summary>
    /// Helper class that handles serializing and deserializing to and from JSON strings, respectively.
    /// </summary>
    public static class JsonFormatter
    {
        private static Logger logger = Logger.GetLogger(typeof(JsonFormatter));

        /// <summary>
        /// Converts the specified object to a JSON string.
        /// </summary>
        /// <typeparam name="T">A JSON-serializable object type.</typeparam>
        /// <param name="t">The object to be serialized.</param>
        /// <returns>A JSON string representing the specified object.</returns>
        public static string ConvertToJson<T>(T t) 
        {
            return JsonConvert.SerializeObject(t);
        }

        /// <summary>
        /// Converts the specified JSON string to the specified object.
        /// </summary>
        /// <typeparam name="T">The object type to which the JSON string will be deserialized.</typeparam>
        /// <param name="value">A JSON string.</param>
        /// <returns>An object containing the data from the JSON string.</returns>
        public static T ConvertFromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings 
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                Error = ErrorHandler
            });
        }

        /// <summary>
        /// Error handler for errors encountered while attempting to deserialize a JSON string.
        /// </summary>
        /// <param name="sender">Object that sent the event</param>
        /// <param name="e">Event arguments</param>
        private static void ErrorHandler(object sender, ErrorEventArgs e)
        {
            logger.Error("Error while deserializing JSON: " + e.ErrorContext.Error.Message);
            e.ErrorContext.Handled = e.CurrentObject != null;
        }
    }
}
