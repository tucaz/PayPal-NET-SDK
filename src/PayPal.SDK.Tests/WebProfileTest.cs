using PayPal.Api;
using System;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebProfileTest : BaseTest
    {
        public static readonly string WebProfileJson =
            "{\"name\": \"Test profile\"," +
            "\"presentation\": " + PresentationTest.PresentationJson + "," +
            "\"input_fields\": " + InputFieldsTest.InputFieldsJson + "," +
            "\"flow_config\":" + FlowConfigTest.FlowConfigJson + "," +
            "\"temporary\":true}";

        public static WebProfile GetWebProfile()
        {
            return JsonFormatter.ConvertFromJson<WebProfile>(WebProfileJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebProfileObjectTest()
        {
            var webProfile = GetWebProfile();
            Assert.Equal("Test profile", webProfile.name);
            Assert.NotNull(webProfile.presentation);
            Assert.NotNull(webProfile.input_fields);
            Assert.NotNull(webProfile.flow_config);
            Assert.Equal(true, webProfile.temporary);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebProfileConvertToJsonTest()
        {
            Assert.False(GetWebProfile().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebProfileToStringTest()
        {
            Assert.False(GetWebProfile().ToString().Length == 0);
        }

        [Fact, Trait("Category", "Functional")]
        public void WebProfileGetListTest()
        {
            try
            {
                // Create a new profile
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the list of profiles
                var profiles = WebProfile.GetList(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(profiles);
                Assert.True(profiles.Count > 0);

                // Delete the profile
                profile.id = createdProfile.id;
                profile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebProfileCreateAndGetTest()
        {
            try
            {
                // Create the profile
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var profile = WebProfileTest.GetWebProfile();
                profile.name = Guid.NewGuid().ToString();
                var response = profile.Create(apiContext);
                this.RecordConnectionDetails();

                Assert.NotNull(response);
                Assert.NotNull(response.id);

                // Get the profile
                var profileId = response.id;
                var retrievedProfile = WebProfile.Get(apiContext, profileId);
                this.RecordConnectionDetails();

                Assert.Equal(profileId, retrievedProfile.id);

                // Delete the profile
                retrievedProfile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebProfileUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a new profile
                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the profile object for the new profile
                profile = WebProfile.Get(apiContext, createdProfile.id);
                this.RecordConnectionDetails();

                // Update the profile
                var newName = "New " + profileName;
                profile.name = newName;
                profile.Update(apiContext);
                this.RecordConnectionDetails();

                // Get the profile again and verify it was successfully updated.
                var retrievedProfile = WebProfile.Get(apiContext, profile.id);
                this.RecordConnectionDetails();

                Assert.Equal(newName, retrievedProfile.name);

                // Delete the profile
                profile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebProfilePartialUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a new profile
                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the profile object for the new profile
                profile = WebProfile.Get(apiContext, createdProfile.id);
                this.RecordConnectionDetails();

                // Partially update the profile
                var newName = "New " + profileName;
                var patch1 = new Patch
                {
                    op = "add",
                    path = "/presentation/brand_name",
                    value = newName
                };

                var patch2 = new Patch
                {
                    op = "remove",
                    path = "/flow_config/landing_page_type"
                };

                var patchRequest = new PatchRequest
                {
                    patch1,
                    patch2
                };

                profile.PartialUpdate(apiContext, patchRequest);
                this.RecordConnectionDetails();

                // Get the profile again and verify it was successfully updated via the patch commands.
                var retrievedProfile = WebProfile.Get(apiContext, profile.id);
                this.RecordConnectionDetails();

                Assert.Equal(newName, retrievedProfile.presentation.brand_name);
                Assert.True(string.IsNullOrEmpty(retrievedProfile.flow_config.landing_page_type));

                // Delete the profile
                profile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Fact, Trait("Category", "Functional")]
        public void WebProfileDeleteTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a new profile
                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the profile object for the new profile
                profile = WebProfile.Get(apiContext, createdProfile.id);
                this.RecordConnectionDetails();

                // Delete the profile
                profile.Delete(apiContext);
                this.RecordConnectionDetails();

                Assert.Equal(204, (int)PayPalResource.LastResponseDetails.Value.StatusCode);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
