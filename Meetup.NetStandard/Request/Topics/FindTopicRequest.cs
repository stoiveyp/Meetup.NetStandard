using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Topics
{
    public class FindTopicRequest:PagedMeetupRequest
    {
        public string Query { get; set; }

        public FindTopicRequest(string query)
        {
            Query = query;
        }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"photo-host","public"}
            };

            if (!string.IsNullOrWhiteSpace(Query))
            {
                dictionary.Add("query", Query);
            }

            AddPagination(dictionary);

            return dictionary;
        }
    }
}
