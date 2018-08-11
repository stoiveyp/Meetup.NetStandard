using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Meetup.NetStandard.Tests.Helpers
{
    internal class FakeHttpClient:HttpClient
    {
        internal FakeHttpClient(Func<HttpRequestMessage,HttpResponseMessage> handler) :base(new ActionMessageHandler(handler)) {
            BaseAddress = new Uri("https://test.com",UriKind.Absolute);
        }

        internal FakeHttpClient(Func<HttpRequestMessage, Task<HttpResponseMessage>> handler) : base(new ActionMessageHandler(handler))
        {
            BaseAddress = new Uri("https://test.com", UriKind.Absolute);
        }

        public static HttpClient AssertUrl(string requestUri, HttpMethod method = null)
        {
            return new FakeHttpClient(r =>
            {
                var pathAndQuery = r.RequestUri.PathAndQuery;
                var signPos = pathAndQuery.IndexOf("sign=", StringComparison.InvariantCulture)-1;
                if (signPos > 0)
                {
                    pathAndQuery = pathAndQuery.Substring(0, signPos);
                }

                Assert.Equal(method ?? HttpMethod.Get, r.Method);
                Assert.Equal(requestUri,pathAndQuery);
                return new HttpResponseMessage();
            });
        }

        public static HttpClient AssertResponse(string responseExample)
        {
            return new FakeHttpClient(r =>
            {
                var message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new StringContent(System.IO.File.ReadAllText($"Examples/{responseExample}.json"));
                return message;
            });
        }

        public static HttpResponseMessage MessageResponse(HttpStatusCode code, string responseExample)
        {
            var message = new HttpResponseMessage(code);
            message.Content = new StringContent(System.IO.File.ReadAllText($"Examples/{responseExample}.json"));
            return message;
        }

        internal static HttpClient AssertContent<T>(Action<T> assertions)
        {
            return new FakeHttpClient(async r =>
            {
                var contentObject = JsonConvert.DeserializeObject<T>(await r.Content.ReadAsStringAsync());
                assertions(contentObject);
                return new HttpResponseMessage();
            });
        }
    }
}
