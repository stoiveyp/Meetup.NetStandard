using System;
using System.Linq;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Rsvps;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class RsvpTests
    {
        [Fact]
        public async Task RsvpForThrowsOnEmptyNames()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            var groupNameException = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Rsvps.For(string.Empty, "something"));
            Assert.Equal("groupName", groupNameException.ParamName);
            var eventIdException = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Rsvps.For("something", string.Empty));
            Assert.Equal("eventId", eventIdException.ParamName);
        }

        [Fact]
        public async Task RsvpForUsesCorrectUrl()
        {
            var request = new GetRsvpsRequest("tech-nottingham", "258091947")
            {
                Response = RsvpStatus.YesAndNo,
                OrderBy = RsvpOrderBy.Social,
                Descending = true
            };

            var querystring = "response=yes%2Cno&order=social&desc=true";
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham/events/258091947/rsvps?photo-host=public&" + querystring)
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Rsvps.For(request);
        }

        [Fact]
        public async Task RsvpParsesDataCorrectly()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("Rsvps")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Rsvps.For("tech-nottingham", "258091947");
            Assert.Single(response.Data);

            var rsvpData = response.Data.First();
            Assert.Equal("yes",rsvpData.Response);
            Assert.Equal("coorganizer", rsvpData.Member.Role);
            Assert.Equal(460984584, rsvpData.Group.GroupPhoto.Id);
        }


    }
}
