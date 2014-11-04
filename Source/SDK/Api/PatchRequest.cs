using System.Collections.Generic;

namespace PayPal.Api
{
    public class PatchRequest : List<Patch>
    {
        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
