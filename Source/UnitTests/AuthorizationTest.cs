using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;
using PayPal;

namespace PayPal.UnitTest
{
    [TestClass()]
    public class AuthorizationTest
    {
        public static readonly string AuthorizationJson =
            "{\"amount\":" + AmountTest.AmountJson + "," +
            "\"create_time\":\"2013-01-15T15:10:05.123Z\"," +
            "\"id\":\"007\"," +
            "\"parent_payment\":\"1000\"," +
            "\"state\":\"Authorized\"," +
            "\"links\":[" + LinksTest.LinksJson + "]}";

        public static Authorization GetAuthorization()
        {
            return JsonFormatter.ConvertFromJson<Authorization>(AuthorizationJson);
        }

        [TestMethod()]
        public void AuthorizationObjectTest()
        {
            var authorization = GetAuthorization();
            Assert.AreEqual(authorization.id, "007");
            Assert.AreEqual(authorization.create_time, "2013-01-15T15:10:05.123Z");
            Assert.AreEqual(authorization.parent_payment, "1000");
            Assert.AreEqual(authorization.state, "Authorized");
            Assert.IsNotNull(authorization.amount);
            Assert.IsNotNull(authorization.links);
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
            UnitTestUtil.AssertThrownException<PayPal.PaymentsException>(() => authorization.Reauthorize(UnitTestUtil.GetApiContext()));
        }
    }
}
