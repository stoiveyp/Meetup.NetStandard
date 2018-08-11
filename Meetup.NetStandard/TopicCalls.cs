using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Geo;
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

        public Task<MeetupResponse<TopicCategory[]>> FindCategories()
        {
            return FindCategories(new FindTopicCategoriesRequest());
        }

        public Task<MeetupResponse<TopicCategory[]>> FindCategories(FindTopicCategoriesRequest request)
        {
            return MeetupRequestMethods.GetWithRequestAsync<TopicCategory[]>(
                "find/topic_categories",
                _options, request);
        }
    }
}
