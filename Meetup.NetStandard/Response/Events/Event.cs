﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meetup.NetStandard.Response.Events
{
    public class Event:MeetupEvent
    {
        [JsonProperty("created"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("duration")]
        public long DurationMilliseconds { get; set; }

        [JsonProperty("status")]
        public EventStatus Status { get; set; }

        [JsonProperty("local_date")]
        public string LocalDate { get; set; }

        [JsonProperty("local_time")]
        public string LocalTime { get; set; }

        [JsonProperty("updated"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Updated { get; set; }

        [JsonProperty("waitlist_count")]
        public int WaitlistCount { get; set; }

        [JsonProperty("venue")]
        public EventVenue Venue { get; set; }

        [JsonProperty("group")]
        public EventGroup Group { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("visibility")]
        public MeetupVisibility Visibility { get; set; }

        [JsonProperty("how_to_find_us")]
        public string HowToFindUs { get; set; }
    }
}
