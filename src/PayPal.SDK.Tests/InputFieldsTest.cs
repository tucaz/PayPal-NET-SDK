using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;

namespace PayPal.Testing
{
    [TestClass]
    public class InputFieldsTest
    {
        public static readonly string InputFieldsJson = "{\"allow_note\": true, \"no_shipping\": 0, \"address_override\": 1}";

        public static InputFields GetInputFields()
        {
            return JsonFormatter.ConvertFromJson<InputFields>(InputFieldsJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void InputFieldsObjectTest()
        {
            var inputFields = GetInputFields();
            Assert.IsTrue(inputFields.allow_note.Value);
            Assert.AreEqual(0, inputFields.no_shipping);
            Assert.AreEqual(1, inputFields.address_override);
        }

        [TestMethod, TestCategory("Unit")]
        public void InputFieldsConvertToJsonTest()
        {
            Assert.IsFalse(GetInputFields().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void InputFieldsToStringTest()
        {
            Assert.IsFalse(GetInputFields().ToString().Length == 0);
        }
    }
}
