using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using PayPal;
using System;

namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for PlanTest
    /// </summary>
    [TestClass]
    public class PlanTest
    {
        public static readonly string PlanJson = 
            "{\"name\":\"T-Shirt of the Month Club Plan\"," +
            "\"description\":\"Template creation.\"," +
            "\"type\":\"FIXED\"," +
            "\"payment_definitions\":[" + PaymentDefinitionTest.PaymentDefinitionJson + "]," +
            "\"merchant_preferences\":" + MerchantPreferencesTest.MerchantPreferencesJson + "}";

        public static Plan GetPlan()
        {
            return JsonFormatter.ConvertFromJson<Plan>(PlanJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void PlanObjectTest()
        {
            var testObject = GetPlan();
            Assert.AreEqual("T-Shirt of the Month Club Plan", testObject.name);
            Assert.AreEqual("Template creation.", testObject.description);
            Assert.AreEqual("FIXED", testObject.type);
            Assert.IsNotNull(testObject.payment_definitions);
            Assert.IsTrue(testObject.payment_definitions.Count == 1);
            Assert.IsNotNull(testObject.merchant_preferences);
        }

        [TestMethod, TestCategory("Unit")]
        public void PlanConvertToJsonTest()
        {
            Assert.IsFalse(GetPlan().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void PlanToStringTest()
        {
            Assert.IsFalse(GetPlan().ToString().Length == 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void PlanCreateTest()
        {
            try
            {
                var plan = GetPlan();
                var createdPlan = plan.Create(TestingUtil.GetApiContext());
                Assert.IsTrue(!string.IsNullOrEmpty(createdPlan.id));
                Assert.AreEqual(plan.name, createdPlan.name);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void PlanGetTest()
        {
            try
            {
                var plan = Plan.Get(TestingUtil.GetApiContext(), "P-0V2939118D268823YFYLVH4Y");
                Assert.IsNotNull(plan);
                Assert.AreEqual("T-Shirt of the Month Club Plan", plan.name);
                Assert.AreEqual("Template creation.", plan.description);
                Assert.AreEqual("FIXED", plan.type);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void PlanUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();

                // Get a test plan for updating purposes.
                var plan = GetPlan();
                var createdPlan = plan.Create(TestingUtil.GetApiContext());
                var planId = createdPlan.id;

                // Create the patch request and update the description to a random value.
                var updatedDescription = Guid.NewGuid().ToString();
                var patch = new Patch();
                patch.op = "replace";
                patch.path = "/";
                patch.value = new Plan() { description = updatedDescription };
                var patchRequest = new PatchRequest();
                patchRequest.Add(patch);

                // Update the plan.
                createdPlan.Update(apiContext, patchRequest);

                // Verify the plan was updated successfully.
                var updatedPlan = Plan.Get(apiContext, planId);
                Assert.AreEqual(planId, updatedPlan.id);
                Assert.AreEqual(updatedDescription, updatedPlan.description);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void PlanListTest()
        {
            try
            {
                var planList = Plan.List(TestingUtil.GetApiContext());
                Assert.IsNotNull(planList);
                Assert.IsNotNull(planList.plans);
                Assert.IsTrue(planList.plans.Count > 0);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void PlanDeleteTest()
        {
            try
            {
                var plan = GetPlan();
                var createdPlan = plan.Create(TestingUtil.GetApiContext());
                var planId = createdPlan.id;

                // Create a patch request that will delete the plan
                var patchRequest = new PatchRequest
                {
                    new Patch
                    {
                        op = "replace",
                        path = "/",
                        value = new Plan
                        {
                            state = "DELETED"
                        }
                    }
                };

                createdPlan.Update(TestingUtil.GetApiContext(), patchRequest);

                // Attempting to retrieve the plan should result in a PayPalException being thrown.
                TestingUtil.AssertThrownException<PaymentsException>(() => Plan.Get(TestingUtil.GetApiContext(), planId));
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }
    }
}
