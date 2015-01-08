using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System;

namespace PayPal.Testing
{
    [TestClass]
    public class WebProfileTest
    {
        public static readonly string WebProfileJson =
            "{\"name\": \"Test profile\"," +
            "\"presentation\": " + PresentationTest.PresentationJson + "," +
            "\"input_fields\": " + InputFieldsTest.InputFieldsJson + "," +
            "\"flow_config\":" + FlowConfigTest.FlowConfigJson + "}";

        public static WebProfile GetWebProfile()
        {
            return JsonFormatter.ConvertFromJson<WebProfile>(WebProfileJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebProfileObjectTest()
        {
            var webProfile = GetWebProfile();
            Assert.AreEqual("Test profile", webProfile.name);
            Assert.IsNotNull(webProfile.presentation);
            Assert.IsNotNull(webProfile.input_fields);
            Assert.IsNotNull(webProfile.flow_config);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebProfileConvertToJsonTest()
        {
            Assert.IsFalse(GetWebProfile().ConvertToJson().Length == 0);
        }

        [TestMethod, TestCategory("Unit")]
        public void WebProfileToStringTest()
        {
            Assert.IsFalse(GetWebProfile().ToString().Length == 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileGetTest()
        {
            var profileId = "XP-5CQ3-3XSL-DDAA-MATK";
            var profile = WebProfile.Get(TestingUtil.GetApiContext(), profileId);
            Assert.AreEqual(profileId, profile.id);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileGetListTest()
        {
            var profiles = WebProfile.GetList(TestingUtil.GetApiContext());
            Assert.IsNotNull(profiles);
            Assert.IsTrue(profiles.Count > 0);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileCreateTest()
        {
            var profile = WebProfileTest.GetWebProfile();
            profile.name = Guid.NewGuid().ToString();
            var response = profile.Create(TestingUtil.GetApiContext());
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.id);

            // Delete the profile
            profile = WebProfile.Get(TestingUtil.GetApiContext(), response.id);
            profile.Delete(TestingUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileUpdateTest()
        {
            // Create a new profile
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(TestingUtil.GetApiContext());
            
            // Get the profile object for the new profile
            profile = WebProfile.Get(TestingUtil.GetApiContext(), createdProfile.id);

            // Update the profile
            var newName = "New " + profileName;
            profile.name = newName;
            profile.Update(TestingUtil.GetApiContext());

            // Get the profile again and verify it was successfully updated.
            var retrievedProfile = WebProfile.Get(TestingUtil.GetApiContext(), profile.id);
            Assert.AreEqual(newName, retrievedProfile.name);

            // Delete the profile
            profile.Delete(TestingUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfilePartialUpdateTest()
        {
            // Create a new profile
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(TestingUtil.GetApiContext());

            // Get the profile object for the new profile
            profile = WebProfile.Get(TestingUtil.GetApiContext(), createdProfile.id);

            // Partially update the profile
            var newName = "New " + profileName;
            var patch1 = new Patch();
            patch1.op = "add";
            patch1.path = "/presentation/brand_name";
            patch1.value = newName;

            var patch2 = new Patch();
            patch2.op = "remove";
            patch2.path = "/flow_config/landing_page_type";

            var patchRequest = new PatchRequest();
            patchRequest.Add(patch1);
            patchRequest.Add(patch2);

            profile.PartialUpdate(TestingUtil.GetApiContext(), patchRequest);

            // Get the profile again and verify it was successfully updated via the patch commands.
            var retrievedProfile = WebProfile.Get(TestingUtil.GetApiContext(), profile.id);
            Assert.AreEqual(newName, retrievedProfile.presentation.brand_name);
            Assert.IsTrue(string.IsNullOrEmpty(retrievedProfile.flow_config.landing_page_type));

            // Delete the profile
            profile.Delete(TestingUtil.GetApiContext());
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileDeleteTest()
        {
            // Create a new profile
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(TestingUtil.GetApiContext());

            // Get the profile object for the new profile
            profile = WebProfile.Get(TestingUtil.GetApiContext(), createdProfile.id);

            // Delete the profile
            profile.Delete(TestingUtil.GetApiContext());

            // Attempt to get the profile. This should result in an exception.
            TestingUtil.AssertThrownException<PayPal.HttpException>(() => { WebProfile.Get(TestingUtil.GetApiContext(), profile.id); });
        }
    }
}
