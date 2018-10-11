using Meetup.NetStandard.Response.Topics;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Groups
{
    public class Group : MeetupGroup
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("visibility")]
        public MeetupVisibility Visibility { get; set; }

        [JsonProperty("untranslated_city")]
        public string UntranslatedCity { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("localized_country_name")]
        public string LocalizedCountryName { get; set; }

        [JsonProperty("organizer")]
        public GroupOrganizer Organizer { get; set; }

        [JsonProperty("group_photo")]
        public MeetupPhoto GroupPhoto { get; set; }

        [JsonProperty("key_photo")]
        public MeetupPhoto KeyPhoto { get; set; }

        [JsonProperty("next_event")]
        public MeetupEvent NextEvent { get; set; }

        [JsonProperty("category")]
        public MeetupCategory Category { get; set; }

        [JsonProperty("meta_categpry")]
        public TopicCategory MetaCategory { get; set; }

        [JsonProperty("members")]
        public int Members { get; set; }
    }
}
