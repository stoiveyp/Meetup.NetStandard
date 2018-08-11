using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<MeetupResponse<Topic[]>> Find(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            return Find(new FindTopicRequest(query));
        }

        public Task<MeetupResponse<Topic[]>> Find(FindTopicRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return MeetupRequestMethods.GetWithRequestAsync<Topic[]>(
                "find/topics",
                _options, request);
        }

        public Task<MeetupResponse<Topic[]>> RecommendedGroupTopic(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return RecommendedGroupTopic(new RecommendedGroupTopicRequest(text));
        }

        public Task<MeetupResponse<Topic[]>> RecommendedGroupTopic(IEnumerable<int> basedOnTopics)
        {
            var groupArray = basedOnTopics?.ToArray() ?? new int[] { };
            if (!groupArray.Any())
            {
                throw new ArgumentNullException(nameof(basedOnTopics));
            }

            return RecommendedGroupTopic(new RecommendedGroupTopicRequest(groupArray));
        }

        public Task<MeetupResponse<Topic[]>> RecommendedGroupTopic(RecommendedGroupTopicRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return MeetupRequestMethods.GetWithRequestAsync<Topic[]>("recommended/group_topics",
                _options, request);
        }
    }
}
