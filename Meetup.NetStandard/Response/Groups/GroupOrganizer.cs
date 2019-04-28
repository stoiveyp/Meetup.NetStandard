using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Groups
{
    public class GroupOrganizer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("photo")]
        public MeetupPhoto Photo { get; set; }
    }
}