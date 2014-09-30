using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PayerInfoTest
    {
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var info = UnitTestUtil.GetPayerInfo();
            Assert.IsFalse(info.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var info = UnitTestUtil.GetPayerInfo();
            Assert.IsFalse(info.ToString().Length == 0);
        }
    }
}
