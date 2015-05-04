using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System;

namespace PayPal.Testing
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
            "\"start_date\":\"2016-02-19T00:37:04Z\"," +
            "\"plan\":" + PlanTest.PlanJson + "," +
            "\"payer\":{\"payment_method\":\"paypal\"}," +
            "\"shipping_address\":" + ShippingAddressTest.ShippingAddressJson + "}";

        public static Agreement GetAgreement()
        {
            return JsonFormatter.ConvertFromJson<Agreement>(AgreementJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void AgreementObjectTest()
        {
            var testObject = GetAgreement();
            Assert.AreEqual("T-Shirt of the Month Club Agreement", testObject.name);
            Assert.AreEqual("Agreement for T-Shirt of the Month Club Plan", testObject.description);
            Assert.AreEqual("2016-02-19T00:37:04Z", testObject.start_date);
            Assert.IsNotNull(testObject.plan);
            Assert.IsNotNull(testObject.payer);
            Assert.IsNotNull(testObject.shipping_address);
        }

        [TestMethod, TestCategory("Unit")]
        public void AgreementConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreement().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void AgreementToStringTest()
        {
            Assert.IsFalse(GetAgreement().ToString().Length == 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void AgreementCreateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();

                // Create a new plan.
                var plan = PlanTest.GetPlan();
                var createdPlan = plan.Create(apiContext);

                // Activate the plan.
                var patchRequest = new PatchRequest()
                {
                    new Patch()
                    {
                        op = "replace",
                        path = "/",
                        value = new Plan() { state = "ACTIVE" }
                    }
                };
                createdPlan.Update(apiContext, patchRequest);

                // Create an agreement using the activated plan.
                var agreement = GetAgreement();
                agreement.plan = new Plan() { id = createdPlan.id };
                agreement.shipping_address = null;
                var createdAgreement = agreement.Create(apiContext);
                Assert.IsNull(createdAgreement.id);
                Assert.IsNotNull(createdAgreement.token);
                Assert.AreEqual(agreement.name, createdAgreement.name);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [Ignore]
        public void AgreementGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                var agreement = new Agreement() { token = "EC-2CD33889A9699491E" };
                var executedAgreement = agreement.Execute(apiContext);
                var agreementId = executedAgreement.id;
                var retrievedAgreement = Agreement.Get(apiContext, agreementId);
                Assert.AreEqual(agreementId, retrievedAgreement.id);
                Assert.AreEqual("-6514356286402072739", retrievedAgreement.description);
                Assert.AreEqual("2015-02-19T08:00:00Z", retrievedAgreement.start_date);
                Assert.IsNotNull(retrievedAgreement.plan);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [Ignore]
        public void AgreementExecuteTest()
        {
            try
            {
                var agreement = new Agreement() { token = "EC-2CD33889A9699491E" };
                var executedAgreement = agreement.Execute(TestingUtil.GetApiContext());
                Assert.AreEqual("I-ASXCM9U5MJJV", executedAgreement.id);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [Ignore]
        public void AgreementUpdateTest()
        {
            try
            {
                // Get the agreement to be used for verifying the update functionality
                var apiContext = TestingUtil.GetApiContext();
                var agreementId = "I-HP4H4YJFCN07";
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
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void AgreementSearchTest()
        {
            try
            {
                var startDate = "2014-10-01";
                var endDate = "2014-10-14";
                var transactions = Agreement.ListTransactions(TestingUtil.GetApiContext(), "I-9STXMKR58UNN", startDate, endDate);
                Assert.IsNotNull(transactions);
                Assert.IsNotNull(transactions.agreement_transaction_list);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        /// <summary>
        /// The following tests are disabled due to them requiring an active billing agreement.
        /// </summary>
        [Ignore]
        public void AgreementSuspendTest()
        {
            var apiContext = TestingUtil.GetApiContext();
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
            var apiContext = TestingUtil.GetApiContext();
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
            var apiContext = TestingUtil.GetApiContext();
            var agreementId = "";
            var agreement = Agreement.Get(apiContext, agreementId);

            var agreementStateDescriptor = new AgreementStateDescriptor();
            agreementStateDescriptor.note = "Canceling the agreement.";
            agreement.Cancel(apiContext, agreementStateDescriptor);

            var canceledAgreement = Agreement.Get(apiContext, agreementId);
        }
    }
}
