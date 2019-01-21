using System.Collections.Generic;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response
{
    public class MeetupGroupBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("join_mode")]
        public JoinMode JoinMode { get; set; }

        [JsonProperty("urlname")]
        public string UrlName { get; set; }

        [JsonProperty("who")]
        public string Who { get; set; }

        [JsonProperty("localized_location")]
        public string LocalizedLocation { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> ExtraFields { get; set; } 
    }
}
