using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal;
using PayPal.Api.Payments;
using PayPal.Manager;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PayerTest
    {
        public static Payer GetPayer()
        {
            var fundingInstrumentList = new List<FundingInstrument>();
            fundingInstrumentList.Add(FundingInstrumentTest.GetFundingInstrument());
            var pay = new Payer();
            pay.funding_instruments = fundingInstrumentList;
            pay.payer_info = PayerInfoTest.GetPayerInfo();
            pay.payment_method = "credit_card";
            return pay;
        }

        [TestMethod()]
        public void PayerObjectTest()
        {
            var pay = GetPayer();
            Assert.AreEqual(pay.payment_method, "credit_card");
            Assert.AreEqual(pay.funding_instruments[0].credit_card_token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(pay.payer_info.first_name, "Joe");
        }

        [TestMethod()]
        public void PayerConvertToJsonTest()
        {
            Assert.IsFalse(GetPayer().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PayerToStringTest()
        {
            Assert.IsFalse(GetPayer().ToString().Length == 0);
        }
    }    
}
