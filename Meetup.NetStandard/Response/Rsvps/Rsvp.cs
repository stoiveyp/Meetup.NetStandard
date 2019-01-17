using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Rsvps
{
    public class Rsvp
    {
        [JsonProperty("created"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("updated"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Updated { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("guests")]
        public int Guests { get; set; }

        [JsonProperty("event")]
        public RsvpEvent Event { get; set; }

        [JsonProperty("group")]
        public RsvpGroup Group { get; set; }

        [JsonProperty("member")]
        public RsvpMember Member { get; set; }

        [JsonProperty("venue")]
        public RsvpVenue Venue { get; set; }
    }
}
