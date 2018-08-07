using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public class MeetupError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class MeetupErrorContainer
    {
        [JsonProperty("errors")]
        public MeetupError[] Errors { get; set; }
    }
}