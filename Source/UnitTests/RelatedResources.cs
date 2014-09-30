using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass]
    public class RelatedResourcesTest
    {
        [TestMethod()]
        public void TestRelatedResources() 
        {
            var resources = UnitTestUtil.GetRelatedResources();
            Assert.AreEqual(resources.authorization.id, UnitTestUtil.GetAuthorization().id);
            Assert.AreEqual(resources.sale.id, UnitTestUtil.GetSale().id);
            Assert.AreEqual(resources.refund.id, UnitTestUtil.GetRefund().id);
            Assert.AreEqual(resources.capture.id, UnitTestUtil.GetCapture().id);
        }

        [TestMethod()]
        public void ConvertToJsonTest() 
        {
            var resources = UnitTestUtil.GetRelatedResources();
            Assert.IsFalse(resources.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest() 
        {
            var resources = UnitTestUtil.GetRelatedResources();
            Assert.IsFalse(resources.ToString().Length == 0);
        }
    }
}
