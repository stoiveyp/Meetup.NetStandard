using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Rsvps
{
    public class RsvpMember:MeetupMember
    {
        [JsonProperty("event_context")]
        public RsvpEventContext EventContext { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
