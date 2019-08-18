
using PayPal;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class FundingInstrumentTest
    {
        public static FundingInstrument GetFundingInstrument()
        {
            FundingInstrument instrument = new FundingInstrument();
            instrument.credit_card = CreditCardTest.GetCreditCard();
            return instrument;
        }

        [Fact, Trait("Category", "Unit")]
        public void FundingInstrumentConvertToJsonTest()
        {
            Assert.False(GetFundingInstrument().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void FundingInstrumentToStringTest()
        {
            Assert.False(GetFundingInstrument().ToString().Length == 0);
        }
    }
}
