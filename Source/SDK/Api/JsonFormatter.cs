using Newtonsoft.Json;

namespace PayPal.Api
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
