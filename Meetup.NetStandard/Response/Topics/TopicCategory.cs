using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Topics
{
    public class TopicCategory:MeetupCategory
    {
        [JsonProperty("category_ids")]
        public int[] CategoryIds { get; set; }

        [JsonProperty("photo")]
        public MeetupPhoto Photo { get; set; }
    }
}
