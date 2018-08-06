using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class MeetupRequestOptionsTests
    {
        [Fact]
        public async Task SetQuerystringAppearsInUrl()
        {
            var client = new FakeHttpClient(req =>
            {
                Assert.Equal("/test?test=test", req.RequestUri.PathAndQuery);
                return new HttpResponseMessage();
            });

            var meetup = new MeetupRequestOptions();

            await meetup.GetAsync("/test",client,new Dictionary<string,string>
            {
                {"test","test"}
            });
        }
    }
}
