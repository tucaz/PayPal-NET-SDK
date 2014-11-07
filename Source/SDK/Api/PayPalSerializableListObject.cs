using System.Collections.Generic;

namespace PayPal.Api
{
    public class PayPalSerializableListObject<T> : List<T>, IPayPalSerializableObject
    {
        /// <summary>
        /// Converts this object to a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string.</returns>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}
