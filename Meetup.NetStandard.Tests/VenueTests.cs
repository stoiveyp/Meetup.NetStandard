using System;
using System.Linq;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Venues;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Response;
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
            await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Venues.Find(new FindVenuesRequest(string.Empty)));
        }

        [Fact]
        public async Task FindVenueNameGeneratesCorrectUrl()
        {
            var request = new FindVenuesRequest("rock city");

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
            var request = new FindVenuesRequest("rock city");

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
            var request = new FindVenuesRequest("rock city")
            {
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

        [Fact]
        public async Task RecommendedVenueEmptyGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/recommended/venues?fields=taglist")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Venues.Recommended();
        }

        [Fact]
        public async Task RecommendedVenueRequestGeneratesCorrectUrl()
        {
            var request = new RecommendedVenuesRequest { 
                Categories = new []{"testcat1","testcat2"},
                Country = "UK",
                GroupIds = new[]{"testgroup1","testgroup2"},
                GroupNames = new[]{"testname1","testname2"},
                Latitude=56.7,
                Longitude=-1.18,
                Location="Nottingham",
                MinimumGroups=5,
                MilesRadius=30.5,
                UsedBetween = new MeetupTimeSpan("1m","2m"),
                Zip="NG120FF"
            };

            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/recommended/venues?fields=taglist&category=testcat1%2Ctestcat2&country=UK&group_id=testgroup1%2Ctestgroup2&group_urlname=testname1%2Ctestname2&lat=56.7&lon=-1.18&location=Nottingham&min_groups=5&radius=30.5&used_between=1m%2C2m&zip=NG120FF")
            };

            var meetup = MeetupClient.WithApiToken("tokenToken", options);
            await meetup.Venues.Recommended(request);
        }

        [Fact]
        public async Task ForGroupThrowsErrorOnEmpty()
        {
            var meetup = MeetupClient.WithApiToken("testtoken");
            await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Venues.For(string.Empty));
        }

        [Fact]
        public async Task ForGroupGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham/venues?fields=taglist")
            };

            var meetup = MeetupClient.WithApiToken("testToken",options);
            await meetup.Venues.For("tech-nottingham");
        }

        [Fact]
        public async Task CreateForThrowsErrorOnEmptyGroup()
        {
            var meetup = MeetupClient.WithApiToken("testtoken");
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Venues.CreateFor(string.Empty,null));
            Assert.Equal("groupName", exception.ParamName);
        }

        [Fact]
        public async Task CreateForThrowsErrorOnNullVenue()
        {
            var meetup = MeetupClient.WithApiToken("testtoken");
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Venues.CreateFor("test", null));
            Assert.Equal("venue", exception.ParamName);
        }

        [Fact]
        public async Task CreateForGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham/venues?fields=taglist", System.Net.Http.HttpMethod.Post)
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Venues.CreateFor("tech-nottingham",new Venue());
        }

        [Fact]
        public async Task CreateForGeneratesCorrectBodyContent()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertContent<Venue>(v => {
                    Assert.NotNull(v);
                    Assert.Equal("random place", v.Name);
                })
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Venues.CreateFor("tech-nottingham", new Venue{Name="random place"});
        }

        //TODO: Handle Conflict on CreateFor
    }
}
