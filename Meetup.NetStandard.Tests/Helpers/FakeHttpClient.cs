using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                return new HttpResponseMessage(HttpStatusCode.OK);
            });
        }

        public static HttpClient AssertMultiPartFormDataContent(string requestUri,Dictionary<string,string> stringContent, Dictionary<string,Stream> fileContent)
        {
            return new FakeHttpClient(async r =>
            {
                var pathAndQuery = r.RequestUri.PathAndQuery;
                var signPos = pathAndQuery.IndexOf("sign=", StringComparison.InvariantCulture) - 1;
                if (signPos > 0)
                {
                    pathAndQuery = pathAndQuery.Substring(0, signPos);
                }

                Assert.Equal(requestUri, pathAndQuery);
                var content = Assert.IsType<MultipartFormDataContent>(r.Content);
                if (stringContent != null)
                {
                    foreach (var stringItem in stringContent)
                    {
                        var s = content.First(hc => hc.Headers.ContentDisposition.Name == stringItem.Key) as StringContent;
                        Assert.Equal(stringItem.Value,await s.ReadAsStringAsync());
                    }
                }

                if (fileContent != null)
                {
                    foreach (var fileItem in fileContent)
                    {
                        var f = content.First(hc => hc.Headers.ContentDisposition.Name == fileItem.Key)as StreamContent;
                        var actualFile = await f.ReadAsStringAsync();
                        var expectedFile = await new StreamReader(fileItem.Value).ReadToEndAsync();
                        Assert.Equal(expectedFile,actualFile);
                    }
                }

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
