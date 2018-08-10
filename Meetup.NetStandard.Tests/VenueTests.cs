using System;
using System.Linq;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Venues;
using Meetup.NetStandard.Response.Venues;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class VenueTests
    {
        [Fact]
        public void VenueCreatedCorrectly()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            Assert.NotNull(meetup.Venues);
        }

        [Fact]
        public async Task FindVenueParsesData()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("FindVenues")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Venues.Find("test");
            Assert.Equal(3, response.Data.Length);

            var sample = response.Data.First();

            Assert.Equal(10, sample.Tags.Length);
            Assert.Equal(VenueVisibility.Public, sample.Visibility);
            Assert.Equal("Quartet statue", sample.Name);
        }

        [Fact]
        public async Task FindVenueNameErrorsWhenBlank()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Venues.Find(string.Empty));
        }

        [Fact]
        public async Task FindVenueRequestErrorsWhenBlank()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            await Assert.ThrowsAsync<InvalidOperationException>(() => meetup.Venues.Find(new FindVenuesRequest()));
        }

        [Fact]
        public async Task FindVenueNameGeneratesCorrectUrl()
        {
            var request = new FindVenuesRequest
            {
                Text = "rock city"
            };

            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/venues?text=rock+city&fields=taglist")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Venues.Find("rock city");
        }

        [Fact]
        public async Task FindVenueOrderedNameGeneratesCorrectUrl()
        {
            var request = new FindVenuesRequest
            {
                Text = "rock city"
            };

            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/venues?text=rock+city&fields=taglist&order=rating")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Venues.Find("rock city",VenueOrderBy.Rating);
        }

        [Fact]
        public async Task FindVenueRequestGeneratesCorrectUrl()
        {
            var request = new FindVenuesRequest
            {
                Text = "rock city",
                Country = "UK",
                Latitude = 2.3,
                Longitude = 20.5,
                Location = "nottingham",
                MilesRadius = 25.6,
                Zip = "NG6",
                Descending=true,
                OrderBy=VenueOrderBy.Rating_Count
            };

            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/venues?text=rock+city&fields=taglist&country=UK&lat=2.3&lon=20.5&location=nottingham&radius=25.6&zip=NG6&order=rating_count&desc=true")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Venues.Find(request);
        }
    }
}
