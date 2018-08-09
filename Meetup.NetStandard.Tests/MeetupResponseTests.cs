using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class MeetupResponseTests
    {
        [Fact]
        public void RateLimitsSetCorrectly()
        {
            var message = new HttpResponseMessage();
            message.Headers.Add(MeetupResponse.RateLimitHeader, "60");
            message.Headers.Add(MeetupResponse.RateLimitRemainingHeader,"38");
            message.Headers.Add(MeetupResponse.RateLimitResetSecondsHeader,"10");

            var meetup = new MeetupResponse<object>(message,null);
            Assert.Equal(60,meetup.RateLimit);
            Assert.Equal(38,meetup.RateLimitRemaining);
            Assert.Equal(10,meetup.RateLimitResetSeconds);
        }

        [Fact]
        public void RateLimitNullByDefault()
        {
            var message = new HttpResponseMessage();
            var meetup = new MeetupResponse<object>(message, null);
            Assert.Null(meetup.RateLimit);
            Assert.Null(meetup.RateLimitRemaining);
            Assert.Null(meetup.RateLimitResetSeconds);
        }

        [Fact]
        public void ResponseSetsDataCorrectly()
        {
            var message = new HttpResponseMessage();
            var data = new Object();
            var meetup = new MeetupResponse<object>(message,data);
            Assert.Equal(data,meetup.Data);
        }

        [Fact]
        public async Task ErrorResponseOnNotSuccess()
        {
            var message =new HttpResponseMessage(HttpStatusCode.InsufficientStorage);
            await Assert.ThrowsAsync<MeetupException>(() => message.AsObject<object>(null));
        }

        [Fact]
        public async Task ErrorContentOnErrorJson()
        {
            var message = FakeHttpClient.MessageResponse(HttpStatusCode.InsufficientStorage,"Throttled");
            var exception = await Assert.ThrowsAsync<MeetupException>(() => message.AsObject<object>(MeetupClient.SetupOptions(null,null)));
            Assert.Single(exception.Errors);
        }

        [Fact]
        public async Task ErrorContentOnClientReturningError()
        {
            var message = FakeHttpClient.MessageResponse(HttpStatusCode.InsufficientStorage, "Throttled");
            var client = new HttpClient(new ActionMessageHandler(req => message));
            var response = await client.GetAsync("https://test.com");
            var exception = await Assert.ThrowsAsync<MeetupException>(() => response.AsObject<object>(MeetupClient.SetupOptions(null, null)));
            Assert.Single(exception.Errors);
        }

        [Fact]
        public void PaginationLinksWorkCorrectly()
        {
            var nextLink = "https://api.meetup.com/find/locations?sign=true&photo-host=public&page=200&offset=2";
            var prevLink = "https://api.meetup.com/find/locations?sign=true&photo-host=public&page=200&offset=0";
            var message = new HttpResponseMessage();
            message.Headers.Add("Link", $"<{nextLink}>; rel=\"next\"");
            message.Headers.Add("Link", $"<{prevLink}>; rel=\"prev\"");

            var meetup = new MeetupResponse<object>(message, null);
            Assert.NotNull(meetup.Previous);
            Assert.NotNull(meetup.Next);

            Assert.Equal("https://api.meetup.com/find/locations?sign=true&photo-host=public&page=200&offset=0", meetup.Previous.Url);
            Assert.Equal("https://api.meetup.com/find/locations?sign=true&photo-host=public&page=200&offset=2", meetup.Next.Url);
        }
    }
}
