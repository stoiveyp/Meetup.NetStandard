using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public class MeetupClient
    {
        public const string MeetupApiBaseAddress = "https://api.meetup.com";
        public HttpClient Client { get; }
        public JsonSerializer Serializer { get; }

        private IMeetupMeta _meta;

        public static MeetupClient WithOAuthToken(string token, JsonSerializer customSerializer = null)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("No token specified", nameof(token));
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return new MeetupClient(client, customSerializer);
        }

        public MeetupClient(HttpClient client, JsonSerializer serializer = null)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(MeetupApiBaseAddress, UriKind.Absolute);
            }

            Serializer = serializer ?? JsonSerializer.CreateDefault();
        }

        public IMeetupMeta Meta => _meta ?? (_meta = new MetaCalls(Client, Serializer));
    }
}
