
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace PayPal.Api.Tests
{
    
    public class TemplateTest
    {
        public static readonly string TemplateJson =
            "{" +
"  \"name\": \"Hours Template\"," +
"  \"default\": true," +
"  \"unit_of_measure\": \"Hours\"," +
"  \"template_data\": {" +
"    \"items\": [" +
"      {" +
"        \"name\": \"Nutri Bullet\"," +
"        \"quantity\": 1," +
"        \"unit_price\": {" +
"          \"currency\": \"USD\"," +
"          \"value\": \"50.00\"" +
"        }" +
"}" +
"    ]," +
"    \"merchant_info\": {" +
"      \"email\": \"jaypatel512-facilitator@hotmail.com\"" +
"    }," +
"    \"tax_calculated_after_discount\": false," +
"    \"tax_inclusive\": false," +
"    \"note\": \"Thank you for your business.\"," +
"    \"logo_url\": \"https://pics.paypal.com/v1/images/redDot.jpeg\"" +
"  }," +
"  \"settings\": [" +
"    {" +
"      \"field_name\": \"items.date\"," +
"      \"display_preference\": {" +
"        \"hidden\": true" +
"      }" +
"    }," +
"    {" +
"      \"field_name\": \"custom\"," +
"      \"display_preference\": {" +
"        \"hidden\": true" +
"      }" +
"    }" +
"  ]" +
"}";

        public static InvoiceTemplate GetTemplate()
        {
            return JsonFormatter.ConvertFromJson<InvoiceTemplate>(TemplateJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void TemplateObjectTest()
        {
            var template = GetTemplate();
            Assert.Equal(true, template.@default);
            Assert.Equal("Hours Template", template.name);
            Assert.Equal(1, template.template_data.items.Count);

            var template_data = template.template_data.items[0];
            Assert.Equal("Nutri Bullet", template_data.name);
            Assert.Equal(1, template_data.quantity);

            Assert.Equal(false, template.template_data.tax_calculated_after_discount);
            Assert.Equal(false, template.template_data.tax_inclusive);
            Assert.Equal("Thank you for your business.", template.template_data.note);

            Assert.Equal(2, template.settings.Count);
            var settings = template.settings[0];
            Assert.Equal("items.date", settings.field_name);
            Assert.Equal(true, settings.display_preference.hidden);

            settings = template.settings[1];
            Assert.Equal("custom", settings.field_name);
        }
    }
}
