using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Rsvps
{
    public class RsvpEventContext
    {
        [JsonProperty("host")]
        public bool Host { get; set; }
    }
}
