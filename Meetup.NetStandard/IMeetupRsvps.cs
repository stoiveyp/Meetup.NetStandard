using System.Threading.Tasks;
using Meetup.NetStandard.Request.Rsvps;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Rsvps;

namespace Meetup.NetStandard
{
    public interface IMeetupRsvps
    {
        Task<MeetupResponse<Rsvp[]>> For(string groupName, string eventId);
        Task<MeetupResponse<Rsvp[]>> For(GetRsvpsRequest request);
    }
}
