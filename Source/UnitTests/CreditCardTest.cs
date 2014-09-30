using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;
using PayPal.Manager;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class CreditCardTest
    {
        [TestMethod()]
        public void TestCreditCard()
        {
            var card = UnitTestUtil.GetCreditCard();
            card.id = "002";
            card.external_customer_id = "008";
            var add = UnitTestUtil.GetAddress();
            Assert.AreEqual(card.number, "4825854086744369");
            Assert.AreEqual(card.first_name, "John");
            Assert.AreEqual(card.last_name, "Doe");
            Assert.AreEqual(card.expire_month, 01);
            Assert.AreEqual(card.expire_year, 2015);
            Assert.AreEqual(card.cvv2, 962);
            Assert.AreEqual(card.id, "002");
            Assert.AreEqual(card.external_customer_id, "008");
            Assert.AreEqual(add.city, card.billing_address.city);
            Assert.AreEqual(add.country_code, card.billing_address.country_code);
            Assert.AreEqual(add.line1, card.billing_address.line1);
            Assert.AreEqual(add.line2, card.billing_address.line2);
            Assert.AreEqual(add.phone, card.billing_address.phone);
            Assert.AreEqual(add.postal_code, card.billing_address.postal_code);
            Assert.AreEqual(add.state, card.billing_address.state);
        }

        [TestMethod()]        
        public void ConvertToJsonTest()
        {
            var card = UnitTestUtil.GetCreditCard();
            var jsonString = card.ConvertToJson();
            var credit = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.IsNotNull(credit);
        }

        [TestMethod()]
        public void CreditCardGetTest()
        {
            var card = UnitTestUtil.GetCreditCard();
            var createdCreditCard = card.Create(UnitTestUtil.GetApiContext());
            var retrievedCreditCard = CreditCard.Get(UnitTestUtil.GetApiContext(), createdCreditCard.id);
            Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
        }

        [TestMethod()]
        public void CreditCardDeleteTest()
        {
            var card = UnitTestUtil.GetCreditCard();
            var createdCreditCard = card.Create(UnitTestUtil.GetApiContext());
            var retrievedCreditCard = CreditCard.Get(UnitTestUtil.GetApiContext(), createdCreditCard.id);
            retrievedCreditCard.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod()]
        public void NullCreditCardIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => CreditCard.Get(UnitTestUtil.GetApiContext(), null));
        }
    }
}
