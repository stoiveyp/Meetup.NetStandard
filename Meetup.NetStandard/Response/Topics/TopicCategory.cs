using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Topics
{
    public class TopicCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("category_ids")]
        public int[] CategoryIds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo")]
        public MeetupPhoto Photo { get; set; }

        [JsonProperty("shortname")]
        public string ShortName { get; set; }

        [JsonProperty("sort_name")]
        public string SortName { get; set; }
    }
}
