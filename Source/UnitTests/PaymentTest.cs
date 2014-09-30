using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal;
using PayPal.Manager;
using PayPal.Util;
using System;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class PaymentTest
    {
        public static Payment GetPaymentAuthorization()
        {
            return GetPayment("authorize");
        }

        public static Payment GetPaymentForSale()
        {
            return GetPayment("sale");
        }

        private static Payment GetPayment(string intent)
        {
            var payment = new Payment();
            payment.intent = intent;
            CreditCard card = CreditCardTest.GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = card;
            fundingInstruments.Add(fundingInstrument);
            Payer payer = new Payer();
            payer.payment_method = "credit_card";
            payer.funding_instruments = fundingInstruments;
            List<Transaction> transactionList = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = AmountTest.GetAmount();
            transactionList.Add(trans);
            payment.transactions = transactionList;
            payment.payer = payer;
            return payment;
        }

        public static Payment CreateFuturePayment()
        {
            FuturePayment pay = new FuturePayment();
            pay.intent = "sale";
            CreditCard card = CreditCardTest.GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = card;
            fundingInstruments.Add(fundingInstrument);
            Payer payer = new Payer();
            payer.payment_method = "credit_card";
            payer.funding_instruments = fundingInstruments;
            List<Transaction> transactionList = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = AmountTest.GetAmount();
            transactionList.Add(trans);
            pay.transactions = transactionList;
            pay.payer = payer;
            Payment paymnt = pay.Create(UnitTestUtil.GetApiContext());
            return paymnt;
        }

        public static Payment CreatePaymentAuthorization()
        {
            return GetPaymentAuthorization().Create(UnitTestUtil.GetApiContext());
        }

        public static Payment CreatePaymentForSale()
        {
            return GetPaymentForSale().Create(UnitTestUtil.GetApiContext());
        }

        [TestMethod()]
        public void PaymentStateTest()
        {
            var actual = CreatePaymentForSale();
            Assert.AreEqual("approved", actual.state);
        }

        [TestMethod()]
        public void PaymentNullAccessToken()
        {
            var payment = GetPaymentForSale();
            string accessToken = null;
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => payment.Create(accessToken));
        }

        [TestMethod()]
        public void PaymentObjectTest()
        {
            var context = UnitTestUtil.GetApiContext();
            var pay = CreatePaymentForSale();
            var retrievedPayment = Payment.Get(context, pay.id);
            Assert.AreEqual(pay.id, retrievedPayment.id);
        }

        [TestMethod()]
        public void PaymentListHistoryTest()
        {
            var context = UnitTestUtil.GetApiContext();
            var containerDictionary = new Dictionary<string, string>();
            containerDictionary.Add("count", "10");
            var paymentHistory = Payment.List(context, containerDictionary);
            Assert.AreEqual(10, paymentHistory.count);
        }

        [TestMethod()]
        public void FuturePaymentTest()
        {
            var context = UnitTestUtil.GetApiContext();
            var futurePayment = CreateFuturePayment();
            var retrievedPayment = FuturePayment.Get(context, futurePayment.id);
            Assert.AreEqual(futurePayment.id, retrievedPayment.id);
        }
    }
}
