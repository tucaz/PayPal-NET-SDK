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
        public void WebProfileGetListTest()
        {
            // Create a new profile
            var apiContext = TestingUtil.GetApiContext();
            var profileName = Guid.NewGuid().ToString();
            var profile = WebProfileTest.GetWebProfile();
            profile.name = profileName;
            var createdProfile = profile.Create(apiContext);

            // Get the list of profiles
            var profiles = WebProfile.GetList(apiContext);
            Assert.IsNotNull(profiles);
            Assert.IsTrue(profiles.Count > 0);

            // Delete the profile
            profile.id = createdProfile.id;
            profile.Delete(apiContext);
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileCreateAndGetTest()
        {
            try
            {
                // Create the profile
                var apiContext = TestingUtil.GetApiContext();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = Guid.NewGuid().ToString();
                var response = profile.Create(apiContext);
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.id);

                // Get the profile
                var profileId = response.id;
                var retrievedProfile = WebProfile.Get(apiContext, profileId);
                Assert.AreEqual(profileId, retrievedProfile.id);

                // Delete the profile
                retrievedProfile.Delete(apiContext);
            }
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileUpdateTest()
        {
            try
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
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfilePartialUpdateTest()
        {
            try
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
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void WebProfileDeleteTest()
        {
            try
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
            catch (ConnectionException ex)
            {
                TestingUtil.WriteConnectionExceptionDetails(ex);
                throw;
            }
        }
    }
}
