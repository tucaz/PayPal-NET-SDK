using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;
using PayPal.Api;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class CreditCardTest
    {
        public static CreditCard GetCreditCard()
        {
            CreditCard card = new CreditCard();
            card.cvv2 = 962;
            card.expire_month = 01;
            card.expire_year = 2015;
            card.first_name = "John";
            card.last_name = "Doe";
            card.number = "4825854086744369";
            card.type = "visa";
            card.billing_address = AddressTest.GetAddress();
            return card;
        }

        public static CreditCard CreateCreditCard()
        {
            return GetCreditCard().Create(UnitTestUtil.GetApiContext());
        }

        [TestMethod()]
        public void CreditCardObjectTest()
        {
            var card = GetCreditCard();
            card.id = "002";
            card.external_customer_id = "008";
            var add = AddressTest.GetAddress();
            Assert.AreEqual(card.number, "4825854086744369");
            Assert.AreEqual(card.first_name, "John");
            Assert.AreEqual(card.last_name, "Doe");
            Assert.AreEqual(card.expire_month, 01);
            Assert.AreEqual(card.expire_year, 2015);
            Assert.AreEqual(card.cvv2, "962");
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
        public void CreditCardConvertToJsonTest()
        {
            var card = GetCreditCard();
            var jsonString = card.ConvertToJson();
            var credit = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.IsNotNull(credit);
        }

        [TestMethod()]
        public void CreditCardGetTest()
        {
            var card = GetCreditCard();
            var createdCreditCard = card.Create(UnitTestUtil.GetApiContext());
            var retrievedCreditCard = CreditCard.Get(UnitTestUtil.GetApiContext(), createdCreditCard.id);
            Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
        }

        [TestMethod()]
        public void CreditCardDeleteTest()
        {
            var card = GetCreditCard();
            var createdCreditCard = card.Create(UnitTestUtil.GetApiContext());
            var retrievedCreditCard = CreditCard.Get(UnitTestUtil.GetApiContext(), createdCreditCard.id);
            retrievedCreditCard.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod]
        public void CreditCardListTest()
        {
            var creditCardList = CreditCard.List(UnitTestUtil.GetApiContext(), startTime: "2014-11-01T19:27:56Z", endTime: "2014-12-25T19:27:56Z");
            Assert.IsNotNull(creditCardList);
            Assert.IsTrue(creditCardList.total_items > 0);
            Assert.IsTrue(creditCardList.total_pages > 0);
        }

        [TestMethod()]
        public void CreditCardNullIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => CreditCard.Get(UnitTestUtil.GetApiContext(), null));
        }
    }
}
