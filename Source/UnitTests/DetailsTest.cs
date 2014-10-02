using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class DetailsTest
    {
        public static Details GetDetails()
        {
            Details detail = new Details();
            detail.tax = "15";
            detail.fee = "0";
            detail.shipping = "10";
            detail.subtotal = "75";
            return detail;
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
