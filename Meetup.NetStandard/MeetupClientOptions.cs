using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public class MeetupClientOptions
    {
        public HttpClient Client { get; set; }
        public JsonSerializer CustomSerializer { get; set; }
        public Dictionary<string,string> AddedQueryString { get; set; }
        internal AuthLevel Level { get; set; }
    }
}
