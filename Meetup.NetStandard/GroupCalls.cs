using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard
{
    public class GroupCalls:IMeetupGroups
    {
        private readonly MeetupClientOptions _options;

        public GroupCalls(MeetupClientOptions options)
        {
            _options = options;
        }


    }
}
