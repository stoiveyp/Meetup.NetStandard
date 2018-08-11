using System;
namespace Meetup.NetStandard.Request.Topics
{
    public class FindTopicRequest
    {
        public string Query { get; set; }

        public FindTopicRequest(string query)
        {
            Query = query;
        }
    }
}
