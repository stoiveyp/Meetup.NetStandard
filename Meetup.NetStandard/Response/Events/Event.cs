using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meetup.NetStandard.Response.Events
{
    public class Event
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public long DurationMilliseconds { get; set; }

        [JsonProperty("status")]
        public EventStatus Status { get; set; }

        [JsonProperty("time"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("local_date")]
        public string LocalDate { get; set; }

        [JsonProperty("local_time")]
        public string LocalTime { get; set; }

        [JsonProperty("updated"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Updated { get; set; }

        [JsonProperty("utc_offset")]
        public long UtcOffsetMilliseconds { get; set; }

        [JsonProperty("waitlist_count")]
        public int WaitlistCount { get; set; }

        [JsonProperty("yes_rsvp_count")]
        public int RSVPYesCount { get; set; }

        [JsonProperty("venue")]
        public EventVenue Venue { get; set; }

        [JsonProperty("group")]
        public EventGroup Group { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("visibility")]
        public EventVisibility Visibility { get; set; }

        [JsonProperty("how_to_find_us")]
        public string HowToFindUs { get; set; }
    }
}
