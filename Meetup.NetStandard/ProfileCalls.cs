using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Profiles;

namespace Meetup.NetStandard
{
    internal class ProfileCalls:IMeetupProfiles
    {
        private readonly MeetupClientOptions _options;
        internal ProfileCalls(MeetupClientOptions options)
        {
            _options = options;
        }


        public Task<MeetupResponse<Profile>> Get()
        {
            return MeetupRequestMethods.GetAsync<Profile>("/members/self", _options);
        }
    }
}
