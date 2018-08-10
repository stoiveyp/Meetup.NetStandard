using System;
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
    }
}
