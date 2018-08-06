using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Meetup.NetStandard
{
    public class MeetupClient
    {
        public HttpClient Client { get; }

        public MeetupClient(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("No token specified",nameof(token));
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            Client = client;
        }

        public MeetupClient(HttpClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }
    }
}
