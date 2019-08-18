
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayerInfoTest
    {
        public static PayerInfo GetPayerInfo()
        {
            var info = GetPayerInfoBasic();
            info.email = "Joe.Shopper@email.com";
            info.phone = "5032141716";
            return info;
        }

        public static PayerInfo GetPayerInfoBasic()
        {
            PayerInfo info = new PayerInfo();
            info.first_name = "Joe";
            info.last_name = "Shopper";
            info.payer_id = "100";
            return info;
        }

        [Fact, Trait("Category", "Unit")]
        public void PayerInfoObjectTest()
        {
            var info = GetPayerInfo();
            Assert.Equal("Joe", info.first_name);
            Assert.Equal("Shopper", info.last_name);
            Assert.Equal("Joe.Shopper@email.com", info.email);
            Assert.Equal("100", info.payer_id);
            Assert.Equal("5032141716", info.phone);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayerInfoConvertToJsonTest()
        {
            Assert.False(GetPayerInfo().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayerInfoToStringTest()
        {
            Assert.False(GetPayerInfo().ToString().Length == 0);
        }
    }
}
