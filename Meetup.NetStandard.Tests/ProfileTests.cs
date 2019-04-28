using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Response.Profiles;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class ProfileTests
    {
        private const string TestToken = "testToken";

        [Fact]
        public void ProfileCreatedCorrectly()
        {
            var meetup = MeetupClient.WithApiToken(TestToken);
            Assert.NotNull(meetup.Profiles);
        }

        [Fact]
        public async Task ProfileGetSelfGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/members/self")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Profiles.Get();
        }

        [Fact]
        public async Task ProfileGetParsesResponseCorrectly()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("BasicProfile")
            };
            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Profiles.Get();

            Assert.NotNull(response.Data);
            var profile = response.Data;

            Assert.Equal("Steven Pears", profile.Name);
            Assert.Equal(123456789,profile.Id);
            Assert.Equal("gb", profile.Country);
            Assert.Equal("CityY", profile.City);
            Assert.Equal("United Kingdom", profile.LocalizedCountryName);
            Assert.Equal(ProfileStatus.Active,profile.Status);
        }
    }
}
