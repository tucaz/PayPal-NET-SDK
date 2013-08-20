using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AmountTest
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

        private Amount GetAmount()
        {
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.details = GetDetails();
            amnt.total = "100";
            return amnt;
        }

        [TestMethod()]
        public void TotalTest()
        {
            Amount target = GetAmount();
            string expected = "100";
            string actual = target.total;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Amount target = GetAmount();
            Details expected = GetDetails();
            Details actual = target.details;
            Assert.AreEqual(expected.subtotal, actual.subtotal);
            Assert.AreEqual(expected.fee, actual.fee);
            Assert.AreEqual(expected.shipping, actual.shipping);
            Assert.AreEqual(expected.subtotal, actual.subtotal);
        }

        [TestMethod()]
        public void CurrencyTest()
        {
            Amount target = GetAmount();
            string expected = "USD";
            string actual = target.currency;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Amount target = GetAmount();
            Assert.AreEqual("100", target.total);
            Assert.AreEqual("USD", target.currency);
            Assert.AreEqual("75", target.details.subtotal);
            Assert.AreEqual("10", target.details.shipping);
            Assert.AreEqual("15", target.details.tax);
            Assert.IsFalse(target.ConvertToJson().Length == 0);
        }
        
        [TestMethod()]
        public void ToStringTest()
        {
            Amount amt = GetAmount();
            Assert.IsFalse(amt.ToString().Length == 0);
        }
    }
}
