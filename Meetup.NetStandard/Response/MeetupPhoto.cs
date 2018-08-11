using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response
{
    public class MeetupPhoto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("highres_link")]
        public Uri HighRes { get; set; }

        [JsonProperty("photo_link")]
        public Uri Photo { get; set; }

        [JsonProperty("thumb_link")]
        public Uri Thumb { get; set; }

        [JsonProperty("base_url")]
        public Uri BaseUrl { get; set; }

        [JsonProperty("type")]
        public MeetupPhotoType Type { get; set; }
    }
}
