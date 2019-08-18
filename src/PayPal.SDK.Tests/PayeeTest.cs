
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayeeTest
    {
        public static Payee GetPayee()
        {
            Payee pay = new Payee();
            pay.merchant_id = "100";
            pay.email = "paypaluser@email.com";
            pay.phone = PhoneTest.GetPhone();
            return pay;
        }

        [Fact, Trait("Category", "Unit")]
        public void PayeeObjectTest()
        {
            var pay = GetPayee();
            Assert.Equal(pay.merchant_id, "100");
            Assert.Equal(pay.email, "paypaluser@email.com");
            Assert.NotNull(pay.phone);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayeeConvertToJsonTest()
        {
            Assert.False(GetPayee().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayeeToStringTest()
        {
            Assert.False(GetPayee().ToString().Length == 0);
        }
    }
}
