using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Events
{
    public class EventVenue:MeetupVenue
    {
        [JsonProperty("repinned")]
        public bool Repinned { get; set; }


    }
}
