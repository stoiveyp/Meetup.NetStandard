using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Venues;

namespace Meetup.NetStandard
{
    public interface IMeetupVenues
    {
        Task<MeetupResponse<Venue[]>> Find(string name);
        Task<MeetupResponse<Venue[]>> Find(FindVenuesRequest request);
    }
}
