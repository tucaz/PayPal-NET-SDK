using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class ItemListTest
    {
        [TestMethod()]
        public void TestItemList()
        {
            var list = UnitTestUtil.GetItemList();
            Assert.AreEqual(UnitTestUtil.GetShippingAddress().recipient_name, list.shipping_address.recipient_name);
            Assert.AreEqual(list.items.Count, 2);
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var list = UnitTestUtil.GetItemList();
            Assert.IsFalse(list.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var list = UnitTestUtil.GetItemList();
            Assert.IsFalse(list.ToString().Length == 0);
        }
    }
}
