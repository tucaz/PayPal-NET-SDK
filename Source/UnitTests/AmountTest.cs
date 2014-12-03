using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class AmountTest
    {
        public static readonly string AmountJson = 
            "{\"total\":\"100\"," +
            "\"currency\":\"USD\"," +
            "\"details\":" + DetailsTest.DetailsJson + "}";

        public static Amount GetAmount()
        {
            return JsonFormatter.ConvertFromJson<Amount>(AmountJson);
        }

        [TestMethod()]
        public void AmountObjectTest()
        {
            var amount = GetAmount();
            Assert.AreEqual("USD", amount.currency);
            Assert.AreEqual("100", amount.total);
            Assert.IsNotNull(amount.details);
        }

        [TestMethod()]
        public void AmountConvertToJsonTest()
        {
            Assert.IsFalse(GetAmount().ConvertToJson().Length == 0);
        }
        
        [TestMethod()]
        public void AmountToStringTest()
        {
            Assert.IsFalse(GetAmount().ToString().Length == 0);
        }
    }
}
