using System;
using System.Collections.Generic;
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
    }
}
