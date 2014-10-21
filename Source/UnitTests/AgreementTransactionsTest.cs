using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for AgreementTransactionsTest
    /// </summary>
    [TestClass]
    public class AgreementTransactionsTest
    {
        public static readonly string AgreementTransactionsJson = "{\"agreement_transaction_list\":[" + AgreementTransactionTest.AgreementTransactionJson + "]}";

        public static AgreementTransactions GetAgreementTransactions()
        {
            return JsonFormatter.ConvertFromJson<AgreementTransactions>(AgreementTransactionsJson);
        }

        [TestMethod()]
        public void AgreementTransactionsObjectTest()
        {
            var testObject = GetAgreementTransactions();
            Assert.IsNotNull(testObject.agreement_transaction_list);
            Assert.IsTrue(testObject.agreement_transaction_list.Count == 1);
        }

        [TestMethod()]
        public void AgreementTransactionsConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreementTransactions().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void AgreementTransactionsToStringTest()
        {
            Assert.IsFalse(GetAgreementTransactions().ToString().Length == 0);
        }
    }
}
