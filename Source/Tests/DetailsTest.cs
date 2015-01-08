using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
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

        [TestMethod, TestCategory("Unit")]
        public void DetailsObjectTest()
        {
            var detail = GetDetails();
            Assert.AreEqual("75", detail.subtotal);
            Assert.AreEqual("15", detail.tax);
            Assert.AreEqual("10", detail.shipping);
            Assert.AreEqual("0", detail.fee);
        }

        [TestMethod, TestCategory("Unit")]
        public void DetailsConvertToJsonTest()
        {
            Assert.IsFalse(GetDetails().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void DetailsToStringTest()
        {
            Assert.IsFalse(GetDetails().ToString().Length == 0);
        }
    }
}
