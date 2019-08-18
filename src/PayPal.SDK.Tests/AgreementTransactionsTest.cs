using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for AgreementTransactionsTest
    /// </summary>
    
    public class AgreementTransactionsTest
    {
        public static readonly string AgreementTransactionsJson = "{\"agreement_transaction_list\":[" + AgreementTransactionTest.AgreementTransactionJson + "]}";

        public static AgreementTransactions GetAgreementTransactions()
        {
            return JsonFormatter.ConvertFromJson<AgreementTransactions>(AgreementTransactionsJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementTransactionsObjectTest()
        {
            var testObject = GetAgreementTransactions();
            Assert.NotNull(testObject.agreement_transaction_list);
            Assert.True(testObject.agreement_transaction_list.Count == 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementTransactionsConvertToJsonTest()
        {
            Assert.False(GetAgreementTransactions().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void AgreementTransactionsToStringTest()
        {
            Assert.False(GetAgreementTransactions().ToString().Length == 0);
        }
    }
}
