using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api.Payments;
using PayPal;

namespace RestApiSDKUnitTest
{
    [TestClass()]
    public class AuthorizationTest
    {
        [TestMethod()]
        public void TestAuthorization()
        {
            var authorize = UnitTestUtil.GetAuthorization();
            var expected = UnitTestUtil.GetAmount();
            var actual = authorize.amount;
            Assert.AreEqual(expected.currency, actual.currency);
            Assert.AreEqual(expected.details.fee, actual.details.fee);
            Assert.AreEqual(expected.details.shipping, actual.details.shipping);
            Assert.AreEqual(expected.details.subtotal, actual.details.subtotal);
            Assert.AreEqual(expected.details.tax, actual.details.tax);
            Assert.AreEqual(expected.total, actual.total);
            Assert.AreEqual(authorize.id, "007");
            Assert.AreEqual(authorize.create_time, "2013-01-15T15:10:05.123Z");
            Assert.AreEqual(authorize.parent_payment, "1000");
            Assert.AreEqual(authorize.state, "Authorized");
        }

        [TestMethod()]
        public void ConvertToJsonTest()
        {
            var authorize = UnitTestUtil.GetAuthorization();
            Assert.IsFalse(authorize.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var authorize = UnitTestUtil.GetAuthorization();
            Assert.IsFalse(authorize.ToString().Length == 0);
        }

        [TestMethod()]
        public void AuthorizationGetTest()
        {
            var pay = UnitTestUtil.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorize = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            Assert.AreEqual(authorizationId, authorize.id);
        }

        [TestMethod()]
        public void AuthorizationCaptureTest()
        {
            var pay = UnitTestUtil.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorize = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            var cap = new Capture();
            var amt = new Amount();
            amt.total = "1";
            amt.currency = "USD";
            cap.amount = amt;
            var response = authorize.Capture(UnitTestUtil.GetApiContext(), cap);
            Assert.AreEqual("completed", response.state);
        }

        [TestMethod()]
        public void AuthorizationVoidTest()
        {
            var pay = UnitTestUtil.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorize = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            var authorizationResponse = authorize.Void(UnitTestUtil.GetApiContext());
            Assert.AreEqual("voided", authorizationResponse.state);
        }

        [TestMethod()]
        public void NullAccessTokenTest()
        {
            string token = null;
            var pay = UnitTestUtil.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Authorization.Get(token, authorizationId));
        }

        [TestMethod()]
        public void NullAuthorizationIdTest()
        {
            string authorizationId = null;
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId));
        }
    }
}
