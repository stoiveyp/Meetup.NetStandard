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
            var defaults = new DefaultClientOptions{Client= new FakeHttpClient(req =>
            {
                Assert.Equal("/test?test=test", req.RequestUri.PathAndQuery);
                return new HttpResponseMessage();
            })};

            await MeetupRequestMethods.GetAsync("/test",defaults,new Dictionary<string,string>
            {
                {"test","test"}
            });
        }
    }
}
