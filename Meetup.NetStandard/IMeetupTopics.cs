using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Topics;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Topics;

namespace Meetup.NetStandard
{
    public interface IMeetupTopics
    {
        Task<MeetupResponse<TopicCategory[]>> FindCategories();
        Task<MeetupResponse<TopicCategory[]>> FindCategories(FindTopicCategoriesRequest request);
        Task<MeetupResponse<Topic[]>> Find(string query);
        Task<MeetupResponse<Topic[]>> Find(FindTopicRequest request);
        Task<MeetupResponse<Topic[]>> RecommendedGroupTopic(string text);
        Task<MeetupResponse<Topic[]>> RecommendedGroupTopic(IEnumerable<int> basedOn);
        Task<MeetupResponse<Topic[]>> RecommendedGroupTopic(RecommendedGroupTopicRequest request);
    }
}
