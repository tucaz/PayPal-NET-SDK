using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.UnitTest
{
    /// <summary>
    /// Summary description for PlanListTest
    /// </summary>
    [TestClass]
    public class PlanListTest
    {
        public static readonly string PlanListJson = "{\"plans\":[" + PlanTest.PlanJson + "]}";

        public static PlanList GetPlanList()
        {
            return JsonFormatter.ConvertFromJson<PlanList>(PlanListJson);
        }

        [TestMethod()]
        public void PlanListObjectTest()
        {
            var testObject = GetPlanList();
            Assert.IsNotNull(testObject.plans);
            Assert.IsTrue(testObject.plans.Count == 1);
        }

        [TestMethod()]
        public void PlanListConvertToJsonTest()
        {
            Assert.IsFalse(GetPlanList().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void PlanListToStringTest()
        {
            Assert.IsFalse(GetPlanList().ToString().Length == 0);
        }
    }
}
