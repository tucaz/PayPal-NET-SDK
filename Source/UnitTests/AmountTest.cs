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
            amnt.total = "100";
            amnt.details = GetDetails();            
            return amnt;
        }


        [TestMethod()]
        public void AmountObjectTest()
        {
            Amount target = GetAmount();            
            Assert.AreEqual("USD", target.currency);
            Assert.AreEqual("100", target.total);
            Assert.AreEqual("75", target.details.subtotal);
            Assert.AreEqual("15", target.details.tax);
            Assert.AreEqual("2", target.details.fee);
            Assert.AreEqual("10", target.details.shipping);
            Assert.AreEqual("75", target.details.subtotal);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Amount amt = GetAmount();
            Assert.IsFalse(amt.ConvertToJson().Length == 0);
        }
        
        [TestMethod()]
        public void ToStringTest()
        {
            Amount amt = GetAmount();
            Assert.IsFalse(amt.ToString().Length == 0);
        }
    }
}
