using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for BankAccountTest
    /// </summary>
    
    public class BankAccountTest
    {
        public static BankAccount GetBankAccount()
        {
            var bankAccount = new BankAccount();
            bankAccount.account_name = "Test Account";
            bankAccount.account_number = "01234567890123456789";
            bankAccount.account_number_type = "BBAN";
            bankAccount.account_type = "CHECKING";
            bankAccount.check_type = "PERSONAL";
            bankAccount.billing_address = AddressTest.GetAddress();
            bankAccount.links = LinksTest.GetLinksList();
            return bankAccount;
        }

        [Fact, Trait("Category", "Unit")]
        public void BankAccountObjectTest()
        {
            var bankAccount = GetBankAccount();
            Assert.Equal("Test Account", bankAccount.account_name);
            Assert.Equal("01234567890123456789", bankAccount.account_number);
            Assert.Equal("BBAN", bankAccount.account_number_type);
            Assert.Equal("CHECKING", bankAccount.account_type);
            Assert.Equal("PERSONAL", bankAccount.check_type);
            Assert.NotNull(bankAccount.billing_address);
            Assert.NotNull(bankAccount.links);
        }

        [Fact, Trait("Category", "Unit")]
        public void BankAccountConvertToJsonTest()
        {
            Assert.False(GetBankAccount().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void BankAccountToStringTest()
        {
            Assert.False(GetBankAccount().ToString().Length == 0);
        }
    }
}
