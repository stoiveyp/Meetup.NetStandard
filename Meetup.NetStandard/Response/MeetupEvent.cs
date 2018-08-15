using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response
{
    public class MeetupEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("time"), JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("utc_offset")]
        public long UtcOffsetMilliseconds { get; set; }

        [JsonProperty("yes_rsvp_count")]
        public int RSVPYesCount { get; set; }
    }
}
