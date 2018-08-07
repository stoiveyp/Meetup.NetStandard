using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public static class HttpClientExtensions
    {
        public static async Task<MeetupResponse<T>> AsObject<T>(this HttpResponseMessage response,DefaultClientOptions options)
        {
            if (response.Content == null)
            {
                return default(MeetupResponse<T>);
            }

            var stream = await response.Content.ReadAsStreamAsync();
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                 var objectContent = options.CustomSerializer.Deserialize<T>(reader);
                return new MeetupResponse<T>(response,objectContent);
            }
        }
    }
}
