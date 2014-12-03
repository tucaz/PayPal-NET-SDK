using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass]
    public class SaleTest
    {
        public static Sale GetSale()
        {
            var sale = new Sale();
            sale.amount = AmountTest.GetAmount();
            sale.id = "102";
            sale.parent_payment = "103";
            sale.state = "Approved";
            sale.create_time = "2013-01-17T18:12:02.347Z";
            sale.links = LinksTest.GetLinksList();
            return sale;
        }

        [TestMethod()]
        public void SaleObjectTest()
        {
            var sale = GetSale();
            Assert.AreEqual("102", sale.id);
            Assert.AreEqual("103", sale.parent_payment);
            Assert.AreEqual("Approved", sale.state);
            Assert.AreEqual("2013-01-17T18:12:02.347Z", sale.create_time);
            Assert.IsNotNull(sale.amount);
            Assert.IsNotNull(sale.links);
        }

        [TestMethod()]
        public void SaleNullIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Sale.Get(UnitTestUtil.GetApiContext(), null));
        }

        [TestMethod()]
        public void SaleConvertToJsonTest()
        {
            Assert.IsFalse(GetSale().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void SaleToStringTest()
        {
            Assert.IsFalse(GetSale().ToString().Length == 0);
        }
    }
}
