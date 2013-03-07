using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayPal.Util;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for SDKUtilTest and is intended
    ///to contain all SDKUtilTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SDKUtilTest
    {
        private string pattern
        {
            get
            {
                string stringPattern = "v1/payments/payment?count={0}&start_id={1}&start_index={2}&start_time={3}&end_time={4}&payee_id={5}";
                return stringPattern;
            }
        }

        private Object[] parameters
        {
            get
            {
                int? count = null;
                string startId = "001";
                int? startIndex = null;
                string startTime = "2013-01-15T15:10:05.123Z";
                string endTime = "2013-01-17T17:10:05.123Z";
                string payeeId = "007";
                Object[] paramtrs = new Object[] { count, startId, startIndex, startTime, endTime, payeeId };
                return paramtrs;
            }
        }

        [TestMethod()]
        public void FormatURIPathTest()
        {
            string expected = "v1/payments/payment?start_id=001&start_time=2013-01-15T15:10:05.123Z&end_time=2013-01-17T17:10:05.123Z&payee_id=007";
            string actual;
            actual = SDKUtil.FormatURIPath(pattern, parameters);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SDKUtilConstructorTest()
        {
            SDKUtil target = new SDKUtil();
            Assert.IsNotNull(target);
        }

    }
}
