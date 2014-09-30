using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class FundingInstrumentTest
    {
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var instrument = UnitTestUtil.GetFundingInstrument();
            Assert.IsFalse(instrument.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var instrument = UnitTestUtil.GetFundingInstrument();
            Assert.IsFalse(instrument.ToString().Length == 0);
        }
    }
}
