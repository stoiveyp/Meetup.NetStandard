using System.Threading.Tasks;
using Meetup.NetStandard.Request.Events;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Events;

namespace Meetup.NetStandard
{
    public interface IMeetupEvents
    {
        Task<MeetupResponse<Event[]>> For(string groupName);
        Task<MeetupResponse<Event[]>> For(GetEventsRequest request);
    }
}
