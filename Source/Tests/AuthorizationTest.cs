using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PayPal.Api;
using PayPal;

namespace PayPal.Testing
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

        [TestMethod, TestCategory("Unit")]
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

        [TestMethod, TestCategory("Unit")]
        public void AuthorizationConvertToJsonTest()
        {
            var authorize = GetAuthorization();
            Assert.IsFalse(authorize.ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void AuthorizationToStringTest()
        {
            var authorize = GetAuthorization();
            Assert.IsFalse(authorize.ToString().Length == 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void AuthorizationGetTest()
        {
            try
            {
                var pay = PaymentTest.CreatePaymentAuthorization();
                var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
                var authorize = Authorization.Get(TestingUtil.GetApiContext(), authorizationId);
                Assert.AreEqual(authorizationId, authorize.id);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void AuthorizationCaptureTest()
        {
            try
            {
                var pay = PaymentTest.CreatePaymentAuthorization();
                var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
                var authorize = Authorization.Get(TestingUtil.GetApiContext(), authorizationId);
                var cap = new Capture();
                var amt = new Amount();
                amt.total = "1";
                amt.currency = "USD";
                cap.amount = amt;
                var response = authorize.Capture(TestingUtil.GetApiContext(), cap);
                Assert.AreEqual("completed", response.state);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void AuthorizationVoidTest()
        {
            try
            {
                var pay = PaymentTest.CreatePaymentAuthorization();
                var authorizationId = pay.transactions[0].related_resources[0].authorization.id;
                var authorize = Authorization.Get(TestingUtil.GetApiContext(), authorizationId);
                var authorizationResponse = authorize.Void(TestingUtil.GetApiContext());
                Assert.AreEqual("voided", authorizationResponse.state);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void AuthorizationNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => Authorization.Get(new APIContext("token"), null));
        }

        [TestMethod, TestCategory("Functional")]
        public void AuthroizationReauthorizeTest()
        {
            try
            {
                var authorization = Authorization.Get(TestingUtil.GetApiContext(), "7GH53639GA425732B");
                var reauthorizeAmount = new Amount();
                reauthorizeAmount.currency = "USD";
                reauthorizeAmount.total = "1";
                authorization.amount = reauthorizeAmount;
                TestingUtil.AssertThrownException<PayPal.PaymentsException>(() => authorization.Reauthorize(TestingUtil.GetApiContext()));
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }
    }
}
