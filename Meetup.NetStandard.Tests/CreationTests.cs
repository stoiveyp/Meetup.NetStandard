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
        public void SignedWithEmptyTokenThrowsException()
        {
            Assert.Throws<ArgumentException>("token", () => MeetupClient.WithApiToken(string.Empty));
        }

        [Fact]
        public void SignedWithNullTokenThrowsException()
        {
            Assert.Throws<ArgumentException>("token", () => MeetupClient.WithApiToken(null));
        }

        [Fact]
        public void ValidTokenCreatesClient()
        {
            var client = MeetupClient.WithApiToken(TestToken);
            Assert.NotNull(client.Options.AddedQueryString);
            Assert.Equal("true",client.Options.AddedQueryString["sign"]);
            Assert.Equal(TestToken,client.Options.AddedQueryString["key"]);
        }

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
            var defaults = new MeetupClientOptions
            {
                CustomSerializer = new JsonSerializer()
            };
            var meetupClient = MeetupClient.WithOAuthToken(TestToken, defaults);
            Assert.Equal(defaults,meetupClient.Options);
        }

        [Fact]
        public void ValidOAuthTokenCreatesClient()
        {
            var client = MeetupClient.WithOAuthToken(TestToken);
            var header = client.Options.Client.DefaultRequestHeaders.Authorization;
            Assert.Equal("Bearer",header.Scheme);
            Assert.Equal(TestToken,header.Parameter);
        }

        [Fact]
        public void NullDefaultCreatesDefaults()
        {
            var meetupclient = new MeetupClient(null);
            Assert.NotNull(meetupclient.Options);
            Assert.NotNull(meetupclient.Options.CustomSerializer);
            Assert.NotNull(meetupclient.Options.Client);
        }
    }
}
