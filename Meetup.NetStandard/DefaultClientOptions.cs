using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    public class DefaultClientOptions
    {
        public HttpClient Client { get; set; }
        public JsonSerializer CustomSerializer { get; set; }
        public Dictionary<string,string> AddedQueryString { get; set; }
    }
}
