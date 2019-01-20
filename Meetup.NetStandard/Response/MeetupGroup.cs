using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meetup.NetStandard.Response
{
    public class MeetupGroup
    {
        [JsonProperty("created"), JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("join_mode")]
        public JoinMode JoinMode { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("urlname")]
        public string UrlName { get; set; }

        [JsonProperty("who")]
        public string Who { get; set; }

        [JsonProperty("localized_location")]
        public string LocalizedLocation { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> ExtraFields { get; set; } 
    }
}
