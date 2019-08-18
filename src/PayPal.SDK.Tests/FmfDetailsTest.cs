
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class FmfDetailsTest
    {
        public static readonly string FmfDetailsJson =
            "{\"filter_type\":\"FILTER\"," +
            "\"filter_id\":\"001\"," +
            "\"name\":\"Filter name\"," +
            "\"description\":\"Filter description\"}";

        public static FmfDetails GetFmfDetails()
        {
            return JsonFormatter.ConvertFromJson<FmfDetails>(FmfDetailsJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void FmfDetailsObjectTest()
        {
            var testObject = GetFmfDetails();
            Assert.Equal("FILTER", testObject.filter_type);
            Assert.Equal("001", testObject.filter_id);
            Assert.Equal("Filter name", testObject.name);
            Assert.Equal("Filter description", testObject.description);
        }

        [Fact, Trait("Category", "Unit")]
        public void FmfDetailsConvertToJsonTest()
        {
            Assert.False(GetFmfDetails().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void FmfDetailsToStringTest()
        {
            Assert.False(GetFmfDetails().ToString().Length == 0);
        }
    }
}
