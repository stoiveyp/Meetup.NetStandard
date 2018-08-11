using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
    }
}
