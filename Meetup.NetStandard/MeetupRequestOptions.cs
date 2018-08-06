using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public class MeetupRequestOptions
    {
        public async Task<HttpResponseMessage> GetAsync(string requestUri,HttpClient client, Dictionary<string,string> querystringParameters = null)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"{requestUri}{BuildQueryString(querystringParameters)}");
            var response = await client.SendAsync(message);
            return response;
        }

        private static string BuildQueryString(Dictionary<string, string> qstring)
        {
            if (qstring == null)
            {
                return string.Empty;
            }

            var osb = new StringBuilder();
            var first = true;
            foreach (var item in qstring)
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
