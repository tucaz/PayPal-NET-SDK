using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for AgreementStateDescriptorTest
    /// </summary>
    [TestClass]
    public class AgreementStateDescriptorTest
    {
        public static readonly string AgreementStateDescriptorJson = "{\"note\":\"Billing Balance Amount\",\"amount\":" + AmountTest.AmountJson + "}";

        public static AgreementStateDescriptor GetAgreementStateDescriptor()
        {
            return JsonFormatter.ConvertFromJson<AgreementStateDescriptor>(AgreementStateDescriptorJson);
        }

        [TestMethod()]
        public void AgreementStateDescriptorObjectTest()
        {
            var testObject = GetAgreementStateDescriptor();
            Assert.AreEqual("Billing Balance Amount", testObject.note);
            Assert.IsNotNull(testObject.amount);
        }

        [TestMethod()]
        public void AgreementStateDescriptorConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreementStateDescriptor().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void AgreementStateDescriptorToStringTest()
        {
            Assert.IsFalse(GetAgreementStateDescriptor().ToString().Length == 0);
        }
    }
}
