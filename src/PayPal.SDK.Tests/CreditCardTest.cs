
using PayPal;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class CreditCardTest : BaseTest
    {
        public static readonly string CreditCardJson = "{" +
            "\"cvv2\": \"962\"," +
            "\"expire_month\": 01," +
            "\"expire_year\": 2024," +
            "\"first_name\": \"John\"," +
            "\"last_name\": \"Doe\"," +
            "\"number\": \"4449335840161468\"," +
            "\"type\": \"visa\"," +
            "\"billing_address\": " + AddressTest.AddressJson + "}";

        public static CreditCard GetCreditCard()
        {
            return JsonFormatter.ConvertFromJson<CreditCard>(CreditCardJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void CreditCardObjectTest()
        {
            var card = GetCreditCard();
            Assert.Equal("4449335840161468", card.number);
            Assert.Equal("John", card.first_name);
            Assert.Equal("Doe", card.last_name);
            Assert.Equal(01, card.expire_month);
            Assert.Equal(2024, card.expire_year);
            Assert.Equal("962", card.cvv2);
            Assert.Equal("visa", card.type);
            Assert.NotNull(card.billing_address);
        }

        [Fact, Trait("Category", "Unit")]        
        public void CreditCardConvertToJsonTest()
        {
            var card = GetCreditCard();
            var jsonString = card.ConvertToJson();
            var credit = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.NotNull(credit);
        }

        [Fact, Trait("Category", "Functional")]
        public void CreditCardGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var card = GetCreditCard();
                var createdCreditCard = card.Create(apiContext);
                this.RecordConnectionDetails();

                var retrievedCreditCard = CreditCard.Get(apiContext, createdCreditCard.id);
                this.RecordConnectionDetails();

                Assert.Equal(createdCreditCard.id, retrievedCreditCard.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void CreditCardDeleteTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var card = GetCreditCard();
                var createdCreditCard = card.Create(apiContext);
                this.RecordConnectionDetails();

                var retrievedCreditCard = CreditCard.Get(apiContext, createdCreditCard.id);
                this.RecordConnectionDetails();

                retrievedCreditCard.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact(Skip="Ignore")]
        public void CreditCardListTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var creditCardList = CreditCard.List(apiContext, startTime: "2014-11-01T19:27:56Z", endTime: "2014-12-25T19:27:56Z");
                this.RecordConnectionDetails();

                Assert.NotNull(creditCardList);
                Assert.True(creditCardList.total_items > 0);
                Assert.True(creditCardList.total_pages > 0);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void CreditCardUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var creditCard = GetCreditCard().Create(apiContext);
                this.RecordConnectionDetails();

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

                var updatedCreditCard = creditCard.Update(apiContext, patchRequest);
                this.RecordConnectionDetails();

                // Retrieve the credit card details from the vault and verify the
                // billing address was updated properly.
                var retrievedCreditCard = CreditCard.Get(apiContext, updatedCreditCard.id);
                this.RecordConnectionDetails();

                Assert.NotNull(retrievedCreditCard);
                Assert.NotNull(retrievedCreditCard.billing_address);
                Assert.Equal("111 First Street", retrievedCreditCard.billing_address.line1);
                Assert.Equal("Saratoga", retrievedCreditCard.billing_address.city);
                Assert.Equal("US", retrievedCreditCard.billing_address.country_code);
                Assert.Equal("CA", retrievedCreditCard.billing_address.state);
                Assert.Equal("95070", retrievedCreditCard.billing_address.postal_code);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void CreditCardNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => CreditCard.Get(new APIContext("token"), null));
        }
    }
}
