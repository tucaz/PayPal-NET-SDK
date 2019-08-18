using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    /// <summary>
    /// Summary description for PlanListTest
    /// </summary>
    
    public class PlanListTest
    {
        public static readonly string PlanListJson = "{\"plans\":[" + PlanTest.PlanJson + "]}";

        public static PlanList GetPlanList()
        {
            return JsonFormatter.ConvertFromJson<PlanList>(PlanListJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void PlanListObjectTest()
        {
            var testObject = GetPlanList();
            Assert.NotNull(testObject.plans);
            Assert.True(testObject.plans.Count == 1);
        }

        [Fact, Trait("Category", "Unit")]
        public void PlanListConvertToJsonTest()
        {
            Assert.False(GetPlanList().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void PlanListToStringTest()
        {
            Assert.False(GetPlanList().ToString().Length == 0);
        }
    }
}
