using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Topics
{
    public class Topic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("urlkey")]
        public string UrlKey { get; set; }

        [JsonProperty("group_count")]
        public int GroupCount { get; set; }

        [JsonProperty("member_count")]
        public long MemberCount { get; set; }

        [JsonProperty("lang")]
        public string LanguageCode { get; set; }
    }
}
