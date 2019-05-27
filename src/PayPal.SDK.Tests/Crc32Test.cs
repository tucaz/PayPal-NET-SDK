using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System;
using System.Net;
using PayPal.Util;

namespace PayPal.Testing
{
    [TestClass]
    public class Crc32Test
    {
        [TestMethod, TestCategory("Unit")]
        public void Crc32ComputeChecksumTest()
        {
            Assert.AreEqual((uint)0x0967b587, Crc32.ComputeChecksum("test_string"));
        }
    }
}