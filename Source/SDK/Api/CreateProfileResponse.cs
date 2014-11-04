using Newtonsoft.Json;

namespace PayPal.Api
{
    public class CreateProfileResponse
    {
        /// <summary>
        /// ID of the payment web experience profile.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
