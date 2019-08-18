
using System.Collections.Generic;
using PayPal;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class PayerTest
    {
        public static Payer GetPayerUsingPayPal()
        {
            var pay = new Payer();
            pay.payer_info = PayerInfoTest.GetPayerInfoBasic();
            pay.payment_method = "paypal";
            return pay;
        }

        public static Payer GetPayerUsingCreditCard()
        {
            var fundingInstrumentList = new List<FundingInstrument>();
            fundingInstrumentList.Add(FundingInstrumentTest.GetFundingInstrument());
            var pay = new Payer();
            pay.funding_instruments = fundingInstrumentList;
            pay.payer_info = PayerInfoTest.GetPayerInfo();
            pay.payer_info.phone = null;
            pay.payment_method = "credit_card";
            return pay;
        }

        [Fact, Trait("Category", "Unit")]
        public void PayerObjectTest()
        {
            var pay = GetPayerUsingCreditCard();
            Assert.Equal("credit_card", pay.payment_method);
            Assert.Equal("Joe", pay.payer_info.first_name);
            Assert.NotNull(pay.funding_instruments);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayerConvertToJsonTest()
        {
            Assert.False(GetPayerUsingCreditCard().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PayerToStringTest()
        {
            Assert.False(GetPayerUsingCreditCard().ToString().Length == 0);
        }
    }    
}
