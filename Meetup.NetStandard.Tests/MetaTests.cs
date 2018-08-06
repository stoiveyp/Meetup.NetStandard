using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
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

        [Fact]
        public async Task StatusDeserialisesCorrectly()
        {
            var client = FakeHttpClient.AssertResponse("StatusResponse");
            var meetup = new MeetupClient(client);
            var meetupResponse = await meetup.Meta.Status();
            var statusResponse = meetupResponse.Data;

            Assert.Equal("test message",statusResponse.Message);
            Assert.Equal("test title",statusResponse.Title);
            Assert.Equal(ApiStatus.Unavailable,statusResponse.Status);
        }

    }
}
