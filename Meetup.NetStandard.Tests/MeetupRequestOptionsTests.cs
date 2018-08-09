using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class MeetupRequestOptionsTests
    {
        [Fact]
        public async Task SetQuerystringAppearsInUrl()
        {
            var defaults = new MeetupClientOptions
            {
                Client = new FakeHttpClient(req =>
                {
                    Assert.Equal("/test?test=test", req.RequestUri.PathAndQuery);
                    return new HttpResponseMessage();
                })
            };

            await MeetupRequestMethods.GetAsync("/test", defaults, new FakeMeetupRequest());
        }

        [Fact]
        public async Task ContextHeadersWork()
        {
            var defaults = new MeetupClientOptions
            {
                Client = new FakeHttpClient(req =>
                {
                    Assert.Equal("test%25group",req.Headers.GetValues("X-Meta-Visit").First());
                    Assert.Equal("12345", req.Headers.GetValues("X-Meta-Visit-Event").First());
                    Assert.Equal("/test?test=test", req.RequestUri.PathAndQuery);
                    return new HttpResponseMessage();
                })
            };

            await MeetupRequestMethods.GetAsync("/test", defaults, new FakeMeetupRequest{
                ContextEventId = "12345",
                ContextGroupName = "test%group"
            });
        }

        private class FakeMeetupRequest : MeetupRequest
        {
            public override Dictionary<string, string> AsDictionary()
            {
                return new Dictionary<string, string>
            {
                {"test","test"}
                };
            }
        }
    }
}
