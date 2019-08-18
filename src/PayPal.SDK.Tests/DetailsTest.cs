
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class DetailsTest
    {
        public static readonly string DetailsJson = 
            "{\"tax\":\"15\"," +
            "\"fee\":\"0\"," +
            "\"shipping\":\"10\"," +
            "\"subtotal\":\"75\"}";

        public static Details GetDetails()
        {
            return JsonFormatter.ConvertFromJson<Details>(DetailsJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void DetailsObjectTest()
        {
            var detail = GetDetails();
            Assert.Equal("75", detail.subtotal);
            Assert.Equal("15", detail.tax);
            Assert.Equal("10", detail.shipping);
            Assert.Equal("0", detail.fee);
        }

        [Fact, Trait("Category", "Unit")]
        public void DetailsConvertToJsonTest()
        {
            Assert.False(GetDetails().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void DetailsToStringTest()
        {
            Assert.False(GetDetails().ToString().Length == 0);
        }
    }
}
