using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response
{
    public class StatusResponse:MeetupResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public ApiStatus Status { get; set; }
    }
}
