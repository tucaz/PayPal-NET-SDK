using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;
using System;

namespace RestApiSDKUnitTest
{
    /// <summary>
    /// Summary description for AgreementTest
    /// </summary>
    [TestClass]
    public class AgreementTest
    {
        public static readonly string AgreementJson =
            "{\"name\":\"T-Shirt of the Month Club Agreement\"," + 
            "\"description\":\"Agreement for T-Shirt of the Month Club Plan\"," +
            "\"start_date\":\"2015-02-19T00:37:04Z\"," +
            "\"plan\":" + PlanTest.PlanJson + "," +
            "\"payer\":{\"payment_method\":\"paypal\"}," +
            "\"shipping_address\":" + ShippingAddressTest.ShippingAddressJson + "}";

        public static Agreement GetAgreement()
        {
            return JsonFormatter.ConvertFromJson<Agreement>(AgreementJson);
        }

        [TestMethod()]
        public void AgreementObjectTest()
        {
            var testObject = GetAgreement();
            Assert.AreEqual("T-Shirt of the Month Club Agreement", testObject.name);
            Assert.AreEqual("Agreement for T-Shirt of the Month Club Plan", testObject.description);
            Assert.AreEqual("2015-02-19T00:37:04Z", testObject.start_date);
            Assert.IsNotNull(testObject.plan);
            Assert.IsNotNull(testObject.payer);
            Assert.IsNotNull(testObject.shipping_address);
        }

        [TestMethod()]
        public void AgreementConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreement().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void AgreementToStringTest()
        {
            Assert.IsFalse(GetAgreement().ToString().Length == 0);
        }

        [TestMethod()]
        public void AgreementCreateTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var agreement = GetAgreement();
            agreement.plan = new Plan() { id = "P-0V2939118D268823YFYLVH4Y" };
            agreement.shipping_address = null;
            var createdAgreement = agreement.Create(apiContext);
            Assert.IsNull(createdAgreement.id);
            Assert.IsNotNull(createdAgreement.token);
            Assert.AreEqual(agreement.name, createdAgreement.name);
        }

        [TestMethod()]
        public void AgreementGetTest()
        {
            var agreement = Agreement.Get(UnitTestUtil.GetApiContext(), "I-ASXCM9U5MJJV");
            Assert.AreEqual("I-ASXCM9U5MJJV", agreement.id);
            Assert.AreEqual("Agreement for T-Shirt of the Month Club Plan", agreement.description);
            Assert.AreEqual("2015-02-19T08:00:00Z", agreement.start_date);
            Assert.IsNotNull(agreement.plan);
        }

        [TestMethod()]
        public void AgreementExecuteTest()
        {
            var agreement = new Agreement() { token = "EC-2CD33889A9699491E" };
            var executedAgreement = agreement.Execute(UnitTestUtil.GetApiContext());
            Assert.AreEqual("I-ASXCM9U5MJJV", executedAgreement.id);
        }

        [TestMethod()]
        public void AgreementUpdateTest()
        {
            // Get the agreement to be used for verifying the update functionality
            var apiContext = UnitTestUtil.GetApiContext();
            var agreementId = "I-9STXMKR58UNN";
            var agreement = Agreement.Get(apiContext, agreementId);

            // Create an update for the agreement
            var updatedDescription = Guid.NewGuid().ToString();
            var patch = new Patch();
            patch.op = "replace";
            patch.path = "/";
            patch.value = new Agreement() { description = updatedDescription };
            var patchRequest = new PatchRequest();
            patchRequest.Add(patch);

            // Update the agreement
            agreement.Update(apiContext, patchRequest);

            // Verify the agreement was successfully updated
            var updatedAgreement = Agreement.Get(apiContext, agreementId);
            Assert.AreEqual(agreementId, updatedAgreement.id);
            Assert.AreEqual(updatedDescription, updatedAgreement.description);
        }

        [TestMethod()]
        public void AgreementSearchTest()
        {
            DateTime startDate = new DateTime(2014, 10, 1);
            DateTime endDate = new DateTime(2014, 10, 14);
            var transactions = Agreement.ListTransactions(UnitTestUtil.GetApiContext(), "I-9STXMKR58UNN", startDate, endDate);
            Assert.IsNotNull(transactions);
            Assert.IsNotNull(transactions.agreement_transaction_list);
        }

        /// <summary>
        /// The following tests are disabled due to them requiring an active billing agreement.
        /// </summary>
        [Ignore]
        public void AgreementSuspendTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var agreementId = "";
            var agreement = Agreement.Get(apiContext, agreementId);

            var agreementStateDescriptor = new AgreementStateDescriptor();
            agreementStateDescriptor.note = "Suspending the agreement.";
            agreement.Suspend(apiContext, agreementStateDescriptor);

            var suspendedAgreement = Agreement.Get(apiContext, agreementId);
        }

        [Ignore]
        public void AgreementReactivateTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var agreementId = "";
            var agreement = Agreement.Get(apiContext, agreementId);

            var agreementStateDescriptor = new AgreementStateDescriptor();
            agreementStateDescriptor.note = "Re-activating the agreement.";
            agreement.ReActivate(apiContext, agreementStateDescriptor);

            var reactivatedAgreement = Agreement.Get(apiContext, agreementId);
        }

        [Ignore]
        public void AgreementCancelTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var agreementId = "";
            var agreement = Agreement.Get(apiContext, agreementId);

            var agreementStateDescriptor = new AgreementStateDescriptor();
            agreementStateDescriptor.note = "Canceling the agreement.";
            agreement.Cancel(apiContext, agreementStateDescriptor);

            var canceledAgreement = Agreement.Get(apiContext, agreementId);
        }
    }
}
