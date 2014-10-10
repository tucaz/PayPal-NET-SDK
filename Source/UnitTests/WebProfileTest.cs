using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;
using PayPal;
using System;

namespace RestApiSDKUnitTest
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

        [TestMethod()]
        public void WebProfileObjectTest()
        {
            var webProfile = GetWebProfile();
            Assert.AreEqual("Test profile", webProfile.name);
            Assert.IsNotNull(webProfile.presentation);
            Assert.IsNotNull(webProfile.input_fields);
            Assert.IsNotNull(webProfile.flow_config);
        }

        [TestMethod()]
        public void WebProfileConvertToJsonTest()
        {
            Assert.IsFalse(GetWebProfile().ConvertToJson().Length == 0);
        }

        [TestMethod()]
        public void WebProfileToStringTest()
        {
            Assert.IsFalse(GetWebProfile().ToString().Length == 0);
        }

        [TestMethod()]
        public void WebProfileGetTest()
        {
            var profileId = "XP-VKRN-ZPNE-AXGJ-YFZM";
            var profile = WebProfile.Get(UnitTestUtil.GetApiContext(), profileId);
            Assert.AreEqual(profileId, profile.id);
        }

        [TestMethod()]
        public void WebProfileGetListTest()
        {
            var profiles = WebProfile.GetList(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(profiles);
            Assert.IsTrue(profiles.Count > 0);
        }

        [TestMethod()]
        public void WebProfileCreateTest()
        {
            var profile = WebProfileTest.GetWebProfile();
            profile.name = Guid.NewGuid().ToString();
            var response = profile.Create(UnitTestUtil.GetApiContext());
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.id);

            // Delete the profile
            profile = WebProfile.Get(UnitTestUtil.GetApiContext(), response.id);
            profile.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod()]
        public void WebProfileUpdateTest()
        {
            // Create a new profile
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(UnitTestUtil.GetApiContext());
            
            // Get the profile object for the new profile
            profile = WebProfile.Get(UnitTestUtil.GetApiContext(), createdProfile.id);

            // Update the profile
            var newName = "New " + profileName;
            profile.name = newName;
            profile.Update(UnitTestUtil.GetApiContext());

            // Get the profile again and verify it was successfully updated.
            var retrievedProfile = WebProfile.Get(UnitTestUtil.GetApiContext(), profile.id);
            Assert.AreEqual(newName, retrievedProfile.name);

            // Delete the profile
            profile.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod()]
        public void WebProfilePartialUpdateTest()
        {
            // Create a new profile
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(UnitTestUtil.GetApiContext());

            // Get the profile object for the new profile
            profile = WebProfile.Get(UnitTestUtil.GetApiContext(), createdProfile.id);

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

            profile.PartialUpdate(UnitTestUtil.GetApiContext(), patchRequest);

            // Get the profile again and verify it was successfully updated via the patch commands.
            var retrievedProfile = WebProfile.Get(UnitTestUtil.GetApiContext(), profile.id);
            Assert.AreEqual(newName, retrievedProfile.presentation.brand_name);
            Assert.IsTrue(string.IsNullOrEmpty(retrievedProfile.flow_config.landing_page_type));

            // Delete the profile
            profile.Delete(UnitTestUtil.GetApiContext());
        }

        [TestMethod()]
        public void WebProfileDeleteTest()
        {
            // Create a new profile
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(UnitTestUtil.GetApiContext());

            // Get the profile object for the new profile
            profile = WebProfile.Get(UnitTestUtil.GetApiContext(), createdProfile.id);

            // Delete the profile
            profile.Delete(UnitTestUtil.GetApiContext());

            // Attempt to get the profile. This should result in an exception.
            UnitTestUtil.AssertThrownException<PayPal.Exception.HttpException>(() => { WebProfile.Get(UnitTestUtil.GetApiContext(), profile.id); });
        }
    }
}
