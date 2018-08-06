using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public static class HttpClientExtensions
    {
        public static async Task<T> AsObject<T>(this HttpResponseMessage response,JsonSerializer serializer)
        {
            if (response.Content == null)
            {
                return default(T);
            }

            var stream = await response.Content.ReadAsStreamAsync();
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}
