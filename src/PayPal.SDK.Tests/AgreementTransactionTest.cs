using PayPal.Api;
using Xunit;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for AgreementTransaction
    /// </summary>
    
    public class AgreementTransactionTest
    {
        public static readonly string AgreementTransactionJson =
            "{\"transaction_id\":\"I-0LN988D3JACS\"," +
            "\"status\":\"Created\"," +
            "\"transaction_type\":\"Recurring Payment\"," +
            "\"payer_email\":\"bbuyer@example.com\"," +
            "\"payer_name\":\"Betsy Buyer\"," +
            "\"time_zone\":\"GMT\"}";

        public static AgreementTransaction GetAgreementTransaction()
        {
            return JsonFormatter.ConvertFromJson<AgreementTransaction>(AgreementTransactionJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementTransactionObjectTest()
        {
            var testObject = GetAgreementTransaction();
            Assert.Equal("I-0LN988D3JACS", testObject.transaction_id);
            Assert.Equal("Created", testObject.status);
            Assert.Equal("Recurring Payment", testObject.transaction_type);
            Assert.Equal("bbuyer@example.com", testObject.payer_email);
            Assert.Equal("Betsy Buyer", testObject.payer_name);
            Assert.Equal("GMT", testObject.time_zone);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementTransactionConvertToJsonTest()
        {
            Assert.False(GetAgreementTransaction().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementTransactionToStringTest()
        {
            Assert.False(GetAgreementTransaction().ToString().Length == 0);
        }
    }
}
