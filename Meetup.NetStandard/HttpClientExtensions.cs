using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public static class HttpClientExtensions
    {
        public static async Task<MeetupResponse<T>> AsObject<T>(this HttpResponseMessage response, MeetupClientOptions options)
        {
            var raw = await AsRawObject<T>(response, options);
            return new MeetupResponse<T>(response, raw);
        }
        public static async Task<T> AsRawObject<T>(this HttpResponseMessage response, MeetupClientOptions options)
        {
            if (response.Content == null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return default(T);
                }
                throw new MeetupException(response.StatusCode);
            }

            var stream = await response.Content.ReadAsStreamAsync();
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var objectContent = options.CustomSerializer.Deserialize<T>(reader);
                    return objectContent;
                }

                var errorContent = options.CustomSerializer.Deserialize<MeetupErrorContainer>(reader);
                throw new MeetupException(response.StatusCode, errorContent.Errors);
            }
        }
    }
}
