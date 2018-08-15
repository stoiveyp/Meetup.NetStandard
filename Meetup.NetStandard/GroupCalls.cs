using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Groups;

namespace Meetup.NetStandard
{
    public class GroupCalls:IMeetupGroups
    {
        private readonly MeetupClientOptions _options;

        public GroupCalls(MeetupClientOptions options)
        {
            _options = options;
        }


        public Task<MeetupResponse<Group>> Get(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            return MeetupRequestMethods.GetWithRequestAsync<Group>($"/{groupName}", _options, null);
        }
    }
}
