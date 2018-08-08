using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public static class MeetupRequestMethods
    {
        public static async Task<HttpResponseMessage> GetAsync(
            string requestUri,
            MeetupClientOptions options,
            Dictionary<string,string> querystringParameters = null)
        {
            var fullUri = $"{requestUri}{BuildQueryString(querystringParameters,options)}";
            var message = new HttpRequestMessage(HttpMethod.Get, fullUri);
            var response = await options.Client.SendAsync(message);
            return response;
        }

        private static string BuildQueryString(Dictionary<string, string> qstring, MeetupClientOptions options)
        {
            if (qstring == null)
            {
                return string.Empty;
            }

            var osb = new StringBuilder();
            var first = true;
            foreach (var item in options?.AddedQueryString == null 
                ? qstring : qstring.Concat(options.AddedQueryString))
            {
                osb.Append(first ? "?" : "&");

                osb.Append(item.Key);
                osb.Append("=");
                osb.Append(System.Net.WebUtility.UrlEncode(item.Value));
                first = false;
            }

            return osb.ToString();
        }
    }
}
