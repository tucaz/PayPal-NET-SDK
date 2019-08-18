using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class RelatedResourcesTest
    {
        public static RelatedResources GetRelatedResources()
        {
            RelatedResources resources = new RelatedResources();
            resources.authorization = AuthorizationTest.GetAuthorization();
            resources.capture = CaptureTest.GetCapture();
            resources.refund = RefundTest.GetRefund();
            resources.sale = SaleTest.GetSale();
            resources.order = OrderTest.GetOrder();
            return resources;
        }

        [Fact, Trait("Category", "Unit")]
        public void RelatedResourcesObjectTest() 
        {
            var resources = GetRelatedResources();
            Assert.Equal(resources.authorization.id, AuthorizationTest.GetAuthorization().id);
            Assert.Equal(resources.sale.id, SaleTest.GetSale().id);
            Assert.Equal(resources.refund.id, RefundTest.GetRefund().id);
            Assert.Equal(resources.capture.id, CaptureTest.GetCapture().id);
        }

        [Fact, Trait("Category", "Unit")]
        public void RelatedResourcesConvertToJsonTest() 
        {
            Assert.False(GetRelatedResources().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void RelatedResourcesToStringTest() 
        {
            Assert.False(GetRelatedResources().ToString().Length == 0);
        }
    }
}
