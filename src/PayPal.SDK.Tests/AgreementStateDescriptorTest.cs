using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for AgreementStateDescriptorTest
    /// </summary>
    
    public class AgreementStateDescriptorTest
    {
        public static readonly string AgreementStateDescriptorJson = "{\"note\":\"Billing Balance Amount\",\"amount\":" + AmountTest.AmountJson + "}";

        public static AgreementStateDescriptor GetAgreementStateDescriptor()
        {
            return JsonFormatter.ConvertFromJson<AgreementStateDescriptor>(AgreementStateDescriptorJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementStateDescriptorObjectTest()
        {
            var testObject = GetAgreementStateDescriptor();
            Assert.Equal("Billing Balance Amount", testObject.note);
            Assert.NotNull(testObject.amount);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementStateDescriptorConvertToJsonTest()
        {
            Assert.False(GetAgreementStateDescriptor().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementStateDescriptorToStringTest()
        {
            Assert.False(GetAgreementStateDescriptor().ToString().Length == 0);
        }
    }
}
