using System.Threading.Tasks;
using Meetup.NetStandard.Request.Profiles;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Groups;
using Meetup.NetStandard.Response.Profiles;

namespace Meetup.NetStandard
{
    public interface IMeetupProfiles
    {
        Task<MeetupResponse<Profile>> Get();
        Task<Profile> Update(Group group, ProfileUpdate update);
        Task<Profile> Update(string urlName, ProfileUpdate update);
    }
}
