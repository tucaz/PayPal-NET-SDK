using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
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

        [TestMethod()]
        public void DetailsObjectTest()
        {
            var detail = GetDetails();
            Assert.AreEqual("75", detail.subtotal);
            Assert.AreEqual("15", detail.tax);
            Assert.AreEqual("10", detail.shipping);
            Assert.AreEqual("0", detail.fee);
        }

        [TestMethod()]
        public void DetailsConvertToJsonTest()
        {
            Assert.IsFalse(GetDetails().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void DetailsToStringTest()
        {
            Assert.IsFalse(GetDetails().ToString().Length == 0);
        }
    }
}
