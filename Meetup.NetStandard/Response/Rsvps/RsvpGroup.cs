using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Rsvps
{
    public class RsvpGroup:MeetupGroupBase
    {
        [JsonProperty("members")]
        public int Members { get; set; }

        [JsonProperty("group_photo")]
        public MeetupPhoto GroupPhoto { get; set; }
    }
}
