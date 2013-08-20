using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class DetailsTest
    {
        private Details GetDetails()
        {
            Details detail = new Details();
            detail.tax = "15";
            detail.fee = "2";
            detail.shipping = "10";
            detail.subtotal = "75";
            return detail;
        }

        [TestMethod()]
        public void TaxTest()
        {
            Details target = GetDetails();
            string expected = "15";
            string actual = target.tax;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtotalTest()
        {
            Details target = GetDetails();
            string expected = "75";
            string actual = target.subtotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShippingTest()
        {
            Details target = GetDetails();
            string expected = "10";
            string actual = target.shipping;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FeeTest()
        {
            Details target = GetDetails();
            string expected = "2";
            string actual = target.fee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Details target = GetDetails();
            Assert.AreEqual("75", target.subtotal);
            Assert.AreEqual("15", target.tax);
            Assert.AreEqual("10", target.shipping);
            Assert.AreEqual("2", target.fee);
            Assert.IsFalse(target.ToString().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Details target = GetDetails();
            Assert.IsFalse(target.ToString().Length == 0);
        }
    }
}
