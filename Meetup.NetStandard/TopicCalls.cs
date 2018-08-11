using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Topics;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Topics;

namespace Meetup.NetStandard
{
    public class TopicCalls : IMeetupTopics
    {
        private readonly MeetupClientOptions _options;

        public TopicCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public Task<MeetupResponse<TopicCategory[]>> Categories()
        {
            throw new NotImplementedException();
        }

        public Task<MeetupResponse<Topic[]>> Find(string query)
        {
            throw new NotImplementedException();
        }

        public Task<MeetupResponse<Topic[]>> Find(FindTopicRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
