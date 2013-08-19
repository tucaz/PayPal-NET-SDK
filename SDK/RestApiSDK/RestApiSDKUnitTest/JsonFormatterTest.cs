using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for JsonFormatterTest and is intended
    ///to contain all JsonFormatterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JsonFormatterTest
    {
        /// <summary>
        ///A test for ConvertFromJson
        ///</summary>
        public void ConvertFromJsonTestHelper<T>()
        {
            string response = string.Empty; // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            actual = JsonFormatter.ConvertFromJson<T>(response);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        public void ConvertToJsonTestHelper<T>()
        {
            T t = default(T); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = JsonFormatter.ConvertToJson<T>(t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
