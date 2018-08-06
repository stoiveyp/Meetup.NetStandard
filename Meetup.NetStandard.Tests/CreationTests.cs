using System;
using System.Net.Http;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class CreationTests
    {
        private const string TestToken = "testtoken";

        [Fact]
        public void EmptyTokenThrowsException()
        {
            Assert.Throws<ArgumentException>("token",() => new MeetupClient(string.Empty));
        }

        [Fact]
        public void NullTokenThrowsException()
        {
            Assert.Throws<ArgumentException>("token", () => new MeetupClient((string)null));
        }

        [Fact]
        public void ValidTokenCreatesClient()
        {
            var client = new MeetupClient(TestToken);
            var header = client.Client.DefaultRequestHeaders.Authorization;
            Assert.Equal("Bearer",header.Scheme);
            Assert.Equal(TestToken,header.Parameter);
        }

        [Fact]
        public void InvalidHttpClientCreateClient()
        {
            Assert.Throws<ArgumentNullException>("client",() => new MeetupClient((HttpClient)null));
        }

        [Fact]
        public void ValidHttpClientSetCorrectly()
        {
            var httpClient = new HttpClient();
            var meetupClient = new MeetupClient(httpClient);
            Assert.Equal(httpClient,meetupClient.Client);
        }
    }
}
