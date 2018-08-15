using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Meetup.NetStandard.Response
{
    public class MeetupResponse<T>:MeetupResponse
    {
        public T Data { get; }
        public MeetupLink<T> Previous { get; private set; }
        public MeetupLink<T> Next { get; private set; }

        public MeetupResponse(HttpResponseMessage response, T data):base(response)
        {
            Data = data;
            if (!response.Headers.TryGetValues("link", out IEnumerable<string> list))
            {
                return;
            }
            Next = ProcessLink(list, "next");
            Previous = ProcessLink(list,"prev");
        }

        private MeetupLink<T> ProcessLink(IEnumerable<string> links, string linkType)
        {

            var link = links?.FirstOrDefault(l => l.EndsWith($"rel=\"{linkType}\"",StringComparison.Ordinal));
            var breaker = link?.IndexOf(';') ?? -1;
            if (breaker == -1)
            {
                return null;
            }

            return new MeetupLink<T>(link.Substring(1, breaker - 2));
        }
    }
}