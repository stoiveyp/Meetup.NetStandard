using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Meta
{
    public class Status
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public ApiStatus ApiStatus { get; set; }
    }
}
