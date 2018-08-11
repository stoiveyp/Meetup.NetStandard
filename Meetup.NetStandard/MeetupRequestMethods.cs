using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Meetup.NetStandard.Request;
using System;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public static class MeetupRequestMethods
    {
        public static async Task<HttpResponseMessage> GetAsync(
            string requestUri,
            MeetupClientOptions options,
            MeetupRequest request = null)
        {
            var fullUri = $"{requestUri}{BuildQueryString(request?.AsDictionary(),options)}";
            var message = new HttpRequestMessage(HttpMethod.Get, fullUri);
            if(!string.IsNullOrWhiteSpace(request?.ContextEventId))
            {
                message.Headers.Add("X-Meta-Visit-Event", request.ContextEventId);
            }

            if (!string.IsNullOrWhiteSpace(request?.ContextGroupName))
            {
                message.Headers.Add("X-Meta-Visit", System.Net.WebUtility.UrlEncode(request.ContextGroupName));
            }

            var response = await options.Client.SendAsync(message);
            return response;
        }

        public static async Task<MeetupResponse<T>> GetWithRequestAsync<T>(string requestUri, MeetupClientOptions options, MeetupRequest request)
        {
            var response = await GetAsync(requestUri, options, request);
            return await response.AsObject<T>(options);
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
