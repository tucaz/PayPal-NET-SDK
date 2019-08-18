using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class InputFieldsTest
    {
        public static readonly string InputFieldsJson = "{\"allow_note\": true, \"no_shipping\": 0, \"address_override\": 1}";

        public static InputFields GetInputFields()
        {
            return JsonFormatter.ConvertFromJson<InputFields>(InputFieldsJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void InputFieldsObjectTest()
        {
            var inputFields = GetInputFields();
            Assert.True(inputFields.allow_note.Value);
            Assert.Equal(0, inputFields.no_shipping);
            Assert.Equal(1, inputFields.address_override);
        }

        [Fact, Trait("Category", "Unit")]
        public void InputFieldsConvertToJsonTest()
        {
            Assert.False(GetInputFields().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void InputFieldsToStringTest()
        {
            Assert.False(GetInputFields().ToString().Length == 0);
        }
    }
}
