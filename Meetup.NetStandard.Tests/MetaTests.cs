using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class MetaTests
    {
        [Fact]
        public void MetaCreated()
        {
            var client = new MeetupClient(new HttpClient());
            Assert.NotNull(client.Meta);
        }

        [Fact]
        public async Task StatusCreatesCorrectCall()
        {
            var client = FakeHttpClient.AssertUrl("/status");
            var meetup = new MeetupClient(client);
            await meetup.Meta.Status();
        }

    }
}
