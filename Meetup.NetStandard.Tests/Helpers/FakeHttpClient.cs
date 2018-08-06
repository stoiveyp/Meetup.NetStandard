using System;
using System.Net.Http;
using Xunit;

namespace Meetup.NetStandard.Tests.Helpers
{
    internal class FakeHttpClient:HttpClient
    {
        internal FakeHttpClient(Func<HttpRequestMessage,HttpResponseMessage> handler) :base(new ActionMessageHandler(handler)) {
            BaseAddress = new Uri("https://test.com",UriKind.Absolute);
        }

        public static HttpClient AssertUrl(string requestUri)
        {
            return new FakeHttpClient(r =>
            {
                Assert.Equal(requestUri,r.RequestUri.PathAndQuery);
                return new HttpResponseMessage();
            });
        }
    }
}
