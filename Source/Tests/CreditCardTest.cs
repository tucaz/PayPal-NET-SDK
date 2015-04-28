using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass()]
    public class CreditCardTest
    {
        public static readonly string CreditCardJson = "{" +
            "\"cvv2\": \"962\"," +
            "\"expire_month\": 01," +
            "\"expire_year\": 2018," +
            "\"first_name\": \"John\"," +
            "\"last_name\": \"Doe\"," +
            "\"number\": \"4449335840161468\"," +
            "\"type\": \"visa\"," +
            "\"billing_address\": " + AddressTest.AddressJson + "}";

        public static CreditCard GetCreditCard()
        {
            return JsonFormatter.ConvertFromJson<CreditCard>(CreditCardJson);
        }

        public static CreditCard CreateCreditCard()
        {
            return GetCreditCard().Create(TestingUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Unit")]
        public void CreditCardObjectTest()
        {
            var card = GetCreditCard();
            Assert.AreEqual("4449335840161468", card.number);
            Assert.AreEqual("John", card.first_name);
            Assert.AreEqual("Doe", card.last_name);
            Assert.AreEqual(01, card.expire_month);
            Assert.AreEqual(2018, card.expire_year);
            Assert.AreEqual("962", card.cvv2);
            Assert.AreEqual("visa", card.type);
            Assert.IsNotNull(card.billing_address);
        }

        [TestMethod, TestCategory("Unit")]        
        public void CreditCardConvertToJsonTest()
        {
            var card = GetCreditCard();
            var jsonString = card.ConvertToJson();
            var credit = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.IsNotNull(credit);
        }

        [TestMethod, TestCategory("Functional")]
        public void CreditCardGetTest()
        {
            var card = GetCreditCard();
            var createdCreditCard = card.Create(TestingUtil.GetApiContext());
            var retrievedCreditCard = CreditCard.Get(TestingUtil.GetApiContext(), createdCreditCard.id);
            Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
        }

        [TestMethod, TestCategory("Functional")]
        public void CreditCardDeleteTest()
        {
            try
            {
                var card = GetCreditCard();
                var createdCreditCard = card.Create(TestingUtil.GetApiContext());
                var retrievedCreditCard = CreditCard.Get(TestingUtil.GetApiContext(), createdCreditCard.id);
                retrievedCreditCard.Delete(TestingUtil.GetApiContext());
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void CreditCardListTest()
        {
            try
            {
                var creditCardList = CreditCard.List(TestingUtil.GetApiContext(), startTime: "2014-11-01T19:27:56Z", endTime: "2014-12-25T19:27:56Z");
                Assert.IsNotNull(creditCardList);
                Assert.IsTrue(creditCardList.total_items > 0);
                Assert.IsTrue(creditCardList.total_pages > 0);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void CreditCardUpdateTest()
        {
            try
            {
                var creditCard = CreateCreditCard();

                // Create a patch request to update the credit card.
                var patchRequest = new PatchRequest
            {
                new Patch
                {
                    op = "replace",
                    path = "/billing_address",
                    value = new Address
                    {
                        line1 = "111 First Street",
                        city = "Saratoga",
                        country_code = "US",
                        state = "CA",
                        postal_code = "95070"
                    }
                }
            };

                var apiContext = TestingUtil.GetApiContext();
                var updatedCreditCard = creditCard.Update(apiContext, patchRequest);

                // Retrieve the credit card details from the vault and verify the
                // billing address was updated properly.
                var retrievedCreditCard = CreditCard.Get(apiContext, updatedCreditCard.id);
                Assert.IsNotNull(retrievedCreditCard);
                Assert.IsNotNull(retrievedCreditCard.billing_address);
                Assert.AreEqual("111 First Street", retrievedCreditCard.billing_address.line1);
                Assert.AreEqual("Saratoga", retrievedCreditCard.billing_address.city);
                Assert.AreEqual("US", retrievedCreditCard.billing_address.country_code);
                Assert.AreEqual("CA", retrievedCreditCard.billing_address.state);
                Assert.AreEqual("95070", retrievedCreditCard.billing_address.postal_code);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void CreditCardNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => CreditCard.Get(new APIContext("token"), null));
        }
    }
}
