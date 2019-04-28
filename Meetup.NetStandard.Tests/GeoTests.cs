using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Geo;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class GeoTests
    {
        private const string TestToken = "testToken";

        [Fact]
        public void LocationCreatedCorrectly()
        {
            var meetup = MeetupClient.WithApiToken(TestToken);
            Assert.NotNull(meetup.Geo);
        }

        [Fact]
        public async Task LocationFindGeneratesCorrectUrl()
        {
            var request = new FindLocationRequest
            {
                Name = "bas",
                Longitude=57.2,
                Latitude=-1.18,
                Page = 1,
                PageSize=2
            };

            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/location?query=bas&lon=57.2&lat=-1.18&page=2&offset=1")
            };

            var meetup = MeetupClient.WithOAuthToken("testToken",options);
            await meetup.Geo.FindLocation(request);
        }

        [Fact]
        public async Task LocationFindGeneratesCorrectResponse()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("FindLocation")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Geo.FindLocation(string.Empty);
            Assert.Equal(5,response.Data.Length);
        }

        [Fact]
        public async Task LocationPropertiesAreAccurate()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("FindLocation")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Geo.FindLocation(string.Empty);

            var location = response.Data[2];
            Assert.Equal("Stratford ",location.City);
            Assert.Equal("gb", location.Country);
            Assert.Equal("United Kingdom", location.LocalizedCountryName);
            Assert.Equal("Stratford , England, United Kingdom",location.FullName);
            Assert.Equal("E15",location.Zip);
            Assert.Equal(51.54,location.Latitude);
            Assert.Equal(0.01,location.Longitude);
        }
    }
}
