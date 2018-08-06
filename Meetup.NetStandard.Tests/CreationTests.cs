using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class CreationTests
    {
        private const string TestToken = "testtoken";

        [Fact]
        public void EmptyOAuthTokenThrowsException()
        {
            Assert.Throws<ArgumentException>("token",() => MeetupClient.WithOAuthToken(string.Empty));
        }

        [Fact]
        public void NullOAuthTokenThrowsException()
        {
            Assert.Throws<ArgumentException>("token", () => MeetupClient.WithOAuthToken((string)null));
        }

        [Fact]
        public void CustomSerializerWithOAuthTokenSetCorrectly()
        {
            var serializer = new JsonSerializer();
            var meetupClient = MeetupClient.WithOAuthToken(TestToken, serializer);
            Assert.Equal(serializer,meetupClient.Serializer);
        }

        [Fact]
        public void ValidOAuthTokenCreatesClient()
        {
            var client = MeetupClient.WithOAuthToken(TestToken);
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
            Assert.NotNull(meetupClient.Serializer);
        }

        [Fact]
        public void ValidSerializerSetCorrectly()
        {
            var serializer = new JsonSerializer();
            var meetupClient = new MeetupClient(new HttpClient(), serializer);
            Assert.Equal(serializer,meetupClient.Serializer);
        }
    }
}
