using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Groups;

namespace Meetup.NetStandard
{
    public interface IMeetupGroups
    {
        Task<MeetupResponse<List<Group>>> Get();
        Task<MeetupResponse<Group>> Get(string groupName);
        Task<MeetupResponse<Group>> Get(string groupName, string[] extraFields);
        Task<MeetupResponse<List<Group>>> Find();
    }
}
