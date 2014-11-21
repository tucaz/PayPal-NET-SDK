using Newtonsoft.Json;
using System;
using System.IO;

namespace PayPal.Api
{
    public class Image : PayPalSerializableObject
    {
        /// <summary>
        /// A base-64 encoded string representing a PNG image.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "image")]
        public string image { get; set; }

        /// <summary>
        /// Saves the image data to a file on disk.
        /// </summary>
        /// <param name="filename">The path to the file where the image will be saved.</param>
        public void Save(string filename)
        {
            if(!string.IsNullOrEmpty(this.image))
            {
                File.WriteAllBytes(filename, Convert.FromBase64String(this.image));
            }
        }
    }
}
