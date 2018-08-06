using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response
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
