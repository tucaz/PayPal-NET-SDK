using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayPal.Api
{
    public class PayPalSerializableObject
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
