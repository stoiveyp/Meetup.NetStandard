using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class GroupTests
    {
        [Fact]
        public void GroupCallsGeneratedCorrectly()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            Assert.NotNull(meetup.Groups);
        }

        [Fact]
        public async Task GetThrowsExceptionOnEmptyGroupName()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            var error = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Groups.Get(string.Empty));
            Assert.Equal("groupName",error.ParamName);
        }

        [Fact]
        public async Task GetGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham")
            };
            var meetup = MeetupClient.WithApiToken("testToken",options);
            await meetup.Groups.Get("tech-nottingham");
        }
    }
}
