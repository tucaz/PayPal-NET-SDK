using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var transaction = UnitTestUtil.GetTransaction();
            Assert.IsFalse(transaction.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var transaction = UnitTestUtil.GetTransaction();
            Assert.IsFalse(transaction.ToString().Length == 0);
        }
    }
}
