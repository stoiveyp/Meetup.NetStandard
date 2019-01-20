using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetup.NetStandard.Request;
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

        public Task<MeetupResponse<Group>> Get(string groupName,string[] fields)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            return MeetupRequestMethods.GetWithRequestAsync<Group>($"/{groupName}", _options, MeetupRequest.FieldsOnly(fields));
        }

        public Task<MeetupResponse<List<Group>>> Find()
        {
            return MeetupRequestMethods.GetWithRequestAsync<List<Group>>($"/find/groups", _options, null);
        }
    }
}
