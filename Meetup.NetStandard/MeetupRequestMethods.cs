using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Response;
using System.IO;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    internal static class MeetupRequestMethods
    {
        internal static async Task<HttpResponseMessage> GetAsync(
            string requestUri,
            MeetupClientOptions options,
            MeetupRequest request = null)
        {
            var fullUri = $"{requestUri}{BuildQueryString(request?.AsDictionary(),options)}";
            var message = new HttpRequestMessage(HttpMethod.Get, fullUri);

            AddContext(message, request);

            var response = await options.Client.SendAsync(message);
            return response;
        }

        internal static async Task<HttpResponseMessage> PostAsync<TContent>(
    string requestUri,
    MeetupClientOptions options,
        TContent content)
        {
            var fullUri = $"{requestUri}{BuildQueryString(new Dictionary<string, string>(), options)}";
            var message = new HttpRequestMessage(HttpMethod.Post, fullUri);

            var mem = new MemoryStream();
            var writer = new JsonTextWriter(new StreamWriter(mem));
            options.CustomSerializer.Serialize(writer, content);
            await writer.FlushAsync();

            mem.Seek(0, SeekOrigin.Begin);
            message.Content = new StreamContent(mem);

            var response = await options.Client.SendAsync(message);
            return response;
        }

        internal static async Task<MeetupResponse<T>> GetWithRequestAsync<T>(string requestUri, MeetupClientOptions options, MeetupRequest request)
        {
            var response = await GetAsync(requestUri, options, request);
            return await response.AsObject<T>(options);
        }

        internal static async Task<MeetupResponse<TResponse>> PostWithContentAsync<TContent, TResponse>(string requestUri, MeetupClientOptions options, TContent content)
        {
            var response = await PostAsync(requestUri, options, content);
            return await response.AsObject<TResponse>(options);
        }

        private static void AddContext(HttpRequestMessage message, MeetupRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request?.ContextEventId))
            {
                message.Headers.Add("X-Meta-Visit-Event", request.ContextEventId);
            }

            if (!string.IsNullOrWhiteSpace(request?.ContextGroupName))
            {
                message.Headers.Add("X-Meta-Visit", System.Net.WebUtility.UrlEncode(request.ContextGroupName));
            }
        }

        private static string BuildQueryString(Dictionary<string, string> qstring, MeetupClientOptions options)
        {
            if(qstring == null && options.AddedQueryString == null)
            {
                return string.Empty;
            }

            var osb = new StringBuilder();
            var added = AddTo(osb, qstring,true);
            added = AddTo(osb, options.AddedQueryString, added);
            return osb.ToString();
        }

        private static bool AddTo(StringBuilder osb, Dictionary<string, string> queryString, bool first)
        {
            if((queryString?.Count ?? 0) == 0)
            {
                return first;
            }

            foreach (var item in queryString)
            {
                osb.Append(first ? "?" : "&");

                osb.Append(item.Key);
                osb.Append("=");
                osb.Append(System.Net.WebUtility.UrlEncode(item.Value));
                first = false;
            }
            return first;
        }
    }
}
