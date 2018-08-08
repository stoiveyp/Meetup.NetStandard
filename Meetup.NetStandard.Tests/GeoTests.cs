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

            var hitHandler = false;
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/location?query=bas&long=57.2&lat=-1.18&page=2&offset=1")
            };

            var meetup = MeetupClient.WithApiToken("testToken",options);
            await meetup.Geo.FindLocation(request);
        }

        [Fact]
        public async Task LocationFindGeneratesCorrectResponse()
        {
            var request = new FindLocationRequest
            {
                Name = "bas",
                Longitude = 57.2,
                Latitude = -1.18,
                Page = 1,
                PageSize = 2
            };

            var hitHandler = false;
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("FindLocation")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Geo.FindLocation(request);
            Assert.Equal(5,response.Data.Length);
        }
    }
}
