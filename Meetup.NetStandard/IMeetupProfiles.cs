using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Profiles;

namespace Meetup.NetStandard
{
    public interface IMeetupProfiles
    {
        Task<MeetupResponse<Profile>> Get();
    }
}
