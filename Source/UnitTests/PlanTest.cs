using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using PayPal;
using System;

namespace PayPal.UnitTest
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

        [TestMethod()]
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

        [TestMethod()]
        public void PlanConvertToJsonTest()
        {
            Assert.IsFalse(GetPlan().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PlanToStringTest()
        {
            Assert.IsFalse(GetPlan().ToString().Length == 0);
        }

        [TestMethod()]
        public void PlanCreateTest()
        {
            var plan = GetPlan();
            var createdPlan = plan.Create(UnitTestUtil.GetApiContext());
            Assert.IsTrue(!string.IsNullOrEmpty(createdPlan.id));
            Assert.AreEqual(plan.name, createdPlan.name);
        }

        [TestMethod()]
        public void PlanGetTest()
        {
            var plan = Plan.Get(UnitTestUtil.GetApiContext(), "P-0V2939118D268823YFYLVH4Y");
            Assert.IsNotNull(plan);
            Assert.AreEqual("T-Shirt of the Month Club Plan", plan.name);
            Assert.AreEqual("Template creation.", plan.description);
            Assert.AreEqual("FIXED", plan.type);
        }

        [TestMethod()]
        public void PlanUpdateTest()
        {
            var apiContext = UnitTestUtil.GetApiContext();
            var planId = "P-7R813789P6651091RFYXDDLY";

            // Get a test plan for updating purposes.
            var plan = Plan.Get(apiContext, planId);

            // Create the patch request and update the description to a random value.
            var updatedDescription = Guid.NewGuid().ToString();
            var patch = new Patch();
            patch.op = "replace";
            patch.path = "/";
            patch.value = new Plan() { description = updatedDescription };
            var patchRequest = new PatchRequest();
            patchRequest.Add(patch);

            // Update the plan.
            plan.Update(apiContext, patchRequest);

            // Verify the plan was updated successfully.
            var updatedPlan = Plan.Get(apiContext, planId);
            Assert.AreEqual(planId, updatedPlan.id);
            Assert.AreEqual(updatedDescription, updatedPlan.description);
        }

        [TestMethod()]
        public void PlanListTest()
        {
            var planList = Plan.List(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(planList);
            Assert.IsNotNull(planList.plans);
            Assert.IsTrue(planList.plans.Count > 0);
        }

        [TestMethod]
        public void PlanDeleteTest()
        {
            var plan = GetPlan();
            var createdPlan = plan.Create(UnitTestUtil.GetApiContext());
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

            createdPlan.Update(UnitTestUtil.GetApiContext(), patchRequest);

            // Attempting to retrieve the plan should result in a PayPalException being thrown.
            UnitTestUtil.AssertThrownException<PaymentsException>(() => Plan.Get(UnitTestUtil.GetApiContext(), planId));
        }
    }
}
