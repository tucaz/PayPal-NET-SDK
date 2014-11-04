using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;
using PayPal;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class AuthorizationTest
    {
        public static Authorization GetAuthorization()
        {
            Authorization authorize = new Authorization();
            authorize.amount = AmountTest.GetAmount();
            authorize.create_time = "2013-01-15T15:10:05.123Z";
            authorize.id = "007";
            authorize.parent_payment = "1000";
            authorize.state = "Authorized";
            authorize.links = LinksTest.GetLinksList();
            return authorize;
        }

        [TestMethod()]
        public void AuthorizationObjectTest()
        {
            var authorization = GetAuthorization();
            var expectedAmount = AmountTest.GetAmount();
            var actualAmount = authorization.amount;
            Assert.AreEqual(expectedAmount.currency, actualAmount.currency);
            Assert.AreEqual(expectedAmount.details.fee, actualAmount.details.fee);
            Assert.AreEqual(expectedAmount.details.shipping, actualAmount.details.shipping);
            Assert.AreEqual(expectedAmount.details.subtotal, actualAmount.details.subtotal);
            Assert.AreEqual(expectedAmount.details.tax, actualAmount.details.tax);
            Assert.AreEqual(expectedAmount.total, actualAmount.total);
            Assert.AreEqual(authorization.id, "007");
            Assert.AreEqual(authorization.create_time, "2013-01-15T15:10:05.123Z");
            Assert.AreEqual(authorization.parent_payment, "1000");
            Assert.AreEqual(authorization.state, "Authorized");
        }

        [TestMethod()]
        public void AuthorizationConvertToJsonTest()
        {
            var authorize = GetAuthorization();
            Assert.IsFalse(authorize.ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void AuthorizationToStringTest()
        {
            var authorize = GetAuthorization();
            Assert.IsFalse(authorize.ToString().Length == 0);
        }

        [TestMethod()]
        public void AuthorizationGetTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorize = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            Assert.AreEqual(authorizationId, authorize.id);
        }

        [TestMethod()]
        public void AuthorizationCaptureTest()
        {
            var pay = PaymentTest.CreatePaymentAuthorization();
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
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            var authorize = Authorization.Get(UnitTestUtil.GetApiContext(), authorizationId);
            var authorizationResponse = authorize.Void(UnitTestUtil.GetApiContext());
            Assert.AreEqual("voided", authorizationResponse.state);
        }

        [TestMethod()]
        public void AuthorizationNullAccessTokenTest()
        {
            string token = null;
            var pay = PaymentTest.CreatePaymentAuthorization();
            var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Authorization.Get(token, authorizationId));
        }

        [TestMethod()]
        public void AuthorizationNullIdTest()
        {
            UnitTestUtil.AssertThrownException<System.ArgumentNullException>(() => Authorization.Get(UnitTestUtil.GetApiContext(), null));
        }

        [TestMethod]
        public void AuthroizationReauthorizeTest()
        {
            var authorization = Authorization.Get(UnitTestUtil.GetApiContext(), "7GH53639GA425732B");
            var reauthorizeAmount = new Amount();
            reauthorizeAmount.currency = "USD";
            reauthorizeAmount.total = "1";
            authorization.amount = reauthorizeAmount;
            UnitTestUtil.AssertThrownException<PayPal.HttpException>(() => authorization.Reauthorize(UnitTestUtil.GetApiContext()));
        }
    }
}
