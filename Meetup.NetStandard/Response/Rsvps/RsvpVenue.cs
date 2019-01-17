using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Rsvps
{
    public class RsvpVenue:MeetupVenue
    {
        [JsonProperty("repinned")]
        public bool Repinned { get; set; }


    }
}
