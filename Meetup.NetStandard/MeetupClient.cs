using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public class MeetupClient
    {
        public const string MeetupApiBaseAddress = "https://api.meetup.com";
        public DefaultClientOptions Defaults { get; }

        private IMeetupMeta _meta;

        public static MeetupClient WithApiToken(string token, DefaultClientOptions options = null)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("No token specified", nameof(token));
            }

            options = SetupOptions(options, null);
            options.AddedQueryString.Add("sign","true");
            options.AddedQueryString.Add("key",token);
            return new MeetupClient(options);
        }

        public static MeetupClient WithOAuthToken(string token, DefaultClientOptions options = null)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("No token specified", nameof(token));
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return new MeetupClient(SetupOptions(options,client));
        }

        public MeetupClient(DefaultClientOptions options)
        {
            Defaults = SetupOptions(options,null);
        }

        public IMeetupMeta Meta => _meta ?? (_meta = new MetaCalls(Defaults));

        public static DefaultClientOptions SetupOptions(DefaultClientOptions options, HttpClient client)
        {
            options = options ?? new DefaultClientOptions();
            options.Client = client ?? options.Client ?? new HttpClient();
            options.CustomSerializer = options.CustomSerializer ?? JsonSerializer.CreateDefault();
            options.AddedQueryString = options.AddedQueryString ?? new Dictionary<string, string>();

            if (options.Client.BaseAddress == null)
            {
                options.Client.BaseAddress = new Uri(MeetupApiBaseAddress, UriKind.Absolute);
            }

            return options;
        }
    }
}
