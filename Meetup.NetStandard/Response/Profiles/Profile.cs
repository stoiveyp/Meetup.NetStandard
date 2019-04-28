using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meetup.NetStandard.Response.Profiles
{
    public class Profile
    {
        [JsonProperty("bio",NullValueHandling = NullValueHandling.Ignore)]
        public string Bio { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("localized_country_name",NullValueHandling = NullValueHandling.Ignore)]
        public string LocalizedCountryName { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("joined"),JsonConverter(typeof(MillisecondUnixDateTimeConverter))]
        public DateTime Joined { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo", NullValueHandling = NullValueHandling.Ignore)]
        public MeetupPhoto Photo { get; set; }

        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public ProfileStatus Status { get; set; }
    }
}
