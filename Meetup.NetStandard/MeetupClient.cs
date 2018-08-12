using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Newtonsoft.Json;

[assembly:InternalsVisibleTo("Meetup.NetStandard.Tests")]

namespace Meetup.NetStandard
{
    public class MeetupClient
    {
        public const string MeetupApiBaseAddress = "https://api.meetup.com";
        public MeetupClientOptions Options { get; }

        public static MeetupClient WithApiToken(string token, MeetupClientOptions options = null)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("No token specified", nameof(token));
            }

            options = SetupOptions(options, null);
            options.AddedQueryString.Add("sign", "true");
            options.AddedQueryString.Add("key", token);
            options.Level = AuthLevel.ApiKey;
            return new MeetupClient(options);
        }

        public static MeetupClient WithOAuthToken(string token, MeetupClientOptions options = null)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("No token specified", nameof(token));
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            options = SetupOptions(options, client);
            options.Level = AuthLevel.OAuth2;
            return new MeetupClient(options);
        }

        public MeetupClient(MeetupClientOptions options)
        {
            Options = SetupOptions(options, null);
        }

        private IMeetupMeta _meta;
        private IMeetupGeo _geo;
        private IMeetupVenues _venues;
        private IMeetupTopics _topics;
        private IMeetupEvents _events;

        public IMeetupMeta Meta => _meta ?? (_meta = new MetaCalls(Options));
        public IMeetupGeo Geo => _geo ?? (_geo = new GeoCalls(Options));
        public IMeetupVenues Venues => _venues ?? (_venues = new VenueCalls(Options));
        public IMeetupTopics Topics => _topics ?? (_topics = new TopicCalls(Options));
        public IMeetupEvents Events => _events ?? (_events = new EventCalls(Options));

        internal static MeetupClientOptions SetupOptions(MeetupClientOptions options, HttpClient client)
        {
            options = options ?? new MeetupClientOptions();
            options.Client = client ?? options.Client ?? new HttpClient();
            options.CustomSerializer = options.CustomSerializer ?? JsonSerializer.CreateDefault();
            options.AddedQueryString = options.AddedQueryString ?? new Dictionary<string, string>();

            if (options.Client.BaseAddress == null)
            {
                options.Client.BaseAddress = new Uri(MeetupApiBaseAddress, UriKind.Absolute);
            }

            return options;
        }

        public async Task<MeetupResponse<T>> GoToLink<T>(MeetupLink<T> meetupLink)
        {
            var response = await MeetupRequestMethods.GetAsync(meetupLink.Url, Options);
            return await response.AsObject<T>(Options);
        }
    }
}
