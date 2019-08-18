using System.Collections.Generic;
using PayPal.Api;
using System;
using System.Net;
using PayPal.Util;
using Xunit;


namespace PayPal.Testing
{
    
    public class Crc32Test
    {
        [Fact, Trait("Category", "Unit")]
        public void Crc32ComputeChecksumTest()
        {
            Assert.Equal((uint)0x0967b587, Crc32.ComputeChecksum("test_string"));
        }
    }
}