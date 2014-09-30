using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ItemTest
    {
        [TestMethod()]
        public void TestItem()
        {
            var itm = UnitTestUtil.GetItem();
            Assert.AreEqual(itm.name, "Item Name");
            Assert.AreEqual(itm.currency, "USD");
            Assert.AreEqual(itm.price, "10.50");
            Assert.AreEqual(itm.quantity, "5");
            Assert.AreEqual(itm.sku, "Sku");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var item = UnitTestUtil.GetItem();
            Assert.IsFalse(item.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var item = UnitTestUtil.GetItem();
            Assert.IsFalse(item.ToString().Length == 0);
        }
    }
}
