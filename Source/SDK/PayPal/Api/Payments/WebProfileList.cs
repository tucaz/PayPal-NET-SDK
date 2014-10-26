using System.Collections.Generic;

namespace PayPal.Api.Payments
{
    public class WebProfileList : List<WebProfile>
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
