using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    /// <summary>
    ///This is a test class for DetailsTest and is intended
    ///to contain all DetailsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DetailsTest
    {
        private Details GetDetails()
        {
            Details amntDetails = new Details();
            amntDetails.tax = "15";
            amntDetails.fee = "2";
            amntDetails.shipping = "10";
            amntDetails.subtotal = "75";
            return amntDetails;
        }

        /// <summary>
        ///A test for tax
        ///</summary>
        [TestMethod()]
        public void TaxTest()
        {
            Details target = GetDetails();
            string expected = "15";
            string actual = target.tax;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for subtotal
        ///</summary>
        [TestMethod()]
        public void SubtotalTest()
        {
            Details target = GetDetails();
            string expected = "75";
            string actual = target.subtotal;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for shipping
        ///</summary>
        [TestMethod()]
        public void ShippingTest()
        {
            Details target = GetDetails();
            string expected = "10";
            string actual = target.shipping;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for fee
        ///</summary>
        [TestMethod()]
        public void FeeTest()
        {
            Details target = GetDetails();
            string expected = "2";
            string actual = target.fee;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConvertToJson
        ///</summary>
        [TestMethod()]
        public void ConvertToJsonTest()
        {
            Details target = GetDetails();
            Assert.AreEqual("75", target.subtotal);
            Assert.AreEqual("15", target.tax);
            Assert.AreEqual("10", target.shipping);
            Assert.AreEqual("2", target.fee);
        }

        /// <summary>
        ///A test for Details Constructor
        ///</summary>
        [TestMethod()]
        public void DetailsConstructorTest()
        {
            Details target = new Details();
            Assert.IsNotNull(target);
        }
    }
}
