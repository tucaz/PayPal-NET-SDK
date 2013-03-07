using System;
// install Newtonsoft.Json -excludeversion -outputDirectory .\Packages
// net35
using Newtonsoft.Json;

namespace PayPal
{
    public static class JsonFormatter
    {  
        public static string ConvertToJson<T>(T t) 
        {
            return JsonConvert.SerializeObject(t);
        }

        public static T ConvertFromJson<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
