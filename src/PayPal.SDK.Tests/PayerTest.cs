using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
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

        [TestMethod, TestCategory("Unit")]
        public void PayerObjectTest()
        {
            var pay = GetPayerUsingCreditCard();
            Assert.AreEqual("credit_card", pay.payment_method);
            Assert.AreEqual("Joe", pay.payer_info.first_name);
            Assert.IsNotNull(pay.funding_instruments);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayerConvertToJsonTest()
        {
            Assert.IsFalse(GetPayerUsingCreditCard().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PayerToStringTest()
        {
            Assert.IsFalse(GetPayerUsingCreditCard().ToString().Length == 0);
        }
    }    
}
