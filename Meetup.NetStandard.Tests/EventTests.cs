using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Events;
using Meetup.NetStandard.Request.Venues;
using Meetup.NetStandard.Response.Events;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;
using EventStatus = Meetup.NetStandard.Request.Events.EventStatus;

namespace Meetup.NetStandard.Tests
{
    public class EventTests
    {
        [Fact]
        public async Task EventForThrowsOnEmptyName()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Events.For(string.Empty));
            Assert.Equal("groupName",exception.ParamName);
        }

        [Fact]
        public async Task EventForUsesCorrectUrl()
        {
            var request = new GetEventsRequest("tech-nottingham")
            {
                NoLaterThan = new DateTime(2018, 01, 01).AddMonths(1),
                NoEarlierThan = new DateTime(2018, 01, 01).AddDays(1),
                PageSize = 20,
                ScrollTo = EventScrollTo.recent_past,
                Status = EventStatus.Draft
            };

            var querystring = "no_earlier_than=2018-01-02T00%3A00%3A00&no_later_than=2018-02-01T00%3A00%3A00&page=20&scroll=recent_past&status=draft";
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham/events?photo-host=public&"+querystring)
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Events.For(request);
        }

        [Fact]
        public async Task EventParsesDataCorrectly()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("Events")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Events.For("tech-nottingham");
            Assert.Single(response.Data);

            var eventData = response.Data.First();
            Assert.Equal("Tech Nottingham August 2018: Secure Signups and Visual Testing",eventData.Name);
            Assert.Equal(84,eventData.RSVPYesCount);
            Assert.NotNull(eventData.Venue);
            Assert.Equal("Beck Street", eventData.Venue.Address1);
            Assert.False(eventData.Venue.Repinned);
            Assert.Equal(9000000,eventData.DurationMilliseconds);
            Assert.NotNull(eventData.Group);
            Assert.Equal("Techies",eventData.Group.Who);
            Assert.Equal(EventVisibility.Public,eventData.Visibility);
        }


    }
}
