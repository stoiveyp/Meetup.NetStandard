using System;
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
    }
}
