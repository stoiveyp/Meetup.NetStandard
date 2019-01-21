using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meetup.NetStandard.Response
{
    public class MeetupGroup:MeetupGroupBase
    {
        [JsonProperty("created"), JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}
