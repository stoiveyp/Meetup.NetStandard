using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Groups;

namespace Meetup.NetStandard
{
    public interface IMeetupGroups
    {
        Task<MeetupResponse<Group>> Get(string groupName);
    }
}
