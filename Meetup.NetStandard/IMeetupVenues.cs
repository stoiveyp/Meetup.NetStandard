using System.Threading.Tasks;
using Meetup.NetStandard.Request.Venues;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Venues;

namespace Meetup.NetStandard
{
    public interface IMeetupVenues
    {
        Task<MeetupResponse<Venue[]>> Find(string text);
        Task<MeetupResponse<Venue[]>> Find(string text,VenueOrderBy orderBy,bool descending=false);
        Task<MeetupResponse<Venue[]>> Find(FindVenuesRequest request);

        Task<MeetupResponse<Venue[]>> Recommended();
        Task<MeetupResponse<Venue[]>> Recommended(RecommendedVenuesRequest request);
        Task<MeetupResponse<Venue[]>> For(string groupName);
        Task<MeetupResponse<Venue[]>> For(GroupVenueRequest groupName);
        Task<MeetupResponse<Venue>> CreateFor(string groupName, Venue venue);
    }
}
