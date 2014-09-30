using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal.Manager;
using PayPal;

namespace RestApiSDKUnitTest
{
    [TestClass]
    public class ReauthorizationTest
    {
        [TestMethod]
        public void TestReauthorization()
        {
            var authorization = Authorization.Get(UnitTestUtil.GetApiContext(), "7GH53639GA425732B");
            var reauthorizeAmount = new Amount();
            reauthorizeAmount.currency = "USD";
            reauthorizeAmount.total = "1";
            authorization.amount = reauthorizeAmount;
            UnitTestUtil.AssertThrownException<PayPal.Exception.HttpException>(() => authorization.Reauthorize(UnitTestUtil.GetApiContext()));
        }
    }
}
