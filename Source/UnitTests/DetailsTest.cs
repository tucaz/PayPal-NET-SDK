using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class DetailsTest
    {
        [TestMethod()]
        public void TestDetails()
        {
            var detail = UnitTestUtil.GetDetails();
            Assert.AreEqual("75", detail.subtotal);
            Assert.AreEqual("15", detail.tax);
            Assert.AreEqual("10", detail.shipping);
            Assert.AreEqual("2", detail.fee);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var detail = UnitTestUtil.GetDetails();
            Assert.IsFalse(detail.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var detail = UnitTestUtil.GetDetails();
            Assert.IsFalse(detail.ToString().Length == 0);
        }
    }
}
