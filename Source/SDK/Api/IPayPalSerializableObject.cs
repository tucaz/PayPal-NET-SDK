using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayPal.Api
{
    public interface IPayPalSerializableObject
    {
        /// <summary>
        /// Converts this object to a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string.</returns>
        string ConvertToJson();
    }
}
